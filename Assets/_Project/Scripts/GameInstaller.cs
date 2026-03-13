using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField]
    private MiniGameLauncher miniGameLauncher;
    
    public override void InstallBindings()
    {
        Container.Bind<MiniGameLauncher>().FromInstance(miniGameLauncher).AsSingle(); 
    }
}