using System.Collections.Generic;
using MOBoard.Common.Types;

namespace MOBoard.Board.Read.Domain
{
    public class Board : AggregateRoot
    {
        private readonly ISet<Column> _columns = new HashSet<Column>();

        public Board(string name, BoardType type)
        {
            Name = name;
            Type = type;
            Columns = _columns;
        }

        public string Name { get; }
        public BoardType Type { get; }
        public ISet<Column> Columns { get; }
    }

    public class Column : AggregateRoot
    {
        public string Name { get; }

    }

    public enum BoardType
    {
        Normal,
        RoadMap
    }
}
