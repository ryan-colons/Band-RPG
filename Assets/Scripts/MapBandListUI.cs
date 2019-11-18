using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapBandListUI : MonoBehaviour
    {
    private Musician _musician;  
    public void SetMusician(Musician musician)
        {
        _musician = musician;
        GetComponent<Text>().text = _musician.Name + " on the " + _musician.Instrument.Type.ToString();
        Debug.Log(_musician.Name + " on the " + _musician.Instrument.Type.ToString());
        this.gameObject.SetActive(true);
        }

    }
