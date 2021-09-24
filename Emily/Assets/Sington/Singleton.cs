using UnityEngine;

// 예시에서는 접근 제한 지시자 (public, private, protected)는 public으로 통일하였습니다.

// 싱글톤을 사용 할 클래스에 상속을 받아 사용한다. 
// ex : public class ClassName : Singleton<ClassName>  { }

// 외부에서 접근할 경우 className.instance.참조할_변수/함수
// ex : TestClass.instance.print("Hello, World");

// OnAwake 함수는 override 하여 사용한다.
// ex : public override void OnAwake()

[DisallowMultipleComponent]
public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    // 상속 받은 객체에서 해당 bool 변수를 true / false 해 주는 것으로 싱글톤을 상속한 GameObject의 dontDestroyOnLoad를 on / off 가능함
    public bool dontDestroyOnLoad;

    private static volatile T _instance;
    private static object _syncRoot = new System.Object();

    public static T instance
    {
        get
        {
            Initialize();
            return _instance;
        }
    }

    public static bool isInitialized
    {
        get
        {
            return _instance != null;
        }
    }

    public static void Initialize()
    {
        if (_instance != null)
        {
            return;
        }
        lock (_syncRoot)
        {
            _instance = GameObject.FindObjectOfType<T>();

            if (_instance == null)
            {
                var go = new GameObject(typeof(T).FullName);
                _instance = go.AddComponent<T>();
            }
        }
    }

    protected virtual void Awake()
    {
        if (_instance != null)
        {
            Debug.LogError(GetType().Name + " Singleton class is already created.");
        }

        if (dontDestroyOnLoad)
        {
            DontDestroyOnLoad(this);
        }

        OnAwake();
    }

    protected virtual void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }

    protected virtual void OnAwake() { }
}