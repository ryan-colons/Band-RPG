using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
    {

    private Encounter _currentEncounter;
    private List<Musician> band;

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
        band = new List<Musician>();
        }

    public void AddMusician(Musician musician) 
        {
        band.Add(musician);
        }

    public List<Musician> GetBand() 
        {
        return band;
        }

    
    }