using System;
using UnityEngine;

public partial class UnitStats
{
    public Manipulator manipulator;

    partial void Start()
    {
        manipulator = new Manipulator(this);
    }

    partial void Update()
    {
        manipulator.Balance();
    }

    [Serializable]
    public class Manipulator
    {
        [SerializeField] private readonly UnitStats stats;
        public Manipulator(UnitStats stats)
        {
            this.stats = stats;
        }

        public void BloodReduction(float value)
        {
            stats.blood = Mathf.Clamp01(stats.blood - value);
        }

        public void Balance()
        {
            var dt = Time.deltaTime;
            stats.oxygen = Mathf.Clamp01(stats.oxygen - (stats.oxygen - stats.blood) * 0.3f*dt);
            stats.consciousness = Mathf.Clamp01(stats.consciousness - ((stats.consciousness - stats.oxygen)*0.1f + (1 - stats.oxygen) * 0.2f)* dt);
            stats.stamina = Mathf.Clamp01(stats.stamina - (stats.stamina - stats.oxygen)*0.2f*dt);
            stats.vitality = Mathf.Clamp01(stats.vitality - ((stats.vitality - stats.oxygen)*0.1f + (1 - stats.vitality) * 0.05f)*dt);
        }
    }
}

