using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inv;
    public GameObject itemButton;

    void Start()
    {
        inv = GameObject.FindGameObjectWithTag("Liaam").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Liaam"))
        {
            if (inv.isFull == false)
            {
                inv.isFull = true;
                Instantiate(itemButton, inv.slot.transform);
                Destroy(gameObject);
            }
        }
    }
}
