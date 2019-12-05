using System.Collections.Generic;
using UnityEngine;

public class MusicianCreationHelper
    {

    private static System.Random _random = new System.Random();
    private static List<string> _namesList = new List<string>
        {"Bronklyn", "Bradio", "Bricks", "Brizzel", "Bornagain", 
        "Breakslow", "Beelzebabe", "Binnards", "Bungheap", "Bardsworth", 
        "Banhomer", "Billboar", "Buggins", "Beethoven"};
    private static List<Sprite> _playerSprites = new List<Sprite>(Resources.LoadAll<Sprite>("Sprites/Portraits"));

    public static string GetRandomName ()
        {
        return _namesList[_random.Next(_namesList.Count)];
        }
    
    public static List<Sprite> GetAllSprites ()
        {
        // return a new list so that playerSprites doesn't accidentally get altered anywhere
        return new List<Sprite>(Resources.LoadAll<Sprite>("Sprites/Portraits"));
        }

    public static Sprite GetRandomSprite ()
        {
        return _playerSprites[_random.Next(_playerSprites.Count)];
        }

    public static Instrument GetRandomInstrument()
        {
        Instrument instrument = new Instrument((InstrumentType)_random.Next(System.Enum.GetNames(typeof(InstrumentType)).Length));
        return instrument;
        }
    }