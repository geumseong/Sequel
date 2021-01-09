using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneloader : MonoBehaviour
{
    public static int hate;
    public int scene;
    public static bool goalreached;
    public static Sceneloader scenechange;

    void Start()
    {
        hate = scene;
        goalreached = false;
    }
    private void Update()
    {
        if (goalreached == true)
        {
            Scenechange();
        }
    }
    public void Scenechange()
    {
        SceneManager.LoadScene(scene);
    }
}
