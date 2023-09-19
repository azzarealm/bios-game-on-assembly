using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float sensitivity = 5.0f;

    private Rigidbody rb;
    private Camera cam;
    private float moveFB;
    private float moveLR;
    private float rrX;
    private float rrY;
    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        moveFB = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        moveLR = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        rrX = Input.GetAxis("Mouse X") * sensitivity;
        rrY -= Input.GetAxis("Mouse Y") * sensitivity;
        rrY = Mathf.Clamp(rrY, -60f, 60f);
        movement = new Vector3(moveLR, 0, moveFB);
        movement = transform.rotation * movement;
        transform.Translate(movement, Space.World);
        transform.Rotate(0, rrY, 0);
        cam.transform.localRotation = Quaternion.Euler(rrY, 0, 0);
    }
}