using Application.DTO;
using Application.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ECommerceContext _context;
        public OrderRepository(ECommerceContext context)
        {
            _context = context;
        }

        public async Task<List<OrderDto>> GetAllAsync()
        {
            var orders = await _context.Orders
                .Include(x => x.OrderDetails)
                .ToListAsync();
            var ordersDto = new List<OrderDto>();
            foreach (var order in orders)
            {
                var orderDto = new OrderDto
                {
                    OrderId = order.OrderId,
                    Customer = order.Customer,
                    OrderDate = order.OrderDate,
                    OrderDetails = new List<OrderDetailsDto>()
                };
                foreach (var od in order.OrderDetails)
                {
                    orderDto.OrderDetails.Add(new OrderDetailsDto()
                    {
                        ProductName = (await _context.Products.FindAsync(od.ProductId))?.Name ?? string.Empty,
                        Quantity = od.Quantity
                    });
                }
                ordersDto.Add(orderDto);
            }
            return ordersDto;
        }

        public async Task FulfillOrderAsync(int id)
        {
            var order = await _context.Orders
                .Include(x => x.OrderDetails)
                .FirstOrDefaultAsync(x => x.OrderId == id);
            if (order is not null)
            {
                foreach (var od in order.OrderDetails)
                {
                    var product = await _context.Products.FindAsync(od.ProductId);
                    if (product != null && product.Quantity >= od.Quantity)
                    {
                        product.Quantity -= od.Quantity;
                        await _context.SaveChangesAsync();
                    }
                    else throw new Exception("The order cannot be " +
                                             $"fulfilled as there are not enough product: {product}");
                }
            }
        }

        public async Task AddOrderAsync(OrderDto orderDto)
        {
            var order = new Order
            {
                Customer = orderDto.Customer,
                OrderDate = orderDto.OrderDate,
                OrderDetails = new List<OrderDetails>()
            };

            foreach (var od in orderDto.OrderDetails)
            {
                var orderDetails = new OrderDetails
                {
                    Quantity = od.Quantity,
                    Product = await _context.Products.FirstOrDefaultAsync(x => x.Name == od.ProductName),
                    Order = order
                };
                order.OrderDetails.Add(orderDetails);
            }

            _context.Orders.Add(order);
        }
    }
}
