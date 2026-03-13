using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class TicTacToeController : MonoBehaviour, IMiniGame
{
    [Inject] private TicTacToeBoard _board;

    private UniTaskCompletionSource<MiniGameOutcome> completion;

    private CellState currentPlayer = CellState.X;

    [SerializeField] private TicTacToeCellView[] cells;
    [SerializeField] private ResultWindow resultWindow;

    public UniTask<MiniGameOutcome> Play()
    {
        completion = new UniTaskCompletionSource<MiniGameOutcome>();

        InitBoard();

        return completion.Task;
    }

    void InitBoard()
    {
        for (int i = 0; i < cells.Length; i++)
        {
            int x = i % 3;
            int y = i / 3;

            cells[i].Init(x, y, this);
        }
    }

    public void OnCellClicked(TicTacToeCellView cell)
    {
        if (!_board.TryMakeMove(cell.X, cell.Y, currentPlayer))
            return;

        cell.SetState(currentPlayer);

        if (_board.CheckWin(currentPlayer))
        {
            EndGame(true);
            return;
        }

        if (_board.IsFull())
        {
            EndGame(false);
            return;
        }

        SwitchPlayer();
    }

    void SwitchPlayer()
    {
        currentPlayer = currentPlayer == CellState.X ? CellState.O : CellState.X;
    }

    void EndGame(bool win)
    {
        var outcome = new MiniGameOutcome
        {
            Result = win ? MiniGameResult.Win : MiniGameResult.Draw,
            Coins = win ? 100 : 20,
            Winner = win ? (currentPlayer == CellState.X ? CellState.X : CellState.O) : CellState.Empty
        };

        resultWindow.Init(outcome);

        resultWindow.Show();

        resultWindow.OnHandle += () =>
        {
            resultWindow.Hide();
            completion.TrySetResult(outcome);
            Destroy(gameObject);
        };
        
    }
}