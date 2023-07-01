using CardCore.Domain.Messages;
using CardCore.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CardCore.Infrastructure.Abstractions
{
    public interface ICardDbContext
    {
        public DbContext Instance {get;}
        public DbSet<Card> Cards { get; set; }
        Task<bool> CommitChanges(EFContextMessage message, CancellationToken cancellationToken = default);
    }
}