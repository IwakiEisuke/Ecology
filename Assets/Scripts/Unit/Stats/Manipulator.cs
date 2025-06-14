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

        public void Reduction()
        {
            var scale = 1 - stats.blood / 2;
            scale *= Time.deltaTime;
            stats.hunger = Mathf.Min(stats.hunger - 0.002f * scale, 1);
            stats.thirst = Mathf.Min(stats.thirst - 0.004f * scale, 1);
            stats.blood = Mathf.Clamp01(stats.blood + 0.004f * scale);
            stats.vitality = Mathf.Clamp01(stats.vitality + 0.002f * scale);
        }

        public void Balance()
        {
            var dt = Time.deltaTime;
            stats.oxygen = Mathf.Clamp01(stats.oxygen - (stats.oxygen - stats.blood) * 0.3f*dt);
            stats.consciousness = Mathf.Clamp01(stats.consciousness - ((stats.consciousness - stats.oxygen)*0.1f + (1 - stats.oxygen) * 0.1f + (stats.consciousness - stats.hunger) * 0.02f + (stats.consciousness - stats.thirst) * 0.04f + (stats.consciousness - stats.stamina) * 0.1f) * dt);
            stats.stamina = Mathf.Clamp01(stats.stamina - (stats.stamina - stats.oxygen)*0.2f*dt);
            stats.vitality = Mathf.Clamp01(stats.vitality - ((stats.vitality - stats.oxygen)*0.1f + (1 - stats.vitality) * 0.05f - (Mathf.Min(0, stats.hunger)*0.2f + Mathf.Min(0, stats.thirst)*0.05f))*dt);
        }
    }
}

