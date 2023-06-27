using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour
{
    private Camera _mainCamera;
    private Vector3 _mousePosition;
    private GameObject _casterPointer; // from where we will cast spells

    [SerializeField] private GameObject caster;
    [SerializeField] private GameObject castObject;
    
    void Start()
    {
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera")
            .GetComponent<Camera>();
        _casterPointer = caster.transform.GetChild(0).gameObject;
    }
    
    void Update()
    {
        _mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

        var diff = _mousePosition - caster.transform.position;
        var rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        
        caster.transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
    }

    void OnFire()
    {
        Instantiate(castObject, _casterPointer.transform.position, caster.transform.rotation);
    }
}
