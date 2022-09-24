using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float RotationSpeed = 150;
    void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxisRaw("Mouse X");
            transform.Rotate(0, -mouseX * RotationSpeed * Time.deltaTime, 0);
        }
    }
}
