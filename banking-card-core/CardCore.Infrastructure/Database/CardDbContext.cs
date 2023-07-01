using CardCore.Domain.Messages;
using CardCore.Domain.Models;
using CardCore.Domain.Models.BaseModels;
using CardCore.Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CardCore.Infrastructure.Database
{
    public class CardDbContext : DbContext, ICardDbContext
    {
        public DbContext Instance => this;

        public DbSet<Card> Cards { get; set; }

        public CardDbContext(DbContextOptions<CardDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>()
            .HasDiscriminator<string>(opt => opt.CardType)
            .HasValue<CreditCard>(nameof(CreditCard))
            .HasValue<DebitCard>(nameof(DebitCard))
            .HasValue<PrepaidCard>(nameof(PrepaidCard));

            modelBuilder.Entity<Card>()
            .HasOne(x => x.CardParent)
            .WithMany(x => x.ChildCards)
            .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Card>()
            .HasIndex(i => i.CardHolderNo);

            modelBuilder.Entity<ProductRule>()
            .HasKey(x => new {x.ProductId, x.RuleId});
            
            base.OnModelCreating(modelBuilder);
        }
        public async Task<bool> CommitChanges(EFContextMessage message, CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && (e.State == EntityState.Modified || e.State == EntityState.Added || e.State == EntityState.Deleted)).ToList();
            try
            {
                if (entries.Count > 0)
                {
                    foreach (var entry in entries)
                    {


                        switch (entry.State)
                        {
                            case EntityState.Added:
                                break;
                            case EntityState.Modified:
                                break;
                            case EntityState.Deleted:
                                break;
                            default: break;
                        }
                    }
                }
                var affectedRows = await this.SaveChangesAsync(cancellationToken);
                return affectedRows > 0;
            }
            catch (DbUpdateConcurrencyException ex)
            {

                throw;
            }
        }
    }
}