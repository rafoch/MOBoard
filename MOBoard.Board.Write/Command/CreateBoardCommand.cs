using MOBoard.Board.Write.Domain;

namespace MOBoard.Board.Write.Command
{
    public class CreateBoardCommand
    {
        public string Name { get; private set; }
        public BoardType BoardType { get; private set; }
    }
}