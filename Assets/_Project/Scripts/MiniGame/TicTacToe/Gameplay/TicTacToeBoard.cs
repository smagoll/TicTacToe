public class TicTacToeBoard
{
    private CellState[,] board = new CellState[3,3];

    public bool TryMakeMove(int x, int y, CellState player)
    {
        if (board[x,y] != CellState.Empty)
            return false;

        board[x,y] = player;
        return true;
    }

    public bool CheckWin(CellState player)
    {
        for(int i=0;i<3;i++)
        {
            if(board[i,0]==player && board[i,1]==player && board[i,2]==player)
                return true;

            if(board[0,i]==player && board[1,i]==player && board[2,i]==player)
                return true;
        }

        if(board[0,0]==player && board[1,1]==player && board[2,2]==player)
            return true;

        if(board[0,2]==player && board[1,1]==player && board[2,0]==player)
            return true;

        return false;
    }

    public bool IsFull()
    {
        foreach(var cell in board)
        {
            if(cell == CellState.Empty)
                return false;
        }

        return true;
    }
}