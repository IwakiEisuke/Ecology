using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ユニットの基本情報表示
/// </summary>
public class UnitStatsView : MonoBehaviour
{
    [SerializeField] UnitStats unitStats;
    [SerializeField] Text testStatsText;

    private void Update()
    {
        UpdateView();
    }

    private void UpdateView()
    {
        testStatsText.text = unitStats.TestStats.ToString("F2");
    }
}
