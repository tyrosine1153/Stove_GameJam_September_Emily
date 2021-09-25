using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ws
{
    public class PopupClose : MonoBehaviour
    {
        [SerializeField] private GameObject target;
        public void CloseButtonDown()
        {
            SoundManager.instance.PlayEffectSound(1);
            target.SetActive(false);
        }
    }
}