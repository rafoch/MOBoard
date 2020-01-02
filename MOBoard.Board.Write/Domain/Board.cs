using System;
using System.Collections.Generic;
using MOBoard.Common.Types;

namespace MOBoard.Board.Write.Domain
{
    public class Board : AggregateRoot
    {
        private readonly ISet<Column> _columns = new HashSet<Column>();

        public Board()
        {
        }

        public Board(string name, BoardType type, Guid projectId)
        {
            Name = name;
            Type = type;
            ProjectId = projectId;
            Columns = _columns;
        }

        public static Board Create(Guid projectId, string name)
            => new Board(name, BoardType.Normal, projectId);
        
        public string Name { get; private set; }
        public BoardType Type { get; private set; }
        public Guid ProjectId { get; private set; }
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