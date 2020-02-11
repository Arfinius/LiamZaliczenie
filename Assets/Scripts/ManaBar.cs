using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour {
    
    RawImage barRawImage;

    [HideInInspector]
    public bool isEmptyMana = false; 

    public Mana mana;

    public Image imageMana;

    private void Awake()
    {
        barRawImage = transform.Find("barMask").Find("bar").GetComponent<RawImage>();
        mana = new Mana();
    }

    private void FixedUpdate()
    {
        mana.Update();
        ManaBarStabilization();

    }

    // Function responsible for turning on shield, depending on mana.
    public void ShieldWhenS()
    {
        mana.TrySpendMana(1f);

    }

    public void ManaBarStabilization()
    {
        Rect uvRect = barRawImage.uvRect;
        uvRect.x += .1f * Time.fixedDeltaTime;
        barRawImage.uvRect = uvRect;
        imageMana.fillAmount = mana.GetNormalized();
    }
}

public class Mana
{
    public const int Mana_Max = 100;

    public float manaAmount = 100;

    private float manaRegenAmount = 10;

    public void Update()
    {
        if (manaAmount > Mana_Max)
        {
            manaAmount = Mana_Max;
        }
        else
        {
            manaAmount += manaRegenAmount * Time.deltaTime;
        }
    }

    public void TrySpendMana(float amount)
    {
        if (manaAmount >= amount)
        {
            manaAmount -= amount;
        }
    }

    public float GetNormalized()
    {
        return manaAmount / Mana_Max;
    }
}
