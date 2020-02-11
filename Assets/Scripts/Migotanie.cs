using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Migotanie : MonoBehaviour
{
    SpriteRenderer SpRe;

    [SerializeField]
    private Tilemap tilemap;

    public float change;
    float m_Hue = 0;

    // Start is called before the first frame update
    void Start()
    {
        SpRe = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Hue >= 1)
            m_Hue = 0;
        m_Hue += change;

        //SpRe.color = Color.HSVToRGB(m_Hue, 1, 1);
        tilemap.color = Color.HSVToRGB(m_Hue, 1, 1);
    }

    
}
