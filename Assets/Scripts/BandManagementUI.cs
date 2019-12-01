using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

public class BandManagementUI : MonoBehaviour
    {
    private GameController _gameController;
    [SerializeField]
    private BandMemberPanelUI[] musicianPanels;
    
    public void ReturnToMap()
        {
        _gameController.LoadScene(0);
        }

    public void Awake ()
        {
        GameObject gameControllerGameObject = GameObject.Find("GameController");
        if (gameControllerGameObject != null) _gameController = gameControllerGameObject.GetComponent<GameController>();
        }

    private void Start()
        {
        List<Musician> bandMembers = _gameController.GetBand();

        foreach(BandMemberPanelUI ui in musicianPanels) 
            {
            ui.gameObject.SetActive(false);
            }

        for (int i = 0; i < bandMembers.Count && i < musicianPanels.Length; i++) 
            {
            Musician currentMusician = bandMembers[i];
            musicianPanels[i].gameObject.SetActive(true);
            musicianPanels[i].SetMusician(currentMusician);
            }
        }
   
    }
