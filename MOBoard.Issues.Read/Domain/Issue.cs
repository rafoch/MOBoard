using System;
using System.ComponentModel.DataAnnotations;
using MOBoard.Common.Types;

namespace MOBoard.Issues.Read.Domain
{
    public class Issue : AggregateRoot
    {
        public Issue()
        {
            
        }

        public Issue(string name, DateTime? dueDate)
        {
            Name = name;
            DueDate = dueDate;
        }

        [Required]
        public string Name { get; private set; }
        public DateTime? DueDate { get; private set; }
    }
}