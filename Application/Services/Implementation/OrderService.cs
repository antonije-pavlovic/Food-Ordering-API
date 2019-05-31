using Application.DTO;
using Application.Responsens;
using Application.Searches;
using Application.Services.Interfaces;
using Domain;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services.Implementation
{
    
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Delete(OrderDTO entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<OrderDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public PageResponse<OrderDTO> GetOrders(OrderSearch search, int id)
        {
            var query = _unitOfWork.Order.Find(o => o.UserId == id);

            if (search.MinTotal.HasValue)
            {
                query = query.Where(o => o.Total >= search.MinTotal);
            }

            if (search.MaxTotal.HasValue)
            {
                query = query.Where(o => o.Total <= search.MaxTotal);
            }
            var totalCount = query.Count();
            query = query.Skip((search.PageNumber - 1) * search.PerPage).Take(search.PerPage);
            var pagesCount = (int)Math.Ceiling((double)totalCount / search.PerPage);

            var response = new PageResponse<OrderDTO>
            {
                CurrentPage = search.PageNumber,
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

        public int Insert(OrderDTO entity)
        {
            var order = new Order
            {
                UserId = entity.UserId,
                Description = entity.Description,
                Total = entity.Total
            };
            _unitOfWork.Order.Add(order);
            return order.Id;
        }

        public void Update(OrderDTO entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
