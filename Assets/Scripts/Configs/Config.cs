using System;
using UnityEngine;




[CreateAssetMenu(fileName = "Config", menuName = "Scriptable Objects/Config")]
public class Config : ScriptableObject
{
    [SerializeField]
    private BulletConfig bulletConfig;
    [SerializeField]
    private KeyboardInputConfig keyboardInputConfig;

    public IBulletsConfig BulletsConfig => bulletConfig;
    public IKeyboardInputConfig KeyboardInputConfig => keyboardInputConfig;

}

public interface IKeyboardInputConfig
{
    public KeyCode Up { get; }
    public KeyCode Left { get; }
    public KeyCode Down { get; }
    public KeyCode Right { get; }
}
public interface IBulletsConfig
{
    public float Speed { get; }
    public float Lifetime { get; }
}

[Serializable]
public class KeyboardInputConfig : IKeyboardInputConfig
{
    [SerializeField] private KeyCode up;
    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode down;
    [SerializeField] private KeyCode right;

    public KeyCode Up => up;

    public KeyCode Left => left;

    public KeyCode Down => down;

    public KeyCode Right => right;
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