using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "InputManager/KeyInputManager")]
public class KeyInputManager : ScriptableObject
{
    [SerializeField] InputActionReference pause;
    [SerializeField] InputActionReference resume;

    public event Action Pause;
    public event Action Resume;

    public void Init()
    {
        pause.action.performed += (context) =>
        {
            Pause?.Invoke();
        };

        resume.action.performed += (context) =>
        {
            Resume?.Invoke();
        };
    }

    public void ResetActions()
    {
        Pause = null;
        Resume = null;
    }
}