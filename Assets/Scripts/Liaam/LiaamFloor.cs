using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiaamFloor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Maail")
        {
            Debug.Log("Maail is Dead");
        }
    }
}
