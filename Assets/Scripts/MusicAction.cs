public class MusicAction
    {
    public string Name { get; set; }
    public int Power { get; set; }
    public int RoundsToCooldown { get; set; }

    public MusicAction(string name, int power, int cooldown)
        {  
        Name = name;
        Power = power;
        RoundsToCooldown = cooldown;
        }
    }