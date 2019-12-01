using UnityEngine;

public class Instrument {
    public InstrumentType Type { get; set; }
    public Sprite Sprite { get; private set; }

    public Instrument(InstrumentType type) 
        {
        Type = type;
        
        //I thought about doing this in one line using the InstrumentType as a string in the file name, but decided that was somehow bad?
        switch(type)
            {
            case InstrumentType.Guitar:
                Sprite = Resources.Load<Sprite>("Sprites/InstrumentIcons/Guitar");
                break;
            case InstrumentType.Piano:
                Sprite = Resources.Load<Sprite>($"Sprites/InstrumentIcons/Piano");
                break;
            case InstrumentType.Drum:
                Sprite = Resources.Load<Sprite>($"Sprites/InstrumentIcons/Drums");
                break;
            case InstrumentType.Bass:
                Sprite = Resources.Load<Sprite>($"Sprites/InstrumentIcons/Bass");
                break; 
            }
        
        }
}