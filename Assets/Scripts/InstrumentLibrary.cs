using System.Collections.Generic;

public class InstrumentLibrary {

    public static Dictionary<InstrumentType, List<MusicAction>> InstrumentActions = new Dictionary<InstrumentType, List<MusicAction>>{
        {
        InstrumentType.Guitar,
        new List<MusicAction>
            {
            new MusicAction("Strum", 10, 1),
            new MusicAction("Shred", 20, 2),
            new MusicAction("The Secret Third Option", 20, 2),
            }
        },
        {
       InstrumentType.Piano,
        new List<MusicAction>   
            {
            new MusicAction("Glissando", 30, 3),
            new MusicAction("Comp", 5, 1),
            }
        },
        {
      InstrumentType.Drum,
        new List<MusicAction>
            {
            new MusicAction("Backbeat", 20, 2),
            new MusicAction("Crash", 10, 1),
            }
        },
    };

}