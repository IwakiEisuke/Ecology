using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] float nutritionValue = 10f;
    [SerializeField] float hydrationValue = 5f;
    [SerializeField] float spoilTime = 60f; // 食品が腐るまでの時間（秒）
    [SerializeField] bool isSpoiled = false;
    
    public float NutritionValue => nutritionValue;
    public float HydrationValue => hydrationValue;
    public float SpoilTime => spoilTime;
    public bool IsSpoiled => isSpoiled;

    private void Update()
    {
        spoilTime -= Time.deltaTime;
        if (spoilTime <= 0 && !isSpoiled)
        {
            isSpoiled = true;
            // ここで食品が腐ったことを通知する処理を追加できます
            Debug.Log("Food has spoiled!");
        }
    }

    public void Eat(Unit unit)
    {
        if (isSpoiled)
        {
            Debug.Log($"{unit.name} cannot eat spoiled food!");
            return;
        }

        // ユニットのステータスに栄養と水分を追加
        unit.Stats.Hunger += nutritionValue;
        unit.Stats.Thirst += hydrationValue;
        Debug.Log($"{unit.name} ate food and gained {nutritionValue} nutrition and {hydrationValue} hydration.");
        
        // 食品を消費した後、オブジェクトを破棄
        Destroy(gameObject);
    }
}
