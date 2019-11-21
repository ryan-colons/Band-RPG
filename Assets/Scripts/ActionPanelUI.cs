using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionPanelUI : MonoBehaviour
    {
    [SerializeField]
    private Button[] moveActionButtons;
    

        void Start()
            {
            this.gameObject.SetActive(false);
            GameController gameController = GameObject.Find("GameController").GetComponent<GameController>();
            //OpenPanel(gameController.GetBand()[0]);
            }

        public void OpenPanel(Musician musician)
            {
            this.gameObject.SetActive(true);


            for(int i = 0; i < moveActionButtons.Length; i++)
                {
                Button button = moveActionButtons[i];

                if(i >= musician.GetMusicActions().Count)
                    {
                    button.gameObject.SetActive(false);
                    break;
                    }
                button.gameObject.SetActive(true);

                MusicAction musicAction = musician.GetMusicActions()[i];

                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => moveBegin(musicAction));

                Text buttonText = button.transform.Find("Text").GetComponent<Text>();
                buttonText.text = $"{musicAction.Name} ({musicAction.RoundsToCooldown})";
                }
            }
        
        private void moveBegin(MusicAction musicAction)
            {
            Debug.Log(musicAction.Name);
            }
    }


