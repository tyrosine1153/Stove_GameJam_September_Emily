using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ws
{
    public class SettingPopup : MonoBehaviour
    {
        [SerializeField] private GameObject settingsPopupScreen;
        [SerializeField] private Button settingsButton;

        [SerializeField] private Text volmunText;
        [SerializeField] private Slider volumeController;
        public void SettingsButtonDown()
        {
            SoundManager.instance.PlayEffectSound(1);
            settingsPopupScreen.SetActive(true);
            UpdateVolumeController();
        }

        // Start is called before the first frame update
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
        public void VolumeChanged(float value)
        {
            ChangeVolumeText(value);
            SoundManager.instance.SetSoundValue(value * 0.1f);
        }
        private void UpdateVolumeController()
        {
            volumeController.value = SoundManager.instance.GetBackGroundMusicVolume() * 10;
            ChangeVolumeText(volumeController.value);
        }
        private void ChangeVolumeText(float volume)
        {
            volmunText.text = $"{volume}";
        }
    }
}