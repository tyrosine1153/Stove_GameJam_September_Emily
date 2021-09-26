using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ws
{
    public class SoundPlayer : MonoBehaviour
    {
        [SerializeField] int songNumber;

        void Start()
        {
            SoundManager.instance.PlayBGM(songNumber);
        }
    }
}