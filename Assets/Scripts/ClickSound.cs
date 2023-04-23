using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickSound : MonoBehaviour
{
    public AudioSource clickPlay;

    public void playThisSoundEffect()
    {
        clickPlay.Play();
    }
}
