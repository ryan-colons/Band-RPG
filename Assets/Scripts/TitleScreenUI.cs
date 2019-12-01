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

    private List<Sprite> playerSprites;

    private void Start ()
        {
        playerSprites = new List<Sprite>(Resources.LoadAll<Sprite>("Sprites/Portraits"));
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

        GameController gameController = Instantiate(_gameControllerPrefab).GetComponent<GameController>();
        gameController.gameObject.name = "GameController";
        gameController.AddMusician(musician);
        gameController.bandName = _bandNameInput.text;
        gameController.LoadScene("Map");

        }

    public string GetRandomName ()
        {
        List<string> namesList = new List<string>{"Bronklyn", "Bradio", "Bricks", "Brizzel", "Bornagain", 
                                        "Breakslow", "Beelzebabe", "Binnards", "Bungheap", "Bardsworth", 
                                        "Banhomer", "Billboar", "Buggins", "Beethoven"};
        return namesList[rnd.Next(namesList.Count)];
        }

    public Sprite GetRandomSprite ()
        {
        return playerSprites[rnd.Next(playerSprites.Count)];
        }
    
    public void Randomise ()
        {
        _musoNameInput.text = GetRandomName();
        _bandNameInput.text = GetRandomName();
        _musicianPortrait.sprite = GetRandomSprite();
        _instrumentDropdown.value = rnd.Next(_instrumentDropdown.options.Count);
        }  
   
    }
