using UnityEngine;

public class Instrument {
    public InstrumentType Type { get; set; }
    public Sprite Sprite { get; private set; }

    public Instrument(InstrumentType type, Sprite sprite) 
        {
        Type = type;
        Sprite = sprite;
        }
}