using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupClose : MonoBehaviour
{
    public void CloseButtonDown() => gameObject.SetActive(false);
}
