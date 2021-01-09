using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    public void ResumeButtonClicked()
    {
        Debug.Log("Resume");
        StateManager.Instance.ResumeGame();
    }
}
