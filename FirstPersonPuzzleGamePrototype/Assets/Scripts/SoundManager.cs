using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public void PlaySoundWhenClicked(AudioSource clip)
    {
        clip.Play();
    }

}
