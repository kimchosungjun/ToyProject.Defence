using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Transform tf;
    public float size;
    public void Awake()
    {
        tf = GetComponent<Transform>();
        SetSize();
    }


    public void SetSize()
    {
        tf.localScale = new Vector3(size, size, size);
    }
}
