using System.Collections.Generic;

public class InstrumentLibrary {

    public static Dictionary<InstrumentType, List<MusicAction>> InstrumentActions = new Dictionary<InstrumentType, List<MusicAction>>{
        {
        InstrumentType.Guitar,
        new List<MusicAction>
            {
            new MusicAction("Tacet", 0, 0, ""),
            new MusicAction("Strum", 10, 1, "guitar1"),
            new MusicAction("Shred", 20, 2, "guitar2"),
            new MusicAction("The Secret Third Option", 20, 2, "guitar3"),
            }
        },
        {
       InstrumentType.Piano,
        new List<MusicAction>   
            {
            new MusicAction("Tacet", 0, 0, ""),
            new MusicAction("Glissando", 20, 3, "piano1"),
            new MusicAction("Comp", 5, 1, "piano2"),
            new MusicAction("Trill", 20, 2, "piano3"),
            }
        },
        {
      InstrumentType.Drum,
        new List<MusicAction>
            {
            new MusicAction("Tacet", 0, 0, ""),
            new MusicAction("Backbeat", 20, 2, "drums1"),
            new MusicAction("Crash", 10, 1, "drums2"),
            new MusicAction("Paradiddle", 15, 2, "drums3"),
            }
        },
        {
        InstrumentType.Bass,
        new List<MusicAction>
            {
            new MusicAction("Tacet", 0, 0, ""),
            new MusicAction("Pedal Note", 20, 2, "bass1"),
            new MusicAction("Walking Bass", 10, 1, "bass2"),
            new MusicAction("Slap", 15, 2, "bass3"),
            }
        }    
    };  

}