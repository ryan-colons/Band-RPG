using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EncounterUI : MonoBehaviour
{
    private Encounter encounter;
    [SerializeField]
    private GameObject _gameControllerPrefab;
    [SerializeField]
    private Text _encounterNameText;
    [SerializeField]
    private Text _bandNameText;
    [SerializeField]
    private BandMemberUI[] playerMusicianSprites;
    private GameController _gameController;
    [SerializeField]
    private ActionPanelUI _actionPanel;
    [SerializeField]
    private Text _currentOutputText;
    [SerializeField]
    private Text currentHypeText;
    [SerializeField]
    private Button timeStepButton;
    [SerializeField]
    private Slider hypeSlider;
    

    public static bool IsRunning = false;

    public GameController CreateDummyGameController() 
        {
        GameController gameController = Instantiate(_gameControllerPrefab).GetComponent<GameController>();
        gameController.gameObject.name = "GameController";
        _gameController.AddMusician(new Musician("Bento", new Instrument(InstrumentType.Guitar), Resources.Load<Sprite>("Sprites/Portraits/portrait1")));
        _gameController.AddMusician(new Musician("Bort", new Instrument(InstrumentType.Piano), Resources.Load<Sprite>("Sprites/Portraits/portrait2")));
        _gameController.AddMusician(new Musician("Bbbbb", new Instrument(InstrumentType.Drum), Resources.Load<Sprite>("Sprites/Portraits/portrait3")));
        _gameController.AddMusician(new Musician("Boson", new Instrument(InstrumentType.Bass), Resources.Load<Sprite>("Sprites/Portraits/portrait4")));
        gameController.SetCurrentEncounter(new Encounter("Test Encounter", EncounterType.Performance, 100f, 30f));
        return gameController;
        }

    public void Awake ()
        {
        GameObject gameControllerGameObject = GameObject.Find("GameController");
        if (gameControllerGameObject != null) _gameController = gameControllerGameObject.GetComponent<GameController>();
        else _gameController = CreateDummyGameController();
        IsRunning = false;
        }

    public void Start ()
        {
        encounter = _gameController.GetCurrentEncounter();
        
        SetEncounterNameText(encounter.Name);
        _bandNameText.text = _gameController.bandName;
        currentHypeText.text = encounter.currentHypeValue.ToString();
        
        List<Musician> bandMembers = _gameController.GetBand();

        foreach(BandMemberUI ui in playerMusicianSprites) {
            ui.gameObject.SetActive(false);
        }

        for (int i = 0; i < bandMembers.Count && i < playerMusicianSprites.Length; i++) 
            {
                Musician currentMusician = bandMembers[i];
                playerMusicianSprites[i].gameObject.SetActive(true);
                playerMusicianSprites[i].SetMusician(currentMusician);
                Debug.Log($"Introducing... {currentMusician.Name} on the {currentMusician.Instrument.Type.ToString()}");
            }
        }
    
    public void SetEncounterNameText (string name) 
        {
        _encounterNameText.text = name;
        }

    public void TimeStep()
        {
        encounter.TimeStep();
        currentHypeText.text = encounter.currentHypeValue.ToString();
        UpdateHypeSlider();
        }

    public void UpdateHypeSlider()
        {
        float hypePercentage = (float)(encounter.currentHypeValue - encounter.LoseThreshold)/(float)(encounter.WinThreshold - encounter.LoseThreshold);
        hypeSlider.value = hypePercentage;
        Debug.Log(encounter.currentHypeValue);
        }

    public void EncounterStart()
        {
        InvokeRepeating("TimeStep", 0f, encounter.GetTimeStepLength());
        IsRunning = true;
        foreach (BandMemberUI ui in playerMusicianSprites) 
            {
            ui.StartPlaying();
            }
        }

    public void AutoWin()
        {
        encounter.EncounterEnd(1);
        }
}
