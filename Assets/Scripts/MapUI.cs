using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class MapUI : MonoBehaviour
    {

    [SerializeField]
    private GameController gameController;

    [SerializeField]
    private InputField _nameInput;
    [SerializeField]
    private ToggleGroup _musicianToggles;

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
        if (string.IsNullOrEmpty(name)) {
            Debug.LogWarning("This band member needs a name!");
            return;
        }

        InstrumentType instrument = InstrumentType.Guitar;
        Sprite sprite = Resources.Load<Sprite>("Sprites/guitar.png");

        Toggle activeToggle = _musicianToggles.ActiveToggles().First();
        switch(activeToggle.name) {
            case "guitarist":
                instrument = InstrumentType.Guitar;
                sprite = Resources.Load<Sprite>("Sprites/guitar.png");
                break;
            case "pianist":
                instrument = InstrumentType.Piano;
                sprite = Resources.Load<Sprite>("Sprites/keys.png");
                break;
            case "drummer":
                instrument = InstrumentType.Drum;
                sprite = Resources.Load<Sprite>("Sprites/drum.png");
                break;
        }

        Musician musician = new Musician(name, new Instrument(instrument, sprite));
        gameController.AddMusician(musician);
        
        _nameInput.text = "";

        }
    }
