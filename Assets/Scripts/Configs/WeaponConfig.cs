using System;
using UnityEngine;




[CreateAssetMenu(fileName = "WeaponConfig", menuName = "Scriptable Objects/WeaponConfig")]
public class WeaponConfig : ScriptableObject
{
    [SerializeField]
    private BulletConfig bulletConfig;

    public IBulletsConfig BulletsConfig => bulletConfig;
}

public interface IBulletsConfig
{
    public float Speed { get; }
    public float Lifetime { get; }
}


[Serializable]
public class BulletConfig: IBulletsConfig
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float lifetime;

    public float Speed => speed;
    public float Lifetime => lifetime;
}