using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    public static AudioSource GunShot;

    public static void PlayGunshot(){
        GunShot.Play();
    }
}
