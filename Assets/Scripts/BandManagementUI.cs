using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

public class BandManagementUI : MonoBehaviour
    {
    private GameController _gameController;
    [SerializeField]
    private BandMemberPanelUI[] _musicianPanels;
    [SerializeField]
    private InputField _bandNameField;

    public void ReturnToMap()
        {
        _gameController.bandName = _bandNameField.text;
        _gameController.LoadScene("Map");
        }

    public void Awake ()
        {
        GameObject gameControllerGameObject = GameObject.Find("GameController");
        if (gameControllerGameObject != null) _gameController = gameControllerGameObject.GetComponent<GameController>();
        }

    private void Start()
        {
        List<Musician> bandMembers = _gameController.GetBand();

        foreach(BandMemberPanelUI ui in _musicianPanels) 
            {
            ui.gameObject.SetActive(false);
            }

        for (int i = 0; i < bandMembers.Count && i < _musicianPanels.Length; i++) 
            {
            Musician currentMusician = bandMembers[i];
            _musicianPanels[i].gameObject.SetActive(true);
            _musicianPanels[i].SetMusician(currentMusician);
            }

        _bandNameField.text =_gameController.bandName;
        }
   
    }
