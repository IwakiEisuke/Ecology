using UnityEngine;

public class UnitController : MonoBehaviour
{
    [SerializeField] UnitSelector unitSelector;
    [SerializeField] UnitBrain unitBrain;

    private void Start()
    {
        InputManager.MouseInput.OnClicked += Attention;
    }

    private void Attention()
    {
        unitBrain.SetTarget(unitSelector.HoveredTarget);
    }
}
