﻿using UnityEngine;

/// <summary>
/// ユニットのステータス
/// </summary>
public partial class UnitStats : MonoBehaviour
{
    [SerializeField] string unitName;
    [SerializeField] int age;

    public string UnitName => unitName;
    public int Age => age;

    // 基本ステータス
    [SerializeField] float blood = 1;
    [SerializeField] float oxygen = 1;
    [SerializeField] float consciousness = 1;
    [SerializeField] float hunger = 1;
    [SerializeField] float thirst = 1;
    [SerializeField] float stamina = 1;
    [SerializeField] float vitality = 1;

    public float Blood => blood;
    public float Oxygen => oxygen;
    public float Consciousness => consciousness;
    public float Hunger => hunger;
    public float Thirst => thirst;
    public float Stamina => stamina;
    public float Vitality => vitality;

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

    partial void Start();
    partial void Update();
}
