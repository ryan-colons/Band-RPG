using UnityEngine;
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
        _gameController.LoadScene(2);
        }

    public void LoadEncounter1()
        {
        if (CheckBand())
            {
            Encounter encounter = new Encounter("Cat with two hands", EncounterType.Performance, 100, (5f/60f));
            _gameController.SetCurrentEncounter(encounter);
            _gameController.LoadScene(1);
            }
        }

    public void LoadEncounter2()
        {
        if (CheckBand())
            {
            Encounter encounter = new Encounter("Dunedin Stadium", EncounterType.Performance, 100, (5f/60f));
            _gameController.SetCurrentEncounter(encounter);
            _gameController.LoadScene(1);
            }
        }

    public void LoadEncounter3()
        {
        if (CheckBand())
            {
            Encounter encounter = new Encounter("Spaaaaace", EncounterType.Performance, 100, (5f/60f));
            _gameController.SetCurrentEncounter(encounter);
            _gameController.LoadScene(1);
            }
        }
    }
