using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Collections.Generic;

public class MapUI : MonoBehaviour
    {
    private GameController _gameController;
    static System.Random rnd = new System.Random();
    
    List<string> namesList = new List<string>{"Bronklyn", "Bradio", "Bricks", "Brizzel", "Bornagain", 
                                         "Breakslow", "Beelzebabe", "Binnards", "Bungheap", "Bardsworth", 
                                         "Banhomer", "Billboar", "Buggins", "Beethoven"};

    [SerializeField]
    private GameController gameController;

    [SerializeField]
    private InputField _musoNameInput;
    [SerializeField]
    private InputField _bandNameInput;
    [SerializeField]
    private ToggleGroup _musicianToggles;
    [SerializeField]
    private Toggle[] _instrumentToggles;
    [SerializeField]
    private MapBandListUI[] bandListEntries;
   
        public void Awake ()
        {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
        }
    public void GoToShow ()
        {
        Debug.Log("Going to show");

        if (string.IsNullOrEmpty(_bandNameInput.text))
            {
            Debug.LogWarning("Your band has no name!");
            return;
            }

        if (gameController.GetBand().Count <= 0)
            {
            Debug.LogWarning("Your band has no members!");
            return;
            }
            
            gameController.bandName = _bandNameInput.text;
        
            Encounter encounter = new Encounter("GIG 1", EncounterType.Performance, 100, 30);
            gameController.SetCurrentEncounter(encounter);
            SceneManager.LoadScene(1);
        }

    public void AddMember ()
        {
        string name = _musoNameInput.text;
        if (string.IsNullOrEmpty(name)) 
            {
            Debug.LogWarning("This band member needs a name!");
            return;
            }

        InstrumentType instrument = InstrumentType.Guitar;
        Sprite sprite = Resources.Load<Sprite>("Sprites/guitar");

        Toggle activeToggle = _musicianToggles.ActiveToggles().First();
        switch(activeToggle.name) 
            {
            case "guitaristToggle":
                instrument = InstrumentType.Guitar;
                sprite = Resources.Load<Sprite>("Sprites/InstrumentIcons/guitar");
                break;
            case "pianistToggle":
                instrument = InstrumentType.Piano;
                sprite = Resources.Load<Sprite>("Sprites/InstrumentIcons/keys");
                break;
            case "drummerToggle":
                instrument = InstrumentType.Drum;
                sprite = Resources.Load<Sprite>("Sprites/InstrumentIcons/drum");
                break;
            case "bassistToggle":
                instrument = InstrumentType.Bass;
                sprite = Resources.Load<Sprite>("Sprites/InstrumentIcons/bass");
                break;
            }
        
        Musician musician = new Musician(name, new Instrument(instrument, sprite));
        gameController.AddMusician(musician);
        UpdateBandList();
        
        _musoNameInput.text = "";



        }
    
    public void RandomMember ()
        {
        string name = namesList[rnd.Next(namesList.Count)];
        if(_musoNameInput.text == name)
            {
            //I tried to get this to reroll if it's the same name, but I can't think of a tidy way to do it!
            }
        _musoNameInput.text = name;

        _musicianToggles.SetAllTogglesOff();
        _instrumentToggles[rnd.Next(_instrumentToggles.Length)].isOn = true;
        }  

    public void UpdateBandList()
        {
        foreach(MapBandListUI ui in bandListEntries) 
            {
            ui.ClearEntry();
            }

        List<Musician> bandMembers = _gameController.GetBand();

        for (int i = 0; i < bandMembers.Count; i++) 
            {
            bandListEntries[i].SetMusician(bandMembers[i]);
            }
        }

   
    }
