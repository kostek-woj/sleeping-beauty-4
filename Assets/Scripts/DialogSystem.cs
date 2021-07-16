using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] private Canvas _dialog;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Texture2D _cursorTexture;

    private CursorMode _cursorMode = CursorMode.Auto;
    private Vector2 _hotSpot = Vector2.zero;

    private Animator _animator;

    void Awake()
    {
        _dialog.enabled = false;
        _animator = GetComponent<Animator>();
    }

    public void Close() {
        _animator.SetTrigger("Close");
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.SetCursor(null, Vector2.zero, _cursorMode);
        _dialog.enabled = false;
    }

    public void Open(string text) {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.SetCursor(_cursorTexture, Vector2.zero, _cursorMode);
        _text.text = text;
        _dialog.enabled = true;
        _animator.SetTrigger("Open");
    }
}
