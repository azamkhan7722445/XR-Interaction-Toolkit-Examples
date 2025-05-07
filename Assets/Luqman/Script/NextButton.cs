using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonNextScene : MonoBehaviour
{
    public void LoadNextScene()
    {
        // Load the scene named "LevelScene"
        SceneManager.LoadScene("Toilet");
    }
}
