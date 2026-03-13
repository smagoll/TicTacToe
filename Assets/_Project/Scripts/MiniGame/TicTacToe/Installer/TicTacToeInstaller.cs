using Zenject;

public class TicTacToeInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<TicTacToeBoard>().AsSingle();
        Container.BindInterfacesAndSelfTo<TicTacToeController>().AsSingle();
    }
}