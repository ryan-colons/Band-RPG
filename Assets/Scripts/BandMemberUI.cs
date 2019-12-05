using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BandMemberUI : MonoBehaviour
{
    private Musician _musician;
    [SerializeField]
    private Text _musicianNameText;
    [SerializeField]
    private Image _musicianInstrumentIcon;
    [SerializeField]
    private ActionPanelUI _actionPanel;
    [SerializeField]
    private Text _currentActionText;
    private AudioSource _audioSource;
    public void Start()
        {
        _audioSource = GetComponent<AudioSource>();
        }
    public void SetMusician(Musician musician) 
        {
        _musician = musician;
        _musicianNameText.text = musician.Name;
        _musicianInstrumentIcon.sprite = musician.Instrument.Sprite;
        GetComponent<Image>().sprite = musician.MusicianPortrait;
        }

    public void SelectMusician()
        {
        _actionPanel.OpenPanel(_musician, this);
        }

    public void UpdateAction()
        {
        _currentActionText.text = _musician.CurrentAction.Name;
        _audioSource.clip = _musician.CurrentAction.AudioClip;
        if (EncounterUI.IsRunning) 
            {
            _audioSource.Play();
            }
        }

    public void StartPlaying()
        {
        _audioSource.Play();
        }
    
}
