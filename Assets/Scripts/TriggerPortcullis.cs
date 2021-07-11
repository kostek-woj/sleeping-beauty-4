using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPortcullis : MonoBehaviour
{
    [SerializeField] private Portcullis _portcullis;
    private Animator _portcullisLeverAnim = null;
    private AudioSource _leverSound;
    private bool _isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        _leverSound = GetComponent<AudioSource>();
        _portcullisLeverAnim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            if (!_isOpen) {
                print("Opening");
                _leverSound.Play();
                _portcullisLeverAnim.SetBool("isOpen", true);
                _portcullis.Open();
                _isOpen = true;
            } else {
                print("Closing");
                _leverSound.Play();
                _portcullisLeverAnim.SetBool("isOpen", false);
                _portcullis.Close();
                _isOpen = false;
            }
            
        }
    }

    
}
