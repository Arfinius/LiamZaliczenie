using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjects : MonoBehaviour
{
    [SerializeField]
    private Material highlightMaterial;
    [SerializeField]
    private Material defaultMaterial;

    [SerializeField]
    private string selectableTag = "Draggable";


    private Transform _selection;
    public bool drag = false;

    void Update()
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

        if (hit.collider != null)
        {

            if(hit.collider.tag == "Draggable")
            {
                drag = true;
                Debug.Log(hit.collider.name);
            }
            else
            {
                drag = false;
            }

        }

        Debug.Log("drag = " + drag);
    }
}
