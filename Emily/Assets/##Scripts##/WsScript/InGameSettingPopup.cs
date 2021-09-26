using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace ws
{
    public class InGameSettingPopup : SettingPopup
    {
        public void GoToMainButtonDown()
        {
            InventoryManager.instance.Initlaize();
            ItemManager.instance.Initlaize();

            SceneManagerEx.instance.LoadScene(SceneType.Menu);
        }

        public void QuitButtonDown()
        {
            Application.Quit();
        }
    }
}