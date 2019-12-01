using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class TitleScreenUI : MonoBehaviour
    {
    static System.Random rnd = new System.Random();
    [SerializeField]
    private InputField _musoNameInput;
    [SerializeField]
    private InputField _bandNameInput;
    [SerializeField]
    private Dropdown _instrumentDropdown;
    [SerializeField]
    private Image _musicianPortrait;
    [SerializeField]
    private GameObject _gameControllerPrefab;
    private GameController _gameController;
   
    public void Start()
        {
        _gameController = Instantiate(_gameControllerPrefab).GetComponent<GameController>();
        _gameController.gameObject.name = "GameController";
        }
    public void StartGame()
        {

        if (string.IsNullOrEmpty(_musoNameInput.text) || string.IsNullOrEmpty(_bandNameInput.text)) 
            {
            Debug.LogWarning("Add names!");
            return;
            }

        Instrument instrument = new Instrument(InstrumentType.Guitar);
        switch(_instrumentDropdown.options[_instrumentDropdown.value].text)
            {
            case "Guitar":
                instrument = new Instrument(InstrumentType.Guitar);
                break;
            case "Piano":
                instrument = new Instrument(InstrumentType.Piano);
                break;
            case "Drum":
                instrument = new Instrument(InstrumentType.Drum);
                break;
            case "Bass":
                instrument = new Instrument(InstrumentType.Bass);
                break; 
            }

        Musician musician = new Musician(_musoNameInput.text, instrument, _musicianPortrait.sprite);

        _gameController.AddMusician(musician);
        _gameController.bandName = _bandNameInput.text;
        _gameController.LoadScene("Map");
        }

    public void Randomise ()
        {
        _musoNameInput.text = _gameController.GetRandomName();
        _bandNameInput.text = _gameController.GetRandomName();
        _musicianPortrait.sprite = _gameController.GetRandomSprite();
        _instrumentDropdown.value = rnd.Next(_instrumentDropdown.options.Count);
        }  
   
    }
