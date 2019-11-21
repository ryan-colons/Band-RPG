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


    public void SetMusician(Musician musician) 
        {
        _musician = musician;
        musicianNameText.text = musician.Name;
        musicianInstrumentIcon.sprite = musician.Instrument.Sprite;
        }

    public void SelectMusician()
        {
        actionPanel.OpenPanel(_musician);
        }

    public void UpdateAction()
        {
        currentActionText.text = _musician.CurrentAction.Name;
        }
}
