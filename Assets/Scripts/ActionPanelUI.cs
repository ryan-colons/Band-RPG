using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionPanelUI : MonoBehaviour
    {
    [SerializeField]
    private Button[] _moveActionButtons;
    [SerializeField]
    private EncounterUI _encounterUI;
    [SerializeField]
    private Text _musicianName;
        void Start()
            {
            this.gameObject.SetActive(false);
            GameController gameController = GameObject.Find("GameController").GetComponent<GameController>();
            }

        public void OpenPanel(Musician musician, BandMemberUI bandMemberUI)
            {
            this.gameObject.SetActive(true);


            for(int i = 0; i < _moveActionButtons.Length; i++)
                {
                Button button = _moveActionButtons[i];

                if(i >= musician.GetMusicActions().Count)
                    {
                    button.gameObject.SetActive(false);
                    break;
                    }
                button.gameObject.SetActive(true);

                MusicAction musicAction = musician.GetMusicActions()[i];


                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => moveBegin(musician, musicAction, bandMemberUI));

                Text buttonText = button.transform.Find("Text").GetComponent<Text>();
                buttonText.text = $"{musicAction.Name} ({musicAction.RoundsToCooldown})";

                _musicianName.text = musician.Name + "'s moves:";
                }
            }
        
        private void moveBegin(Musician musician, MusicAction musicAction, BandMemberUI bandMemberUI)
            {
            musician.CurrentAction = musicAction;
            bandMemberUI.UpdateAction();
            }
    }


