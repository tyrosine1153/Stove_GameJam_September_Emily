using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SoundSetting : MonoBehaviour
{
    [SerializeField] private Slider volumeController;
    [SerializeField] private Text volmunText;

    private void Update()
    {
        volumeController.onValueChanged.AddListener(ChangeValueText);
    }

    public void ChangeValueText(float value)
    {
        volmunText.text = $"{volumeController.value}";
    }
}
