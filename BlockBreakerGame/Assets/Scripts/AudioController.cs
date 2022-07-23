using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blockbreaker
{
    /// <summary>
    /// 
    /// </summary>
    public class AudioController : GenericSingleton<AudioController>
    {
        
        [SerializeField]
        private AudioSource _musicAudio;
        [SerializeField]
        private AudioSource _sfxAudio;

        /// <summary>
        /// Use this for initialization
        /// </summary>
        void Start()
        {
            
            if (_musicAudio == null)
            {
                _musicAudio = transform.GetChild(0).GetComponent<AudioSource>();
            }
            if (_sfxAudio == null)
            {
                _sfxAudio = transform.GetChild(1).GetComponent<AudioSource>();
            }

            PlayMusic();
        }

        /// <summary>
        /// 
        /// </summary>
        void PlayMusic()
        {
            _musicAudio.Play();
        }

    }
}
