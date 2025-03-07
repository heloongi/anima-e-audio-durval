using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip footstepSound;
    public AudioClip attackSound;
    public AudioClip jumpSound;

    public void PlayFootstepSound()
    {
        audioSource.PlayOneShot(footstepSound);
    }

    public void PlayAttackSound()
    {
        audioSource.PlayOneShot(attackSound);
    }

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
    }
}

