using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
    {
    static System.Random rnd = new System.Random();
    private Encounter _currentEncounter;
    private List<Musician> band;
    public string bandName { get; set; }

    // ensure only one GameController ever exists
    private static GameController theOnlyGameController;
    private List<Sprite> playerSprites;

    private void Start ()
        {
        playerSprites = new List<Sprite>(Resources.LoadAll<Sprite>("Sprites/Portraits"));
        }

    private void Awake()
        {
        if (theOnlyGameController != null && theOnlyGameController != this)
            {
            Destroy(this.gameObject);
            }
        else
            {
            theOnlyGameController = this;
            DontDestroyOnLoad(this.gameObject);
            band = new List<Musician>();
            }
        }

    public Encounter GetCurrentEncounter()
        {
        return _currentEncounter;
        }

    public void SetCurrentEncounter(Encounter encounter)
        {
        _currentEncounter = encounter;
        }


    public void AddMusician(Musician musician) 
        {
        if (band == null) band = new List<Musician>();
        band.Add(musician);
        }
    public void RemoveMusician(Musician musician)
        {
        if (band == null) band = new List<Musician>();
        else band.Remove(musician);
        }
    public List<Musician> GetBand() 
        {
        if (band == null) band = new List<Musician>();
        return band;
        }

    public void LoadScene(string sceneName) 
        {
        SceneManager.LoadScene(sceneName);
        }

    public string GetRandomName ()
        {
        List<string> namesList = new List<string>{"Bronklyn", "Bradio", "Bricks", "Brizzel", "Bornagain", 
                                        "Breakslow", "Beelzebabe", "Binnards", "Bungheap", "Bardsworth", 
                                        "Banhomer", "Billboar", "Buggins", "Beethoven"};
        return namesList[rnd.Next(namesList.Count)];
        }
    
    public Sprite GetRandomSprite ()
        {
        return playerSprites[rnd.Next(playerSprites.Count)];
        }

    public Instrument GetRandomInstrument()
        {
        Instrument instrument = new Instrument((InstrumentType)rnd.Next(System.Enum.GetNames(typeof(InstrumentType)).Length));
        return instrument;
        }
    }