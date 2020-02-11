using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectItem : MonoBehaviour
{

    public int SelectedItem = 0;

    public RectTransform[] zrekcilemCie;

    public RectTransform activeSlot;

    public bool meleAtackActive = false;
    public bool BowAtackActive =false;
    public bool RegenActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectedItem = 0;
            meleAtackActive = true;
            BowAtackActive = false;
            RegenActive = false;

}
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectedItem = 1;
            meleAtackActive = false;
            BowAtackActive = true;
            RegenActive = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectedItem = 2;
            meleAtackActive = false;
            BowAtackActive = false;
            RegenActive = true;
        }

        if(SelectedItem == 0)
        {
            meleAtackActive = true;
            BowAtackActive = false;
            RegenActive = false;
        }
        if (SelectedItem == 1)
        {
            meleAtackActive = false;
            BowAtackActive = true;
            RegenActive = false;
        }
        if (SelectedItem == 2)
        {
            meleAtackActive = false;
            BowAtackActive = false;
            RegenActive = true;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (SelectedItem >= transform.childCount - 2)
                SelectedItem = 0;
            else
                SelectedItem++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (SelectedItem <= 0)
                SelectedItem = transform.childCount - 2;
            else
                SelectedItem--;
        }

        activeSlot.anchoredPosition = zrekcilemCie[SelectedItem].anchoredPosition;
    }

    void SelectItemInv()
    {
        int i = 0;
        foreach(Transform item in transform)
        {
            if (i == SelectedItem)
                item.gameObject.SetActive(true);
            else
                item.gameObject.SetActive(false);
            i++;

        }
    }
}
