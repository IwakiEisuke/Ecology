using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] UnitStats stats;

    private void Update()
    {
        if (stats.Vitality <= 0)
        {
            Debug.Log($"{stats.UnitName} is dead.");
        }
        else
        {
            stats.manipulator.Reduction();
        }
    }

}
