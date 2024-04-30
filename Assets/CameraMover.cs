using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    void Update()
    {
        // Z√‡
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += Vector3.forward;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += Vector3.back;
        }
        // X√‡
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += Vector3.right;
        }
        // Y√‡
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            transform.position += Vector3.up;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            transform.position += Vector3.down;
        }
    }
}
