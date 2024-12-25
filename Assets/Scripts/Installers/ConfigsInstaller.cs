using System;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ConfigsInstaller", menuName = "Installers/ConfigsInstaller")]
public class ConfigsInstaller : ScriptableObjectInstaller<ConfigsInstaller>
{
    [SerializeField]
    KeyboardInputConfig keyboardInputConfig;

    [SerializeField]
    private BulletConfig bulletConfig;
    public override void InstallBindings()
    {
        Container.Bind<IKeyboardInputConfig>().To<KeyboardInputConfig>().FromInstance(keyboardInputConfig).AsSingle();
        Container.Bind<IBulletConfig>().To<BulletConfig>().FromInstance(bulletConfig).AsSingle();
    }
}

public interface IKeyboardInputConfig
{
    KeyCode Up { get; }
    KeyCode Right { get; }
    KeyCode Left { get; }
    KeyCode Down { get; }
}

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

[Serializable]
public class KeyboardInputConfig: IKeyboardInputConfig
{
    [SerializeField]
    private KeyCode up;

    [SerializeField]
    private KeyCode left;
    [SerializeField]
    private KeyCode down;
    [SerializeField]
    private KeyCode right;

    public KeyCode Up => up;

    public KeyCode Right => right;

    public KeyCode Left => left;

    public KeyCode Down => down;
}