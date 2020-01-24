using System;
using AutoFixture;
using FluentAssertions;
using MOBoard.Issues.Write.Commands;
using MOBoard.Issues.Write.Domain;
using MOBoard.Tests.Common;
using Xunit;

namespace MOBoard.Tests.Commands
{
    public class Tests
    {
        private readonly IFixture _fixture;

        public Tests()
        {
            _fixture = new Fixture().WithStandardCustomizations();
        }

        [Fact]
        public void ShouldExecute()
        {
            var createCommand = _fixture.Create<CreateIssueCommand>();
            var issue = Issue.Create(
                createCommand.Name,
                Guid.NewGuid(),
                createCommand.Description,
                createCommand.ProjectId,
                createCommand.Priority);
            //act
            issue.CreatedAt.Should().NotBe(DateTime.MaxValue);

        }
    }
}