using System.Collections.Generic;

public class Musician
    {

    public string Name { get; set; }
    public Instrument Instrument { get; set; }

    public Musician(string name, Instrument instrument)
        {  
        Name = name;
        Instrument = instrument;
        }

    public List<MusicAction> GetMusicActions()
        {
        return InstrumentLibrary.InstrumentActions[Instrument.Type];
        }

    }