using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowsFlask : MonoBehaviour
{
    [Header("Projectile")]
    [SerializeField] private GameObject _spell = null;
    [SerializeField] private float _throwingForce;
    [SerializeField] private float _upwardForce;

    [Header("Weapon Stats")]
    [SerializeField] private float _timeBetweenCasting;
    [SerializeField] private float _spread;
    [SerializeField] private float _timeBetweenCasts;
    [SerializeField] private bool _isButtonHoldingAllowed;

    [Header("Reference")]
    [SerializeField] private Camera _cam;
    [SerializeField] private Transform _throwingPoint;

    private bool _casting;

    // for bug fixing
    [SerializeField] private bool _allowInvoke = true;

    private void Update() {
        PlayerThrows();
    }

    private void PlayerThrows() {
        if (_isButtonHoldingAllowed) {
            _casting = Input.GetKey(KeyCode.F);
        } else {
            _casting = Input.GetKeyDown(KeyCode.F);
        }

        if (_casting) {
            ThrowFlask();
        }
    }

    private void ThrowFlask() {
        Ray ray = _cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit)) {
            targetPoint = hit.point;
        } else {
            targetPoint = ray.GetPoint(100);
        }

        Vector3 directionWithoutSpread = targetPoint - _throwingPoint.position;

        float spreadX = Random.Range(-_spread, _spread);
        float spreadY = Random.Range(-_spread, _spread);

        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(spreadX, spreadY, 0);

        GameObject currentSpell = Instantiate(_spell, _throwingPoint.position, Quaternion.identity);

        currentSpell.transform.forward = directionWithSpread;
        currentSpell.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * _throwingForce, ForceMode.Impulse);

        if (_allowInvoke) {
            Invoke("ResetThrow", _timeBetweenCasts);
            _allowInvoke = false;
        }

    }

    private void ResetThrow() {
        _allowInvoke = true;
    }

}
