using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EncounterUI : MonoBehaviour
{
    [SerializeField]
    private Text _encounterNameText;
    [SerializeField]
    private BandMemberUI[] playerMusicianSprites;
    private GameController _gameController;

    public void Awake ()
        {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
        }

    public void Start ()
        {
        SetEncounterNameText(_gameController.GetCurrentEncounter().Name);
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

}
