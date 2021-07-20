using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Resume() {
        print("Resuming");
        SceneManager.LoadScene("Main");
    }

    public void Restart() {
        print("Restarting");
        SceneManager.LoadScene("Main");
    }

    public void Quit() {
        print("Quitting");
        Application.Quit();
    }
}
