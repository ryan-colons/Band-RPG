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
    
    public void SetMusician(Musician musician) 
        {
        _musician = musician;
        musicianNameText.text = musician.Name;
        musicianInstrumentIcon.sprite = musician.Instrument.Sprite;
        }

    public void SelectMusician()
        {
        
        }
}
