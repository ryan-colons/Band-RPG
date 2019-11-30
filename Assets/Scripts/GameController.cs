using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
    {

    private Encounter _currentEncounter;
    private List<Musician> band;
    public string bandName { get; set; }

    // ensure only one GameController ever exists
    private static GameController theOnlyGameController;
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

    public void LoadScene(int sceneIndex) 
        {
        SceneManager.LoadScene(1);
        }
    
    }