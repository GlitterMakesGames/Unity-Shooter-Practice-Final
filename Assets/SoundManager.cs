using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioClip[] clips;

    private AudioSource audioSource;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                audioSource = GetComponent<AudioSource>();
            }
            else
            {
                Destroy(gameObject);
            }
        }

    public void PlayClip(int clip)
    {
        audioSource.PlayOneShot(clips[clip]);
    }

    public void PlaySound(AudioClip clip)
        {
            audioSource.PlayOneShot(clip);
        }

        public void PlaySoundWithVolume(AudioClip clip, float volume)
        {
            audioSource.PlayOneShot(clip, volume);
        }
}
