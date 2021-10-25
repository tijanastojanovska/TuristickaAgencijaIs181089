using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TuristickaAgencijaIS181089.Domain.DomainModels;
using TuristickaAgencijaIS181089.Repository.Data;
using TuristickaAgencijaIS181089.Repository.Interfaces;

namespace TuristickaAgencijaIS181089.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {

        private readonly ApplicationDbContext context;
        private DbSet<Order> entities;
        string errorMessage = string.Empty;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Order>();
        }


        public List<Order> getAllOrders()
        {
            return entities
                .Include(z => z.User)
                .Include(z => z.OrderedLines)
                .Include("OrderedLines.LineInOrder")
                .Include("OrderedLines.LineInOrder.StartingDestination")
               .Include("OrderedLines.LineInOrder.FinalDestination")
               .Include("OrderedLines.LineInOrder.Company")
                .ToListAsync().Result;
        }

        public Order getOrderDetails(BaseEntity model)
        {
            var e= entities
               .Include(z => z.User)
               .Include(z => z.OrderedLines)
               .Include("OrderedLines.LineInOrder")
               .Include("OrderedLines.LineInOrder.StartingDestination")
               .Include("OrderedLines.LineInOrder.FinalDestination")
               .Include("OrderedLines.LineInOrder.Company")

               .SingleOrDefaultAsync(z => z.Id == model.Id).Result;
            return e;
        }

    }
}
