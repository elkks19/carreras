using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFX : MonoBehaviour
{
    public AudioClip[]fxs;
    AudioSource audio5;
    void Start()
    {
        audio5=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    
    public void FXSonidoChoque(){

        audio5.clip = fxs[0];
        audio5.Play();
    }

    public void FXMusic(){

        audio5.clip = fxs[1];
        audio5.Play();
    }
    void Update()
    {
        
    }
}
