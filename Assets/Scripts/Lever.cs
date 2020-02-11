using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject door;

    private void Start()
    {
        Vector2 moveDoor = new Vector2(0, 3f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Maail")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Otwarte");
                door.transform.position += Vector3.up *3f ;
            }
        }
    }
}
