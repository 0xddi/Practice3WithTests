using System.Globalization;
using ChessExample;

namespace Practice3;

public enum ColorEnum
{
    White = 1,
    Black
}

abstract class ChessFigure
{
    protected CheckerBoardPosition StartPosition;
    protected CheckerBoardPosition EndPosition;
    
    public abstract bool IsAbleToMove();

    public ChessFigure(CheckerBoardPosition startPosition, CheckerBoardPosition endPosition)
    {
        this.StartPosition = startPosition;
        this.EndPosition = endPosition;
    }
}

class Pawn : ChessFigure
{
    protected int Color;

    private bool CheckColor(CheckerBoardPosition position, int color)
    {
        if ((Math.Abs(position.X - position.Y) % 2 == 0) && color == (int)ColorEnum.Black) return true;
        if ((Math.Abs(position.X - position.Y) % 2 == 1) && color == (int)ColorEnum.White) return true;
        return false;
    }
    
    public override bool IsAbleToMove()
    {
        return (Math.Abs(StartPosition.X - EndPosition.X) == 1) && (Math.Abs(StartPosition.Y - EndPosition.Y) == 1) && CheckColor(StartPosition, Color) && CheckColor(EndPosition, Color);
    }

    public Pawn(CheckerBoardPosition startPosition, CheckerBoardPosition endPosition, int color) : base(startPosition, endPosition)
    {
        this.Color = color; 
    }
}

class Rook : ChessFigure
{
    public override bool IsAbleToMove()
    {
        return (StartPosition.X == EndPosition.X) || (StartPosition.Y == EndPosition.Y);
    }

    public Rook(CheckerBoardPosition startPosition, CheckerBoardPosition endPosition) : base(startPosition, endPosition) {}
}

class Knight : ChessFigure
{
    public override bool IsAbleToMove()
    {
        return (Math.Abs(StartPosition.X - EndPosition.X) == 1) && (Math.Abs(StartPosition.Y - EndPosition.Y) == 2) || ((Math.Abs(StartPosition.X - EndPosition.X) == 2) && (Math.Abs(StartPosition.Y - EndPosition.Y) == 1));
    }

    public Knight(CheckerBoardPosition startPosition, CheckerBoardPosition endPosition) : base(startPosition, endPosition) {}
}

class Bishop : ChessFigure
{
    public override bool IsAbleToMove()
    {
        return Math.Abs(StartPosition.X - EndPosition.X) == Math.Abs(StartPosition.Y - EndPosition.Y);
    }

    public Bishop(CheckerBoardPosition startPosition, CheckerBoardPosition endPosition) : base(startPosition, endPosition) {}
}

class Queen : ChessFigure
{
    public override bool IsAbleToMove()
    {
        return (StartPosition.X == EndPosition.X || StartPosition.Y == EndPosition.Y) || Math.Abs(StartPosition.X - EndPosition.X) == Math.Abs(StartPosition.Y - EndPosition.Y);
    }
    
    public Queen(CheckerBoardPosition startPosition, CheckerBoardPosition endPosition) : base(startPosition, endPosition)
    {
        this.StartPosition = startPosition;
        this.EndPosition = endPosition;
    }
}

class King : ChessFigure
{
    public override bool IsAbleToMove()
    {
        return (Math.Abs(StartPosition.X - EndPosition.X) <= 1) && (Math.Abs(StartPosition.Y - EndPosition.Y) <= 1);
    }
    
    public King(CheckerBoardPosition startPosition, CheckerBoardPosition endPosition) : base(startPosition, endPosition)
    {
        this.StartPosition = startPosition;
        this.EndPosition = endPosition;
    }
}




class Program
{
    static void Main()
    {
        Console.Write("Enter the start position of the figure: ");
        var inputStartPosition = CheckerBoardPosition.Parse(Console.ReadLine().ToUpper(), CultureInfo.InvariantCulture);
        Console.Write("Enter the end position of the figure: ");
        var inputEndPosition = CheckerBoardPosition.Parse(Console.ReadLine().ToUpper(), CultureInfo.InvariantCulture);

        Console.WriteLine("Now choose your chess figure:");
        Console.WriteLine("=============================");
        Console.WriteLine("1. Black Pawn");
        Console.WriteLine("2. White Pawn");
        Console.WriteLine("3. Rook");
        Console.WriteLine("4. Knight");
        Console.WriteLine("5. Bishop");
        Console.WriteLine("6. Queen");
        Console.WriteLine("7. King");
        Console.WriteLine("=============================");
        Console.Write("Your choice: ");
        var chosenFigure = int.Parse(Console.ReadLine());
        switch (chosenFigure)
        {
            case 1:
                Console.WriteLine((new Pawn(inputStartPosition, inputEndPosition, (int)ColorEnum.Black)).IsAbleToMove());
                break;
            case 2:
                Console.WriteLine((new Pawn(inputStartPosition, inputEndPosition, (int)ColorEnum.White)).IsAbleToMove());
                break;
            case 3:
                Console.WriteLine((new Rook(inputStartPosition, inputEndPosition)).IsAbleToMove());
                break;
            case 4:
                Console.WriteLine((new Knight(inputStartPosition, inputEndPosition)).IsAbleToMove());
                break;
            case 5:
                Console.WriteLine((new Bishop(inputStartPosition, inputEndPosition)).IsAbleToMove());
                break;
            case 6:
                Console.WriteLine((new Queen(inputStartPosition, inputEndPosition)).IsAbleToMove());
                break;
            case 7:
                Console.WriteLine((new King(inputStartPosition, inputEndPosition)).IsAbleToMove());
                break;
        }
    }
}