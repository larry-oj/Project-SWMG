using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour
{
    private Camera _mainCamera;
    private Vector3 _mousePosition;

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

        var diff = _mousePosition - transform.position;
        var rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
    }
}
