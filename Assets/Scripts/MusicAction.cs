using UnityEngine;
public class MusicAction
    {
    public string Name { get; set; }
    public int Power { get; set; }
    public int RoundsToCooldown { get; set; }
    public AudioClip AudioClip { get; set; } 
    public MusicAction(string name, int power, int cooldown, string audioClipName)
        {  
        Name = name;
        Power = power;
        RoundsToCooldown = cooldown;
        if (!string.IsNullOrEmpty(audioClipName))
            {
            AudioClip = (AudioClip) Resources.Load($"InstrumentSounds/{audioClipName}");
            }
        }
    }