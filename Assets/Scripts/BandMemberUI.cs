using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BandMemberUI : MonoBehaviour
{
    private Musician _musician;
    [SerializeField]
    private Text musicianNameText;
    [SerializeField]
    private Image musicianInstrumentIcon;
    [SerializeField]
    private ActionPanelUI actionPanel;
    [SerializeField]
    private Text currentActionText;
    private AudioSource audioSource;
    public void Start()
        {
        audioSource = GetComponent<AudioSource>();
        }
    public void SetMusician(Musician musician) 
        {
        _musician = musician;
        musicianNameText.text = musician.Name;
        musicianInstrumentIcon.sprite = musician.Instrument.Sprite;
        GetComponent<Image>().sprite = musician.MusicianPortrait;
        }

    public void SelectMusician()
        {
        actionPanel.OpenPanel(_musician, this);
        }

    public void UpdateAction()
        {
        currentActionText.text = _musician.CurrentAction.Name;
        audioSource.clip = _musician.CurrentAction.AudioClip;
        if (EncounterUI.IsRunning) 
            {
            audioSource.Play();
            }
        }

    public void StartPlaying()
        {
        audioSource.Play();
        }
    
}
