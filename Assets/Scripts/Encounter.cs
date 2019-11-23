using System.Collections;
using UnityEngine;

public class Encounter
    {
    public string Name { get; set; }
    public EncounterType Type { get; set; }
    public int WinThreshold { get; set; }
    public int LoseThreshold { get; set; }
    public int HypeResistance { get; set; }
    private GameController _gameController;
    public int currentHypeValue = 50;

    public Encounter(string name, EncounterType type, int winThresh, int hypeResistance)
        {  
        Name = name;
        Type = type;
        WinThreshold = winThresh;
        LoseThreshold = 0;
        HypeResistance = hypeResistance;
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
        }

    public void TimeStep()
        {
        currentHypeValue = currentHypeValue + GetCurrentBandValue() - HypeResistance;
        
        if (currentHypeValue <= LoseThreshold)
            {
            EncounterEnd(0);
            }

        if (currentHypeValue >= WinThreshold)
            {
            EncounterEnd(1);
            } 
        }

    public void EncounterEnd(int successState)
        {
        if (successState == 1)
            {
            Debug.Log($"Woohoo, we love {_gameController.bandName}! We're maximally hyped!");
            }
        
        if (successState == 0)
            {
            Debug.Log($"{_gameController.bandName}? Never heard of them!");
            }
        }

    public int GetCurrentBandValue()
        {
        int currentBandValue = 0;
        foreach(Musician musician in _gameController.GetBand())
            {
            currentBandValue = currentBandValue + musician.CurrentAction.Power;
            }
        return currentBandValue;
        }
    }

