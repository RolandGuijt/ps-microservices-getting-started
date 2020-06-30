using GloboTicket.Services.ShoppingBasket.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloboTicket.Services.ShoppingBasket.DbContexts
{
    public class ShoppingBasketDbContext : DbContext
    {
        public ShoppingBasketDbContext(DbContextOptions<ShoppingBasketDbContext> options)
        : base(options)
        {
        }

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketLine> BasketLines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data
            modelBuilder.Entity<Basket>().HasData(
                new Basket()
                {
                    BasketId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    UserId = Guid.Parse("6c9fe94e-257a-42e2-a49c-1b216d4e81be")
                });

            modelBuilder.Entity<BasketLine>().HasData(
               new BasketLine()
               {
                   BasketLineId = Guid.Parse("75918bea-7a04-406e-bafd-51dc8b98816f"),
                   BasketId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                   EventId = Guid.Parse("e29f3df4-d9b4-4182-84dc-4289ac17c0c0"),
                   TicketAmount = 3
               },
               new BasketLine()
               {
                   BasketLineId = Guid.Parse("bec71e6b-6b3d-444e-85d7-77bdb3988908"),
                   BasketId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                   EventId = Guid.Parse("39144996-8bad-4cb8-9029-125d88808377"),
                   TicketAmount = 2
               });

            base.OnModelCreating(modelBuilder);
        }
    }
}
