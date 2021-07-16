using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerToggleMenu : MonoBehaviour
{
    public static bool menuOpened = false;

    [SerializeField] private Canvas _menu;
    [SerializeField] private Texture2D _cursorTexture;
    
    private CursorMode _cursorMode = CursorMode.Auto;
    private Vector2 _hotSpot = Vector2.zero;

    // Start is called before the first frame update
    void Awake()
    {
        _menu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (menuOpened) {
                print("Menu closed");
                Resume();
            } else {
                print("Menu opened");
                ShowMenu();
            }
        }
    }

    private void ShowMenu() {
        _menu.enabled = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.SetCursor(_cursorTexture, Vector2.zero, _cursorMode);
        menuOpened = true;
    }

    public void Resume() {
        print("Resuming");
        _menu.enabled = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.SetCursor(null, Vector2.zero, _cursorMode);
        menuOpened = false;
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
