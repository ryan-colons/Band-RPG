using System.Collections.Generic;
using UnityEngine;

public class MusicianCreationHelper
    {

    private static System.Random random = new System.Random();
    private static List<string> namesList = new List<string>
        {"Bronklyn", "Bradio", "Bricks", "Brizzel", "Bornagain", 
        "Breakslow", "Beelzebabe", "Binnards", "Bungheap", "Bardsworth", 
        "Banhomer", "Billboar", "Buggins", "Beethoven"};
    private static List<Sprite> playerSprites = new List<Sprite>(Resources.LoadAll<Sprite>("Sprites/Portraits"));

    public static string GetRandomName ()
        {
        
        return namesList[random.Next(namesList.Count)];
        }
    
    public static Sprite GetRandomSprite ()
        {
        return playerSprites[random.Next(playerSprites.Count)];
        }

    public static Instrument GetRandomInstrument()
        {
        Instrument instrument = new Instrument((InstrumentType)random.Next(System.Enum.GetNames(typeof(InstrumentType)).Length));
        return instrument;
        }
    }