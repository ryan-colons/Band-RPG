using System.Collections;
using UnityEngine;

public class Encounter
    {
    public string Name { get; set; }
    public EncounterType Type { get; set; }
    public float WinThreshold { get; set; }
    public float LoseThreshold { get; set; }
    public float HypeResistance { get; set; }
    private GameController _gameController;
    public float currentHypeValue = 50f;
    private const float _timeStepLength = 0.1f;
    private float _bandValueCoefficient;

    public Encounter(string name, EncounterType type, float winThresh, float hypeResistance)
        {  
        Name = name;
        Type = type;
        WinThreshold = winThresh;
        LoseThreshold = 0f;
        HypeResistance = hypeResistance;
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
        _bandValueCoefficient = BandValueCoefficientConstant();
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
            AddRandomMusician();
            _gameController.LoadScene("Map");
            }
        
        if (successState == 0)
            {
            Debug.Log($"{_gameController.bandName}? Never heard of them!");
            _gameController.LoadScene("Map");
            }
        }

    public float GetCurrentBandValue()
        {
        float currentBandValue = 0f;
        foreach(Musician musician in _gameController.GetBand())
            {
            currentBandValue = currentBandValue + musician.CurrentAction.Power;
            }
        currentBandValue /= _gameController.GetBand().Count;
        currentBandValue /= _bandValueCoefficient;
        return currentBandValue;
        }

    public float GetTimeStepLength()
        {
        return _timeStepLength;
        }

    private float BandValueCoefficientConstant()
        {
        float standardEncounterSeconds = 60f;
        float standardEncounterSteps = standardEncounterSeconds/_timeStepLength;
        float baselineHypeChange = 50f / standardEncounterSteps;
        // 3 because the best/worst case scenario should be to win/lose in 1/3 of the standard encounter time
        float maxBandValue = 3 * baselineHypeChange;
        // 20 = arbitrary scale for move powers
        float maxMovePower = 20;
        return maxMovePower / maxBandValue;
        }

    private void AddRandomMusician()
        {
        Musician musician = new Musician(MusicianCreationHelper.GetRandomName(), MusicianCreationHelper.GetRandomInstrument(), MusicianCreationHelper.GetRandomSprite());
        _gameController.AddMusician(musician); 
        }
    }

