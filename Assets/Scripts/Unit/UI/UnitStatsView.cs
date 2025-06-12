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
    [SerializeField] Text vitality;
    [SerializeField] Text traits;
    [SerializeField] Text emotion;
    [SerializeField] GameObject attributesParent;

    private void Update()
    {
        UpdateView();
    }

    private void UpdateView()
    {
        
    }
}
