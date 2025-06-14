using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

/// <summary>
/// マウス入力の管理
/// </summary>
[CreateAssetMenu(menuName = "InputManager/MouseInput")]
public class MouseInputManager : ScriptableObject
{
    public bool IsDragging => _isDragging;
    public bool IsMouseHoveringUI => _isMouseHoveringUI;
    public Vector3 DragStartMousePos => _dragStartMousePos;
    public Vector3 DragEndMousePos => _dragEndMousePos;

    public event Action OnMouseDown;
    public event Action OnMouseUp;
    public event Action OnStartDrag;
    public event Action OnClicked;
    public event Action OpenMenu;
    public event Action CloseMenu;
    public event Action OnMouseClickedWithoutUI;

    public float startDragDistance = 50;

    [SerializeField] InputActionReference mousePress;
    [SerializeField] InputActionReference mousePoint;
    [SerializeField] InputActionReference openMenu;

    Vector3 _dragStartMousePos;
    Vector3 _dragEndMousePos;

    bool _isDragging;
    bool _canDrag;
    bool _isMouseHoveringUI;

    public void Init()
    {
        mousePress.action.started += (context) =>
        {
            _dragStartMousePos = mousePoint.action.ReadValue<Vector2>();
            OnMouseDown?.Invoke();
            _canDrag = !_isMouseHoveringUI;
        };

        mousePress.action.canceled += (context) =>
        {
            OnMouseUp?.Invoke();
            if (!IsDragging) OnClicked?.Invoke();
            _isDragging = false;

            if (_canDrag)
            {
                OnMouseClickedWithoutUI?.Invoke();
                CloseMenu?.Invoke();
            }
        };

        openMenu.action.performed += (context) =>
        {
            OpenMenu?.Invoke();
        };
    }

    public void Update()
    {
        _isMouseHoveringUI = EventSystem.current.IsPointerOverGameObject();

        if (mousePress.action.IsPressed() && _canDrag)
        {
            _dragEndMousePos = mousePoint.action.ReadValue<Vector2>();
            if (!IsDragging && Vector3.Distance(_dragStartMousePos, Input.mousePosition) > startDragDistance)
            {
                _isDragging = true;
                OnStartDrag?.Invoke();
                CloseMenu?.Invoke();
            }
        }
    }

    public void ResetActions()
    {
        OnMouseDown = null;
        OnMouseUp = null;
        OnStartDrag = null;
        OnClicked = null;
        OpenMenu = null;
        CloseMenu = null;
        OnMouseClickedWithoutUI = null;
    }

    public void EnableActions()
    {
        mousePress.action.Enable();
        mousePoint.action.Enable();
        openMenu.action.Enable();
    }

    public void DisableActions()
    {
        mousePress.action.Disable();
        mousePoint.action.Disable();
        openMenu.action.Disable();
    }
}