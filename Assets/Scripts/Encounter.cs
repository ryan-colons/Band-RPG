public class Encounter
    {
    public Encounter(string name, EncounterType type, int winThresh)
        {  
        Name = name;
        Type = type;
        WinThreshold = winThresh;
        LoseThreshold = 0;
        }

    public string Name { get; set; }
    public EncounterType Type { get; set; }
    public int WinThreshold { get; set; }
    public int LoseThreshold { get; set; }
}

