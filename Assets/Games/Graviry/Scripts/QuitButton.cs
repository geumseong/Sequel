using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void QuitButtonClicked()
    {
        Debug.Log("The Quit button has been pressed! Game should quit.");
        StateManager.Instance.QuitGame();
    }
}
