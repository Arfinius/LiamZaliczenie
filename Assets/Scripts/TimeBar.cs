using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{
    RawImage barRawImage;

    bool isEmptyMana = false;

    public TimeInMaail time;

    public Image imageTime;


    private void Awake()
    {
        barRawImage = transform.Find("barMask").Find("bar").GetComponent<RawImage>();
        time = new TimeInMaail();
    }

    private void FixedUpdate()
    {
        time.Update();
        ManaBarStabilization();
    }
    
    public void ManaBarStabilization()
    {
        Rect uvRect = barRawImage.uvRect;
        uvRect.x += .1f * Time.fixedDeltaTime;
        barRawImage.uvRect = uvRect;
        imageTime.fillAmount = time.GetNormalized();
    }

    public void TimeReducing()
    {
        time.TrySpendTime(0.25f);
    }


}

public class TimeInMaail
{
    public const int Time_Max = 100;

    public float timeAmount = 100;

    private float timeRegenAmount = 0;

    public void Update()
    {
        if (timeAmount > Time_Max)
        {
            timeAmount = Time_Max;
        }
        else
        {
            timeAmount += timeRegenAmount * Time.deltaTime;
        }
    }

    public void TrySpendTime(float amount)
    {
        if (timeAmount >= amount)
        {
            timeAmount -= amount;
        }
    }

    public float GetNormalized()
    {
        return timeAmount / Time_Max;
    }
}
