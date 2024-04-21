using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudiomangerScript : MonoBehaviour
{
    //Option sivulta löytyvä Sound ON/OFF Nappi/Napit

    public void SoundOff()
    {
        AudioListener.pause = true;
    }
    
    public void SoundOn()
    {
        AudioListener.pause = false;
    }
}
