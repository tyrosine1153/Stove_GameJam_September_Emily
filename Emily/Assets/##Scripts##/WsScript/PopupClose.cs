using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupClose : MonoBehaviour
{
    [SerializeField] private GameObject target;
    public void CloseButtonDown() => target.SetActive(false);
}
