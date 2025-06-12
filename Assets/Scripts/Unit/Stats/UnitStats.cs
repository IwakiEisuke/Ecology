using UnityEngine;

/// <summary>
/// ユニットのステータス
/// </summary>
public class UnitStats : MonoBehaviour
{
    [SerializeField] string unitName;
    [SerializeField] int age;

    // 基本ステータス
    [SerializeField] float blood = 1;
    [SerializeField] float oxygen = 1;
    [SerializeField] float consciousness = 1;
    [SerializeField] float hunger = 1;
    [SerializeField] float thirst = 1;
    [SerializeField] float vitality = 1;

    // 感情
    [SerializeField] float joy;
    [SerializeField] float fear;
    [SerializeField] float excitement;
    [SerializeField] float sadness;
    [SerializeField] float calm;
    [SerializeField] float disgust;
    [SerializeField] float anger;
    [SerializeField] float pain;

    // 性格

    // 能力
}
