using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace ws
{
    public class Openning : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button developersButton;
        [SerializeField] private Button setttingsButton;
        [SerializeField] private Button exitButton;

        [SerializeField] private GameObject developersPopupScreen;
        [SerializeField] private GameObject settingsPopupScreen;

        public void DevelopersButtonDown() => developersPopupScreen.SetActive(true);
        public void SetttingsButtonDown() => settingsPopupScreen.SetActive(true);
    }
}