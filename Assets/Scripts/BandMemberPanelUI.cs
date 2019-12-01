using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BandMemberPanelUI : MonoBehaviour
    {
    [SerializeField]
    private Text _musoNameText;
    [SerializeField]
    private Text _musoInstrumentText;
    [SerializeField]
    private Text _musoMovesText;
    [SerializeField]
    private Image _musoPortrait;

    public void SetMusician(Musician musician)
        {
        _musoNameText.text = musician.Name;
        _musoInstrumentText.text = musician.Instrument.Type.ToString();
        List<MusicAction> musoMoves = musician.GetMusicActions();
        string musoMovesString = "";
        for(int i = 0; i < musoMoves.Count; i++)
            {
            musoMovesString += musoMoves[i].Name;
            if (i < (musoMoves.Count - 1))
                {
                musoMovesString += ", ";
                }
            }
        _musoMovesText.text = musoMovesString;
        _musoPortrait.sprite = musician.MusicianPortrait;
        }

    }