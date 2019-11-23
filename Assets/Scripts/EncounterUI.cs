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
    private Text currentOutputText;
    [SerializeField]
    private Text currentHypeText;
    [SerializeField]
    private Button timeStepButton;

    
    public void Awake ()
        {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
        }

    public void Start ()
        {
        encounter = _gameController.GetCurrentEncounter();
        
        //Do we need to have a distinct method for this?
        SetEncounterNameText(encounter.Name);
        //Rather than just this?
        _bandNameText.text = _gameController.bandName;
        currentOutputText.text = encounter.GetCurrentBandValue().ToString();
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

    public void UpdateCurrentActions()
        {
        foreach(BandMemberUI ui in playerMusicianSprites)
            {
            if(ui.gameObject.activeSelf)
                {
                ui.UpdateAction();
                }
            }
        currentOutputText.text = encounter.GetCurrentBandValue().ToString();
        }

    public void TimeStep()
        {
        encounter.TimeStep();
        currentHypeText.text = encounter.currentHypeValue.ToString();

        }
}
