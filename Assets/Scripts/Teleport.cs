using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public GameObject start, end, player;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Liaam")
        {
            player.transform.position = end.transform.position;
        }
    }
}
