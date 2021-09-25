using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneType : uint {
    Initialize,

    Menu,

    Opening,
    Ending,

    Lobby,
    FruitRoad,
    ReedField,
}

/// <summary>
/// 씬을 메니징 하는 메니저의 Ex 싱글톤 클래스
/// </summary>
public class SceneManagerEx : Singleton<SceneManagerEx>
{
    private SceneType currentSceneType;
    private object userData;

    public SceneType CurrentSceneType
    {
        get { return currentSceneType; }
    }

    /// <summary>
    /// 씬을 넘어 사용되는 데이터
    /// </summary>
    public object UserData
    {
        get { return userData; }
    }

    /// <summary>
    /// 해당 신 타입을 로드한다
    /// </summary>
    /// <param name="type"></param>
    public void LoadScene(SceneType type)
    {
        SceneManager.LoadScene((int) type);
    }

    /// <summary>
    /// 씬을 넘어 사용될 데이터를 설정한다
    /// </summary>
    /// <param name="data"></param>
    public void SetUserData(object data)
    {
        userData = data;
    }

    /// <summary>
    /// 실제로 로드 된 씬의 타입을 반환한다
    /// </summary>
    /// <returns></returns>
    public SceneType GetActiveSceneType()
    {
        return (SceneType) SceneManager.GetActiveScene().buildIndex;
    }

    /// <summary>
    /// 다음 신으로 이동한다
    /// Lobby - FruitRoad - ReedField 순으로 이동한다
    /// 이외의 신일 때는 무시된다
    /// </summary>
    public void LoadNextScene()
    {
        if (CurrentSceneType < SceneType.Lobby || CurrentSceneType > SceneType.ReedField)
        {
            return;
        }

        var nextSceneType = CurrentSceneType + 1;
        if (nextSceneType > SceneType.ReedField)
        {
            nextSceneType = SceneType.Lobby;
        }

        LoadScene(nextSceneType);
    }

    /// <summary>
    /// 이전 신으로 이동한다
    /// ReedField - FruitRoad - Lobby 순으로 이동한다
    /// 이외의 신일 때는 무시된다
    /// </summary>
    public void LoadPrevScene()
    {
        if (CurrentSceneType < SceneType.Lobby || CurrentSceneType > SceneType.ReedField) {
            return;
        }

        var nextSceneType = CurrentSceneType - 1;
        if (nextSceneType < SceneType.Lobby) {
            nextSceneType = SceneType.ReedField;
        }

        LoadScene(nextSceneType);
    }
}
