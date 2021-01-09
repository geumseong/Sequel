using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    //public Canvas hud;
    public Text text;
    static State currentState;
    public static StateManager Instance;

    enum State
    {
        START,
        INGAME,
        END
    }

    void Start()
    {
        Instance = this;
        SwitchState(State.START);
        DontDestroyOnLoad(this.gameObject);
        //text.text = "";
    }
    private void SwitchState(State s)
    {
        currentState = s;
        switch (currentState)
        {
            case State.START:
                //todo: intro
                SwitchState(State.INGAME);
                break;
            case State.INGAME:
                Time.timeScale = 1;
                //hud.gameObject.SetActive(false);
                break;
            case State.END:
                Time.timeScale = 0;
                //hud.gameObject.SetActive(true);
                break;
        }
    }

    public void Loss()
    {
        SwitchState(State.END);
        text.text = "You lose!";
        CameraMovement.cam.GameOverCamera();
    }

    public void Victory()
    {
        Debug.Log("victory!");
        SwitchState(State.END);
        text.text = "You win!";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void ResumeGame()
    { SwitchState(State.INGAME); }
    public void Pause()
    { SwitchState(State.END); }
}
