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





