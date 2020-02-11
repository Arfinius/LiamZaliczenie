using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MigotanieSprites : MonoBehaviour
{
    SpriteRenderer SpRe;

    public float change;
    float m_Hue = 0;

    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        SpRe = GetComponent<SpriteRenderer>();
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        if (m_Hue >= 1)
            m_Hue = 0;
        m_Hue += change;
        if(SpRe == null)
        {
            image.color = Color.HSVToRGB(m_Hue, 1, 1);
        }
        else
            SpRe.color = Color.HSVToRGB(m_Hue, 1, 1);
    }


}
