using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void PlayButtonClicked()
    {
        Debug.Log("The Play button has been pressed! Switching to Main.");
        StateManager.Instance.RestartGame();
    }
    public void RestartButtonClicked()
    {
        Debug.Log("Restarting game");
        SceneManager.LoadScene(0);
    }
}
