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
    private InputField _nameInput;
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
    public void GoToJam ()
        {
        Debug.Log("Going to jam");

        if (gameController.GetBand().Count > 0)
            {
            Encounter encounter = new Encounter("GIG 1", EncounterType.Performance, 100);
            gameController.SetCurrentEncounter(encounter);
            SceneManager.LoadScene(1);
            }
        else
            {
            Debug.LogWarning("Your band has no members!");
            }
        
        }

    public void AddMember ()
        {
        string name = _nameInput.text;
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
                sprite = Resources.Load<Sprite>("Sprites/guitar");
                break;
            case "pianistToggle":
                instrument = InstrumentType.Piano;
                sprite = Resources.Load<Sprite>("Sprites/keys");
                break;
            case "drummerToggle":
                instrument = InstrumentType.Drum;
                sprite = Resources.Load<Sprite>("Sprites/drum");
                break;
            }
        
        Musician musician = new Musician(name, new Instrument(instrument, sprite));
        gameController.AddMusician(musician);
        UpdateBandList();
        
        _nameInput.text = "";



        }
    
    public void RandomMember ()
        {
        string name = namesList[rnd.Next(namesList.Count)];
        if(_nameInput.text == name)
            {
            //I tried to get this to reroll if it's the same name, but I can't think of a tidy way to do it!
            }
        _nameInput.text = name;

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
