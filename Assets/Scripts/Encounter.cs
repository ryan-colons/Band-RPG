public class Encounter
    {
    private string _name;
    private EncounterType _type;
    private int _winThreshold, _loseThreshold = 0;

    public Encounter(string name, EncounterType type, int winThresh)
        {  
        Name = name;
        _type = type;
        WinThreshold = winThresh;
        }

    public string Name { get => _name; set => _name = value; }
    public EncounterType Type { get => _type; set => _type = value; }
    public int WinThreshold { get => _winThreshold; set => _winThreshold = value; }
    public int LoseThreshold { get => _loseThreshold; set => _loseThreshold = value; }
}

public enum EncounterType
    {
    Jam, Performance   
    }