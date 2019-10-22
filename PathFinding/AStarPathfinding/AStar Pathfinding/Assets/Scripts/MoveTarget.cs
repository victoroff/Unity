using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    public LayerMask hitLayers;
    void Update()
    {
        // if player left click
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouse = Input.mousePosition;
            
            //Cast a ray to get where the mouse position
            Ray castPoint = Camera.main.ScreenPointToRay(mouse);

            //Store the position where the ray hit.
            RaycastHit hit;
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity,hitLayers))
            {
                // Move the target to the mouse position
                this.transform.position = hit.point;
            }
        }
    }
}
