using Gamesmarket.Domain.Entity;
using Gamesmarket.DAL.DataSeed;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Gamesmarket.DAL
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<long>, long>
    {// Class for working with a database
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
        // Managing collection of objects in database with Entity Framework
        public DbSet<Game> Games { get; set; }
        public DbSet<GameGenreTag> GameGenreTags { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OwnedGame> OwnedGames { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed roles
            var roleManager = modelBuilder.Entity<IdentityRole<long>>().HasData(
                new IdentityRole<long> { Id = 1, Name = "User", NormalizedName = "USER" },
                new IdentityRole<long> { Id = 2, Name = "Moderator", NormalizedName = "MODERATOR" },
                new IdentityRole<long> { Id = 3, Name = "Administrator", NormalizedName = "ADMINISTRATOR" }
            );

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Game>()
                .HasIndex(g => g.Name);

            modelBuilder.Entity<Cart>()
                .HasIndex(c => c.UserId);

            modelBuilder.Entity<Order>()
                .HasIndex(o => o.UserId);

            modelBuilder.Entity<Friendship>()
                .HasIndex(f => new { f.User1Id, f.User2Id })
                .IsUnique();

            // Link entities relationships
            modelBuilder.Entity<Friendship>(builder =>
            {
                builder.HasOne(f => f.User1)
                .WithMany(u => u.FriendshipAsUser1)
                .HasForeignKey(f => f.User1Id)
                .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(f => f.User2)
                .WithMany(u => u.FriendshipAsUser2)
                .HasForeignKey(f => f.User2Id)
                .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(f => f.ActionUser)
                .WithMany()
                .HasForeignKey(f => f.ActionUserId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<GameGenreTag>(builder =>
            {
                builder.HasOne(g => g.Game)
                .WithMany(gm => gm.GameGenres)
                .HasForeignKey(g => g.GameId);
            });

            modelBuilder.Entity<Payment>(builder =>
            {
                builder.HasOne(p => p.Order)
                .WithMany(o => o.Payments)
                .HasForeignKey(p => p.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Order>(builder =>
            {
                builder.ToTable("Orders").HasKey(x => x.Id);

                builder.HasOne(r => r.User)
                    .WithMany(t => t.Orders)
                    .HasForeignKey(r => r.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<OrderItem>(builder =>
            {
                builder.HasOne(or => or.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(or => or.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

                builder.HasOne(g => g.Game)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(g => g.GameId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Cart>(builder =>
            {
                builder.ToTable("Carts").HasKey(x => x.Id);

                builder.HasOne(u => u.User)
                .WithOne(i => i.Cart)
                .HasForeignKey<Cart>(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);

                builder.HasData(new Cart()
                {
                    Id = 1,
                    UserId = 1
                });
            });

            modelBuilder.Entity<CartItem>(builder =>
            {
                builder.HasOne(c => c.Cart)
                .WithMany(o => o.CartItems)
                .HasForeignKey(c => c.CartId)
                .OnDelete(DeleteBehavior.Cascade);

                builder.HasOne(g => g.Game)
                .WithMany(o => o.CartItems)
                .HasForeignKey(g => g.GameId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<OwnedGame>(builder =>
            {
                builder.HasOne(og => og.User)
                .WithMany(o => o.OwnedGames)
                .HasForeignKey(og => og.UserId)
                .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(g => g.Game)
                .WithMany(o => o.OwnedGames)
                .HasForeignKey(g => g.GameId)
                .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(og => og.GiftFromUser)
                .WithMany()
                .HasForeignKey(og => og.GiftFromUserId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            // Seed admin user
            var adminUser = new User
            {
                Id = 1,
                Name = "Admin",
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                LockoutEnabled = true
            };
            var passwordHasher = new PasswordHasher<User>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Qwe!23");

            modelBuilder.Entity<User>().HasData(adminUser);// Add Admin user to db

            modelBuilder.Entity<Game>().HasData(GameSeedData.GetStarterGames().ToArray());

            // Assign Admin role to the admin user
            modelBuilder.Entity<IdentityUserRole<long>>().HasData(
                new IdentityUserRole<long> { UserId = adminUser.Id, RoleId = 3 } // RoleId 3 = "Administrator" role
            );
        }
    }
}
