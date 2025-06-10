using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    [SerializeField] InputActionAsset asset;
    [SerializeField] PlayerInput cameraPlayerInput;
    [SerializeField] MouseInputManager mouseInputManager;
    [SerializeField] KeyInputManager keyInputManager;

    InputActionMap playerMap;
    InputActionMap uiMap;

    public static MouseInputManager MouseInput => Instance.mouseInputManager;
    public static KeyInputManager KeyInput => Instance.keyInputManager;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playerMap = asset.FindActionMap("Player");
        uiMap = asset.FindActionMap("UI");

        mouseInputManager.Init();
        keyInputManager.Init();

#if UNITY_EDITOR
        // InputSystem側で全てアクションマップが有効化されてしまうので、あとから有効状態を設定する
        // このコールバックがStartより後に実行されるため、ここで設定する必要がある
        UnityEditor.EditorApplication.playModeStateChanged += state =>
        {
            if (state == UnityEditor.PlayModeStateChange.EnteredPlayMode)
                SetPlayerActionMap();
        };
#endif
    }

    private void Update()
    {
        mouseInputManager.Update();
    }

    private void OnDestroy()
    {
        mouseInputManager.ResetActions();
        keyInputManager.ResetActions();
    }

    public void SetUIActionMap()
    {
        playerMap.Disable();
        uiMap.Enable();
    }

    public void SetPlayerActionMap()
    {
        playerMap.Enable();
        uiMap.Disable();
    }
}
