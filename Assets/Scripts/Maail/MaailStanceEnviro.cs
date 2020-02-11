using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaailStanceEnviro : MonoBehaviour
{
    SwitchCharacterScript switchChar;
    public GameObject floor;
    // Start is called before the first frame update
    void Start()
    {
        switchChar = FindObjectOfType<SwitchCharacterScript>().GetComponent<SwitchCharacterScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
