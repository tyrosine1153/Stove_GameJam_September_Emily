using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ws
{
    public enum SoundName
    {
        testBgm = 0,
        buttonDown = 1
    }

    public class SoundManager : Singleton<SoundManager>
    {
        private AudioSource backgroundAudioSource;
        private AudioSource effectAudioSource;

        [SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();
        [SerializeField] private string[] audioClipsPath = 
            {
                "Sounds\\TestBGM",
                "Sounds\\ButtonDown"
            };

        protected override void Awake()
        {
            dontDestroyOnLoad = true;

            for (int i = 0; i < audioClipsPath.Length; i++)
            {
                audioClips.Add(Resources.Load(audioClipsPath[i]) as AudioClip);
            }

            backgroundAudioSource = gameObject.AddComponent<AudioSource>();
            backgroundAudioSource.playOnAwake = true;
            backgroundAudioSource.loop = true;

            effectAudioSource = gameObject.AddComponent<AudioSource>();
            effectAudioSource.playOnAwake = false;
            effectAudioSource.loop = false;

        }

        private void Start()
        {
            backgroundAudioSource.volume = 0.5f;
            effectAudioSource.volume = 0.5f;
        }

        public void SetSoundValue(float volume)
        {
            backgroundAudioSource.volume = volume;
            effectAudioSource.volume = volume;
        }

        public float GetBackGroundMusicVolume()
        {
            return backgroundAudioSource.volume;
        }

        public float GetEffectSoundVolume()
        {
            return effectAudioSource.volume;
        }

        public void StopBGM()
        {
            backgroundAudioSource.Stop();
        }
        public void StopEffectSound()
        {
            effectAudioSource.Stop();
        }

        public void PlayBGM(int soundNumber)
        {
            backgroundAudioSource.clip = audioClips[soundNumber];

            if (backgroundAudioSource.isPlaying) return;
            backgroundAudioSource.Play();
        }

        public void PlayEffectSound(int soundNumber)
        {
            effectAudioSource.clip = audioClips[soundNumber];

            if (effectAudioSource.isPlaying) return;
            effectAudioSource.Play();
        }
    }
}