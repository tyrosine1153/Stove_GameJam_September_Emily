using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialiseScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManagerEx.instance.LoadScene(SceneType.Menu);
    }
}
