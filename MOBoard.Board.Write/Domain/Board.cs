using System.Collections.Generic;
using MOBoard.Common.Types;

namespace MOBoard.Board.Write.Domain
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

        public string Name { get; private set; }
        public BoardType Type { get; private set; }
        public ISet<Column> Columns { get; private set; }
    }

    public class Column : AggregateRoot
    {
        public string Name { get; set; }

    }

    public enum BoardType
    {
        Normal, RoadMap
    }
}