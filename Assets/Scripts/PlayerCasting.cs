using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour
{
    private Camera _mainCamera;
    private Vector3 _mousePosition;

    [SerializeField] private GameObject caster; // from where we will cast spells

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera")
            .GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        _mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

        var diff = _mousePosition - caster.transform.position;
        var rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        
        caster.transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
    }
}
