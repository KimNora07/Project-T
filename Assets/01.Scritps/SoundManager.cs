using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

namespace ProjectT.Manager
{
    public class SoundManager : MonoBehaviour
    {
        public AudioMixer mixer;
        public AudioSource bgSound;
        public AudioClip[] bgList;

        public static SoundManager instance;
        private void Awake()
        {
            if(instance==null)
            {
                instance = this;
                DontDestroyOnLoad(instance);
                SceneManager.sceneLoaded += OnSeneLoaded;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void OnSeneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            for(int i = 0; i < bgList.Length; i++)
            {
                if (arg0.name == bgList[i].name)
                    BgSoundPlay(bgList[i]);
            }
        }

        public void BgSoundVolume(float val)
        {
            mixer.SetFloat("BgSoundVolume", Mathf.Log10(val) * 20);
        }

        public void SFXPlay(string sfxName, AudioClip clip)
        {
            GameObject go = new GameObject(sfxName + "Sound");
            AudioSource audioSource = go.AddComponent<AudioSource>();
            audioSource.outputAudioMixerGroup = mixer.FindMatchingGroups("SFX")[0];
            audioSource.clip = clip;
            audioSource.Play();

            Destroy(go, clip.length);
        }

        public void BgSoundPlay(AudioClip clip)
        {
            bgSound.outputAudioMixerGroup = mixer.FindMatchingGroups("BgSound")[0];
            bgSound.clip = clip;
            bgSound.loop = true;
            bgSound.volume = 0.1f;
            bgSound.Play();
        }
    }
}

