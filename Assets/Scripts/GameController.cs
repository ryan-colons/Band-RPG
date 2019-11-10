using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
    {

    private Encounter _currentEncounter;

    public Encounter GetCurrentEncounter()
        {
        return _currentEncounter;
        }

    public void SetCurrentEncounter(Encounter encounter)
        {
        _currentEncounter = encounter;
        }

    public void Awake()
        {
        DontDestroyOnLoad(this.gameObject);
        }

    
    }