using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    DragObjects dragObjects;

    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
        dragObjects = FindObjectOfType<DragObjects>().GetComponent<DragObjects>();
        Time.timeScale = 0f;
    }

    private void OnMouseUp()
    {
        Time.timeScale = 1f;
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        if (dragObjects.drag)
            transform.position = GetMouseWorldPos() + mOffset;
    }
}
