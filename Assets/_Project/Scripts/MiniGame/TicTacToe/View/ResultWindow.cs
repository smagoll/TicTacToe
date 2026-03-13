using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultWindow : MonoBehaviour
{
    public event Action OnHandle;
    
    [SerializeField]
    private Button button;

    [SerializeField]
    private TextMeshProUGUI _textResult;
    [SerializeField]
    private TextMeshProUGUI _textCoin;

    public void Init(MiniGameOutcome outcome)
    {
        _textResult.text = outcome.Result == MiniGameResult.Draw ? "Draw!" : $"Victory: {outcome.Winner}";

        _textCoin.text = $"+{outcome.Coins} Coins";
    }
    
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Handle()
    {
        OnHandle?.Invoke();
    }

    private void OnEnable()
    {
        button.onClick.AddListener(Handle);
    }
    
    private void OnDisable()
    {
        button.onClick.RemoveListener(Handle);
    }
}
