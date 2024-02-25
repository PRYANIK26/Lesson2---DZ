using System;
using UnityEngine;

[Serializable]
public class RunningStateConfig
{
    [field: SerializeField, Range(0, 15)] public float Speed { get; private set; }
    [field: SerializeField, Range(0, 2)] public float AnimatorSpeed;
}
