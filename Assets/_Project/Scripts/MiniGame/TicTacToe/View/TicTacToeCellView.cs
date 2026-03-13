using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToeCellView : MonoBehaviour
{
    [SerializeField]
    private Button button;
    [SerializeField]
    private TextMeshProUGUI text;

    private int _x;
    private int _y;

    private TicTacToeController _controller;

    public int X => _x;
    public int Y => _y;

    public void Init(int x, int y, TicTacToeController controller)
    {
        _x = x;
        _y = y;
        _controller = controller;
        
        text.text = "";
    }

    void OnClick()
    {
        _controller.OnCellClicked(this);
    }

    public void SetState(CellState state)
    {
        if(state == CellState.X)
            text.text = "X";

        if(state == CellState.O)
            text.text = "O";

        button.interactable = false;
    }

    private void OnEnable()
    {
        button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(OnClick);
    }
}