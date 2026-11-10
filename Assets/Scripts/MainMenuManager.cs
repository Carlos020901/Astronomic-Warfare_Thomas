using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartButton()
    {
        SceneManager.LoadScene("Galaxy");
    }

    public void RetryButton()
    {
        SceneManager.LoadScene("Galaxy");
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }

    public void GoBackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
