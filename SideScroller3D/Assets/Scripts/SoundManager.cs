using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Sound Manager Class 
*/

public class SoundManager : MonoBehaviour
{

    [SerializeField]
    private AudioSource sfxAudio;
    [SerializeField]
    private AudioSource musicAudio;

    public AudioClip[] sfxClips;
    public AudioClip[] musicClips;

    private void Start()
    {

        //TODO make this safer
        if (sfxAudio == null)
            sfxAudio = transform.GetChild(0).GetComponent<AudioSource>();
        if (musicAudio == null)
            musicAudio = transform.GetChild(1).GetComponent<AudioSource>();
    }

    public void PlayCoinCollect()
    {
        //TODO make this refer to dictionary
        if (sfxClips[0] == null) return;
        sfxAudio.PlayOneShot(sfxClips[0]);
    }

    public void PlayDeath()
    {
        if (sfxClips[1] == null) return;
        sfxAudio.PlayOneShot(sfxClips[1]);
    }
}
