using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portcullis : MonoBehaviour
{
    private Animator _animator = null;

    private void Awake() {
        _animator = GetComponent<Animator>();
    }

    public void Open() {
        _animator.SetBool("isOpen", true);
        //gameObject.SetActive(false);
    }

    public void Close() {
        _animator.SetBool("isOpen", false);
        //gameObject.SetActive(true);
    }
}
