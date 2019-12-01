using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

public class MapUI : MonoBehaviour
    {
    private GameController _gameController;

    public void Awake ()
        {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
        }
    public bool CheckBand ()
        {
        Debug.Log("Going to show");

        if (string.IsNullOrEmpty(_gameController.bandName))
            {
            Debug.LogWarning("Your band has no name!");
            return false;
            }

        if (_gameController.GetBand().Count <= 0)
            {
            Debug.LogWarning("Your band has no members!");
            return false;
            }
        return true;
        }

    public void LoadBandManagement()
        {

        }
    
    public void RandomMember ()
        {
        string name = namesList[rnd.Next(namesList.Count)];
        if(_musoNameInput.text == name)
            {
            //I tried to get this to reroll if it's the same name, but I can't think of a tidy way to do it!
            }
        _musoNameInput.text = name;

        _musicianToggles.SetAllTogglesOff();
        _instrumentToggles[rnd.Next(_instrumentToggles.Length)].isOn = true;
        }  

    public void UpdateBandList()
        {
        foreach(MapBandListUI ui in bandListEntries) 
            {
            ui.ClearEntry();
            }

        List<Musician> bandMembers = _gameController.GetBand();

        for (int i = 0; i < bandMembers.Count; i++) 
            {
            bandListEntries[i].SetMusician(bandMembers[i]);
            }
        }

   
    }
