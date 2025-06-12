using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] UnitStats stats;

    private void Update()
    {
        //stats.manipulator.BloodReduction(0.05f * Time.deltaTime);
        if (stats.Vitality <= 0)
        {
            Debug.Log($"{stats.UnitName} is dead.");
        }
    }

}
