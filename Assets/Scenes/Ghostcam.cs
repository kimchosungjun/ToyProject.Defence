using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghostcam : MonoBehaviour
{
    Camera cam;
    [SerializeField] float moveSpeed;
    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Move();
        MouseMove();
    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.rotation * Vector3.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.rotation * Vector3.left * moveSpeed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.rotation * Vector3.back * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.rotation * Vector3.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += transform.rotation * Vector3.up * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.C))
        {
            transform.position += transform.rotation * Vector3.down * moveSpeed * Time.deltaTime;
        }
    }

    float mouseSensitive = 100f; // 마우스 감도
    Vector3 rotateValue;
    private void MouseMove()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitive * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitive * Time.deltaTime;

        rotateValue.x -= mouseY;
        rotateValue.y += mouseX;

        rotateValue.x = Mathf.Clamp(rotateValue.x, -45, 45);

        cam.transform.rotation = Quaternion.Euler(rotateValue);
    }
}
