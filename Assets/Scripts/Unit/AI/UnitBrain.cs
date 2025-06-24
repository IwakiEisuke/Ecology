using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// ユニットの思考から行動を制御するクラス（後から粒度上げる）
/// </summary>
public class UnitBrain : MonoBehaviour
{
    [SerializeField] Unit unit;
    [SerializeField] UnitStats stats;
    [SerializeField] NavMeshAgent agent;

    [SerializeField] Transform target;

    private void Update()
    {
        if (unit == null) return;

        if (target == null)
        {
            ChaseMousePointer();
        }
        else if ((target.position - transform.position).sqrMagnitude < 2)
        {
            if (target.TryGetComponent<Food>(out Food food))
            {
                // 食べ物に到達した場合、食べる処理を実行
                food.Eat(unit);
            }
            else if (target.TryGetComponent<Unit>(out Unit targetUnit))
            {
                // 他のユニットに到達した場合、戦闘や交流などの処理を実行
                Debug.Log($"{unit.name} reached {targetUnit.name}");
            }
            target = null;
        }
    }

    private void ChaseMousePointer()
    {
        // 目標を設定するロジック
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            agent.SetDestination(hitInfo.point);
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
    }
}