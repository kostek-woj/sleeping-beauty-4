using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLayMine : MonoBehaviour
{
    [SerializeField] private GameObject _mine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerToggleMenu.menuOpened && Input.GetMouseButtonDown(1)) {
            Instantiate(_mine, new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z), Quaternion.identity);
        }
    }
}
