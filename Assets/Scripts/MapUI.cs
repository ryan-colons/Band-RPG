using UnityEngine;
using UnityEngine.SceneManagement;

public class MapUI : MonoBehaviour
    {

    [SerializeField]
    private GameController gameController;

    public void GoToJam ()
        {
        Debug.Log("Going to jam");
        Encounter encounter = new Encounter("GIG 1", EncounterType.Performance, 100);
        gameController.SetCurrentEncounter(encounter);
        SceneManager.LoadScene(1);
        }
    }
