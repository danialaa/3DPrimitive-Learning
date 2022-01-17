using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimitiveController : MonoBehaviour
{
    float rotationSpeed = 6;

    private void OnMouseDrag()
    {
        if(Input.GetMouseButtonDown(1))
        {
            updatePrimitiveRotation();
        }
    }

    private Vector2 getDragAmount()
    {
        Vector2 dragAmount = new Vector2(Input.GetAxis("Mouse X") * rotationSpeed,
                                         Input.GetAxis("Mouse Y") * rotationSpeed);

        return dragAmount;
    }

    private void updatePrimitiveRotation()
    {
        Vector2 drag = getDragAmount();

        gameObject.transform.Rotate(Vector3.down, drag.x, Space.World);
        gameObject.transform.Rotate(Vector3.right, drag.y, Space.World);
    }
}
