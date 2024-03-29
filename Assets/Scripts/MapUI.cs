﻿using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

public class MapUI : MonoBehaviour
    {
    private GameController _gameController;

    public void Awake ()
        {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
        }
    public bool CheckBand ()
        {
        Debug.Log("Going to show");

        if (string.IsNullOrEmpty(_gameController.bandName))
            {
            Debug.LogWarning("Your band has no name!");
            return false;
            }

        if (_gameController.GetBand().Count <= 0)
            {
            Debug.LogWarning("Your band has no members!");
            return false;
            }
        return true;
        }

    public void LoadBandManagement()
        {
        _gameController.LoadScene("Band Management");
        }

    public void LoadEncounter1()
        {
        if (CheckBand())
            {
            Encounter encounter = new Encounter("Cat with two hands", EncounterType.Performance, 100, (5f/60f));
            _gameController.SetCurrentEncounter(encounter);
            _gameController.LoadScene("Encounter");
            }
        }

    public void LoadEncounter2()
        {
        if (CheckBand())
            {
            Encounter encounter = new Encounter("Dunedin Stadium", EncounterType.Performance, 100, (5f/60f));
            _gameController.SetCurrentEncounter(encounter);
            _gameController.LoadScene("Encounter");
            }
        }

    public void LoadEncounter3()
        {
        if (CheckBand())
            {
            Encounter encounter = new Encounter("Spaaaaace", EncounterType.Performance, 100, (5f/60f));
            _gameController.SetCurrentEncounter(encounter);
            _gameController.LoadScene("Encounter");
            }
        }

    public void InstaBand()
        {
        _gameController.AddMusician(new Musician("Bento", new Instrument(InstrumentType.Guitar), Resources.Load<Sprite>("Sprites/Portraits/portrait1")));
        _gameController.AddMusician(new Musician("Bort", new Instrument(InstrumentType.Piano), Resources.Load<Sprite>("Sprites/Portraits/portrait2")));
        _gameController.AddMusician(new Musician("Bbbbb", new Instrument(InstrumentType.Drum), Resources.Load<Sprite>("Sprites/Portraits/portrait3")));
        _gameController.AddMusician(new Musician("Boson", new Instrument(InstrumentType.Bass), Resources.Load<Sprite>("Sprites/Portraits/portrait4")));
        _gameController.bandName = "The Scoobies";
        }
    }
