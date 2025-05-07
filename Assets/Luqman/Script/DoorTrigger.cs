using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorTrigger : MonoBehaviour
{
    public GameObject noticePanel; // The UI panel with the confirmation message
    public Button yesButton; // Button for "Yes"
    public Button noButton; // Button for "No"

    private bool noticeActive = false;

    void Start()
    {
        if (noticePanel != null)
            noticePanel.SetActive(false); // Ensure the panel is hidden at the start

        if (yesButton != null)
            yesButton.onClick.AddListener(OnYesButtonClick);

        if (noButton != null)
            noButton.onClick.AddListener(OnNoButtonClick);
    }

    public void OnDoorClicked()
    {
        if (!noticeActive)
        {
            ShowNotice();
        }
    }

    void ShowNotice()
    {
        if (noticePanel != null)
        {
            noticePanel.SetActive(true);
            noticeActive = true;
        }
    }

    void HideNotice()
    {
        if (noticePanel != null)
        {
            noticePanel.SetActive(false);
            noticeActive = false;
        }
    }

    void OnYesButtonClick()
    {
        if (noticeActive)
        {
            LoadNextLevel();
        }
    }

    void OnNoButtonClick()
    {
        if (noticeActive)
        {
            HideNotice();
        }
    }

    void LoadNextLevel()
    {
        // Load the next scene in the build settings
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
