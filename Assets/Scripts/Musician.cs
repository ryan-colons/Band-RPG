using System.Collections.Generic;

public class Musician
    {

    public string Name { get; set; }
    public Instrument Instrument { get; set; }
    public MusicAction CurrentAction { get; set; }

    public Musician(string name, Instrument instrument)
        {  
        Name = name;
        Instrument = instrument;
        CurrentAction = InstrumentLibrary.InstrumentActions[Instrument.Type][0];
        }

    public List<MusicAction> GetMusicActions()
        {
        return InstrumentLibrary.InstrumentActions[Instrument.Type];
        }

    }