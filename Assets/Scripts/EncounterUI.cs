using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EncounterUI : MonoBehaviour
{
    private Encounter encounter;
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

    public void Awake ()
        {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
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

        for (int i = 0; i < bandMembers.Count; i++) 
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
}
