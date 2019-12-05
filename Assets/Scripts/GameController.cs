using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
    {
    private Encounter _currentEncounter;
    private List<Musician> _band;
    public string bandName { get; set; }

    // ensure only one GameController ever exists
    private static GameController _theOnlyGameController;

    private void Awake()
        {
        if (_theOnlyGameController != null && _theOnlyGameController != this)
            {
            Destroy(this.gameObject);
            }
        else
            {
            _theOnlyGameController = this;
            DontDestroyOnLoad(this.gameObject);
            _band = new List<Musician>();
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
        if (_band == null) _band = new List<Musician>();
        _band.Add(musician);
        }
    public void RemoveMusician(Musician musician)
        {
        if (_band == null) _band = new List<Musician>();
        else _band.Remove(musician);
        }
    public List<Musician> GetBand() 
        {
        if (_band == null) _band = new List<Musician>();
        return _band;
        }

    public void LoadScene(string sceneName) 
        {
        SceneManager.LoadScene(sceneName);
        }


    }