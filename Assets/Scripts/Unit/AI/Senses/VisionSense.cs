using UnityEngine;

public class VisionSense : SenseBase
{
    [SerializeField] Unit owner;
    [SerializeField] float visionRange = 10f;
    [SerializeField] LayerMask targetLayerMask;

    readonly Collider[] hits = new Collider[10];

    private void Update()
    {
        Physics.OverlapSphereNonAlloc(transform.position, visionRange, hits, targetLayerMask);

        if (owner == null || owner.Brain == null)
        {
            Debug.LogWarning("VisionSense: Owner or Brain is null, skipping target detection.");
            enabled = false;
            return;
        }

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] != null)
            {
                if (hits[i].TryGetComponent<Food>(out Food food))
                {
                    // 食べ物を見つけた場合、食べ物の位置をユニットの脳に設定
                    owner.Brain.SetTarget(food.transform);
                }
                else if (hits[i].transform != owner.transform && hits[i].TryGetComponent(out Unit targetUnit))
                {
                    // ユニットを見つけた場合、ターゲットユニットの脳にターゲットを設定
                    owner.Brain.SetTarget(targetUnit.transform);
                }
            }
        }
    }
}
