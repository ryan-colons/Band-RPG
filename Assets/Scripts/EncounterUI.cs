using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EncounterUI : MonoBehaviour
{
    [SerializeField]
    private Text _encounterNameText;
    private GameController _gameController;

    public void Awake ()
        {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
        }

    public void Start ()
        {
        SetEncounterNameText(_gameController.GetCurrentEncounter().Name);
        }

    public void SetEncounterNameText (string name) 
        {
        _encounterNameText.text = name;
        }

}
