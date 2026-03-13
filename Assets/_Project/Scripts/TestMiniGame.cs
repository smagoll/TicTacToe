using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TestMiniGame : MonoBehaviour
{
    [SerializeField]
    private Button _button;
    
    [Inject] private MiniGameLauncher miniGameLauncher;
    
    private bool _isRunning = false;

    private async UniTask StartMiniGameAsync()
    {
        if (_isRunning) return;

        _isRunning = true;

        try
        {
            var result = await miniGameLauncher.Launch("TicTacToe");
            Debug.Log($"Result: {result.Result}, Winner: {result.Winner}, Coins: {result.Coins}");
        }
        catch (System.Exception e)
        {
            Debug.LogException(e);
        }

        _isRunning = false;
    }
    
    private void OnButtonClicked()
    {
        StartMiniGameAsync().Forget();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }
    
    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }
}