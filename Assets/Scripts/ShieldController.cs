using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class ShieldController : MonoBehaviour
{


    public ParticleSystem shield, smallDrops, drops;
    public UnityEngine.Experimental.Rendering.Universal.Light2D []lighter;

    // Function responsible for switching on shield.
    public void Enable()
    {
        if (shield.isPlaying == false)
        {
            shield.Play();
            for(int i = 0; i < 8; i++)
            {
                lighter[i].enabled = true;
            }
            //lighter.enabled = true;
        }
        if (smallDrops.isPlaying == false)
        {
            smallDrops.Play();
        }
        if (drops.isPlaying == false)
        {
            drops.Play();
        }
    }

    // Function responsible for switching off shield.
    public void Disable()
    {
        if (shield.isPlaying == true)
        {
            shield.Stop();
            for (int i = 0; i < 8; i++)
            {
                lighter[i].enabled = false;
            }
            //lighter.enabled = false;
        }
        if (smallDrops.isPlaying == true)
        {
            smallDrops.Stop();
        }
        if (drops.isPlaying == true)
        {
            drops.Stop();
        }
    }

}
