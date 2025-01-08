using System;
using UnityEngine;


public interface IHealthComponent
{
    float Hp { get; }
    void ApplyHpChange(float deltaHp);

    event Action<float> HpChanged;
}
public class HPComponent : MonoBehaviour, IHealthComponent, IStartGameListener
{

    [SerializeField]
    private float InitialHp;

    private float hp;
    public float Hp => hp;

    public event Action<float> HpChanged;


    public void ApplyHpChange(float deltaHp)
    {
        hp += deltaHp;
        hp = Mathf.Max(0, hp);
        HpChanged?.Invoke(hp);

    }

    void IStartGameListener.StartGame()
    {
        hp = InitialHp;
    }
}
