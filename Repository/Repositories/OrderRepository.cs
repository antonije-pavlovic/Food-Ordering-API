using Application.DTO;
using Application.Responsens;
using Application.Searches;
using DataAccess;
using Domain;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(RestaurantContext context) : base(context) { }

        public RestaurantContext RestaurantContext
        {
            get
            {
                return Context as RestaurantContext;
            }
        }

        public PageResponse<OrderDTO> Execute(OrderSearch request)
        {
            var query = Find(o => o.UserId == request.UserId);

            if (request.MinTotal.HasValue)
            {
                query = query.Where(o => o.Total >= request.MinTotal);
            }

            if (request.MaxTotal.HasValue)
            {
                query = query.Where(o => o.Total <= request.MaxTotal);
            }           


            var totalCount = query.Count();
            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);
            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            var response = new PageResponse<OrderDTO>
            {
                CurrentPage = request.PageNumber,
                TotalCount = totalCount,
                PageCount = pagesCount,
                Data = query.Select(o => new OrderDTO
                {
                    Total = o.Total,
                    CreateAt = o.CreatedtAt,
                    Description = o.Description
                })
            };
            return response;
        }

        public void InsertOrder(int userId, string desc, double total)
        {
            Context.Add(new Order
            {
                UserId = userId,
                Description = desc,
                Total = total
            });
        }
    }
}
