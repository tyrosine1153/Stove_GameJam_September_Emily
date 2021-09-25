using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace ws
{
    public class Opening : MonoBehaviour
    {
        [SerializeField] private Text volmunText;
        [SerializeField] private Slider volumeController;
        [SerializeField] private Button startButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button exitButton;
        [SerializeField] private GameObject settingsPopupScreen;
        public void Start()
        {
            SoundInitialize();
        }

        private void SoundInitialize()
        {
            volumeController.onValueChanged.AddListener(VolumeChanged);
            SoundManager.instance.SetSoundValue(0.5f);
            SoundManager.instance.PlayBGM(0);
        }

        public void StartButtonDown()
        {
            print("Start");
        }
        public void SettingsButtonDown()
        {
            settingsPopupScreen.SetActive(true);
            UpdateVolumeController();
        }
        private void UpdateVolumeController()
        {
            volumeController.value = SoundManager.instance.GetBackGroundMusicVolume() * 10;
            ChangeVolumeText(volumeController.value);
        }

        public void ExitButtonDown()
        {
            Application.Quit();
        }
        public void VolumeChanged(float value)
        {
            ChangeVolumeText(value);
            SoundManager.instance.SetSoundValue(value * 0.1f);
        }
        private void ChangeVolumeText(float volume)
        {
            volmunText.text = $"{volume}";
        }
    }
}