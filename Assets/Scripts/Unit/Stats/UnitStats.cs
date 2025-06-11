using UnityEngine;

/// <summary>
/// ユニットのステータス
/// </summary>
public class UnitStats : MonoBehaviour
{
    [SerializeField] float testStats = 100f;

    public float TestStats => testStats;
}
