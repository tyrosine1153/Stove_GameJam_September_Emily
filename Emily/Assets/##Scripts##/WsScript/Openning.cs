using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace ws
{
    public class Openning : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button setttingsButton;
        [SerializeField] private Button exitButton;

        [SerializeField] private GameObject settingsPopupScreen;

        public void StartButtonDown() => print("Start");
        public void SetttingsButtonDown() => settingsPopupScreen.SetActive(true);
        public void ExitButtonDown() => Application.Quit();
    }
}