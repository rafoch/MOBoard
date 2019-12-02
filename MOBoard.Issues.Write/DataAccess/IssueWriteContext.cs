﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MOBoard.Common.Extensions;
using MOBoard.Issues.Write.Domain;

namespace MOBoard.Issues.Write.DataAccess
{
    public class IssueWriteContext : DbContext
    {

        public IssueWriteContext(DbContextOptions<IssueWriteContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new IssueConfiguration());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var saveChangesAsync = await base.SaveChangesAsync(cancellationToken);
            return saveChangesAsync;
        }

        public DbSet<Issue> Issues { get; set; }
    }
}