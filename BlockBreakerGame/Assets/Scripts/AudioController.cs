using UnityEngine;

namespace Blockbreaker
{

    public class AudioController : GenericSingleton<AudioController>
    {
        [SerializeField]
        private AudioSource musicAudio;
        [SerializeField]
        private AudioSource sfxAudio;
        
        private void Start()
        {
            if (musicAudio == null)
            {
                musicAudio = transform.GetChild(0).GetComponent<AudioSource>();
            }
            if (sfxAudio == null)
            {
                sfxAudio = transform.GetChild(1).GetComponent<AudioSource>();
            }

            PlayMusic();
        }
        
        private void PlayMusic()
        {
            musicAudio.Play();
        }

    }
}
