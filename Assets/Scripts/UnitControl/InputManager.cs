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

    int frame = 0;

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
    }

    private void Update()
    {
        mouseInputManager.Update();

        if (frame <= 1)
        {
            if (frame == 1)
            {
                // 初回のUpdateでUIアクションマップを有効化
                SetPlayerActionMap();
            }
            frame++;
        }
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
