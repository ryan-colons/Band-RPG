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
        _musicianPortrait.sprite = MusicianCreationHelper.GetRandomSprite();
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
        _musoNameInput.text = MusicianCreationHelper.GetRandomName();
        _bandNameInput.text = MusicianCreationHelper.GetRandomName();
        _musicianPortrait.sprite = MusicianCreationHelper.GetRandomSprite();
        _instrumentDropdown.value = rnd.Next(_instrumentDropdown.options.Count);
        }

    private void ScrollPortrait (int n)
        {
        List<Sprite> sprites = MusicianCreationHelper.GetAllSprites();
        int indexOfCurrentSprite = sprites.IndexOf(_musicianPortrait.sprite);
        if (indexOfCurrentSprite != -1) 
            {
            if (indexOfCurrentSprite == 0 && n < 0)
                {
                    _musicianPortrait.sprite = sprites[sprites.Count - 1];
                }
            else if (indexOfCurrentSprite == sprites.Count - 1 && n > 0)
                {
                    _musicianPortrait.sprite = sprites[0];
                }
            else
                {
                    _musicianPortrait.sprite = sprites[indexOfCurrentSprite + n];
                }
            }
        }

    public void PreviousPortrait ()
        {
        ScrollPortrait(-1);
        }
    public void NextPortrait ()
        {
        ScrollPortrait(1);
        }
   
    }
