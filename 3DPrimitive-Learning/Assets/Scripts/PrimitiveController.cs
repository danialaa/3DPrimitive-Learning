using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimitiveController : MonoBehaviour
{
    float rotationSpeed = 6;
    bool isDragging = false;

    private void Update()
    {
        if (Input.GetMouseButton(1))
            isDragging = true;
        else
            isDragging = false;

        if (isDragging)
            updatePrimitiveRotation();
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
