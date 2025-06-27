using System;
using UnityEngine;

public interface IBulletConfig
{
    float Lifetime { get; }
    float Speed { get; }
}

[Serializable]
public class BulletConfig : IBulletConfig
{
    [SerializeField]
    private float lifetime;

    [SerializeField]
    private float speed;
    public float Lifetime => lifetime;

    public float Speed => speed;
}