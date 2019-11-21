﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapBandListUI : MonoBehaviour
    {
    private GameController _gameController;
    private MapUI _mapUI;
    [SerializeField]
    private Button deleteMember;
    private Musician _musician;  
    public void Awake ()
        {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
        _mapUI = GameObject.Find("MapUI").GetComponent<MapUI>();
        }
    public void SetMusician(Musician musician)
        {
        _musician = musician;
        GetComponent<Text>().text = _musician.Name + " on the " + _musician.Instrument.Type.ToString();
        Debug.Log(_musician.Name + " on the " + _musician.Instrument.Type.ToString());
        this.gameObject.SetActive(true);

        deleteMember.gameObject.SetActive(true);
        }

    public void ClearEntry()
        {
        this.gameObject.SetActive(false);
        deleteMember.gameObject.SetActive(false);
        }
  
    public void DeleteEntry()
        {
        Debug.Log(_musician.Name + " removed from band");
        _gameController.RemoveMusician(_musician);
    //I'm so sure there's a better way of doing this!
        _mapUI.UpdateBandList();
        }
    }
