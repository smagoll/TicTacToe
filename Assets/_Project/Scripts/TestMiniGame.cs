using UnityEngine;
using Zenject;

public class TestMiniGame : MonoBehaviour
{
    [Inject] private MiniGameLauncher miniGameLauncher;

    private async void Start()
    {
        var result = await miniGameLauncher.Launch("TicTacToe");

        Debug.Log($"Result: {result.Result} Coins: {result.Coins}");
    }
}