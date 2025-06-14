using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ユニットの基本情報表示
/// </summary>
public class UnitStatsView : MonoBehaviour
{
    [SerializeField] UnitStats unitStats;
    [SerializeField] Text unitName;
    [SerializeField] Text age;
    [SerializeField] Text blood;
    [SerializeField] Text oxygen;
    [SerializeField] Text consciousness;
    [SerializeField] Text hunger;
    [SerializeField] Text thirst;
    [SerializeField] Text stamina;
    [SerializeField] Text vitality;
    [SerializeField] Text personality;
    [SerializeField] Text emotion;
    [SerializeField] GameObject attributesParent;

    private void Update()
    {
        UpdateView();
    }

    private void UpdateView()
    {
        unitName.text = unitStats.UnitName;
        age.text = unitStats.Age.ToString();
        blood.text = unitStats.Blood.ToString("F2");
        oxygen.text = unitStats.Oxygen.ToString("F2");
        consciousness.text = unitStats.Consciousness.ToString("F2");
        hunger.text = unitStats.Hunger.ToString("F2");
        thirst.text = unitStats.Thirst.ToString("F2");
        stamina.text = unitStats.Stamina.ToString("F2");
        vitality.text = unitStats.Vitality.ToString("F2");
    }
}
