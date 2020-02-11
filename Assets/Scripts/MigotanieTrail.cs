using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MigotanieTrail : MonoBehaviour
{
    TrailRenderer Trail;

    public float change;
    float m_Hue = 0;

    public

    // Start is called before the first frame update
    void Start()
    {
        Trail = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Hue >= 1)
            m_Hue = 0;
        m_Hue += change;

        //Trail.startColor = 
    }


}