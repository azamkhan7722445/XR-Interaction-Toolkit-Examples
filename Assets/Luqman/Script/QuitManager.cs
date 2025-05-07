using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    public void QuitGame()
    {
        // Quit the application
        Application.Quit();

        // Log a message for testing in the editor (this won't show in a built application)
        Debug.Log("Application Quit");
    }
}

