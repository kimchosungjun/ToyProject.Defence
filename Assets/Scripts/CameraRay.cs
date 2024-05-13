using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRay : MonoBehaviour
{
    public Camera mainCamera; 
    public LayerMask objectLayer; 

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        { 
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = mainCamera.ScreenPointToRay(mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, objectLayer))
            {
                Interaction interaction = hit.collider.GetComponent<Interaction>();
                interaction.SendObjectInfo(interaction.gameObject);
            }
        }
    }
}
