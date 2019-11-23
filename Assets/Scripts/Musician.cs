using System.Collections.Generic;
using UnityEngine;

public class Musician
    {
    static System.Random rnd = new System.Random();

    public string Name { get; set; }
    public Instrument Instrument { get; set; }
    public MusicAction CurrentAction { get; set; }
    public Sprite MusicianPortrait { get; set; }

    public Musician(string name, Instrument instrument)
        {  
        Name = name;
        Instrument = instrument;
        CurrentAction = InstrumentLibrary.InstrumentActions[Instrument.Type][0];

        Sprite[] portraits = Resources.LoadAll<Sprite>("Sprites/Portraits");
        MusicianPortrait = portraits[rnd.Next(portraits.Length)];
        }

    public List<MusicAction> GetMusicActions()
        {
        return InstrumentLibrary.InstrumentActions[Instrument.Type];
        }

    }