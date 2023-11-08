using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 250f;
    private Rigidbody rb;
    private Vector3 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        moveInput = new Vector3(horizontalInput, 0.0f, verticalInput).normalized;
    }
    private void FixedUpdate()
    {
        Vector3 moveAmount = moveInput * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount));

        float rotationAmount = Input.GetAxis("Horizontal") * turnSpeed * Time.fixedDeltaTime;
        Quaternion deltaRotation = Quaternion.Euler(Vector3.up * rotationAmount);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
