using System;
using System.Collections.Generic;
using System.Text;
using TuristickaAgencijaIS181089.Domain.DomainModels;

namespace TuristickaAgencijaIS181089.Repository.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> getAllOrders();
        Order getOrderDetails(BaseEntity model);
    }
}
