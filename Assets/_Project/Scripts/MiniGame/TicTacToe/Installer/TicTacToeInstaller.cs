using Zenject;

public class TicTacToeInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<TicTacToeBoard>().AsTransient();
        Container.BindInterfacesAndSelfTo<TicTacToeController>().AsSingle();
    }
}