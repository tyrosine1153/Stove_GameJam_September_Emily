using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace ws
{
    public class Opening : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button exitButton;

        public void StartButtonDown()
        {
            SoundManager.instance.PlayEffectSound((int)SoundName.effectSound);
            SceneManagerEx.instance.LoadScene(SceneType.Opening);
        }

        public void ExitButtonDown()
        {
            Application.Quit();
        }
    }
}