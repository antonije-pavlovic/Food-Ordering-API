using Application.DTO;
using Application.Services.Interfaces;
using Domain;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services.Implementation
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderService _orderService;
        private readonly ITransactionService _transactionService;
        private readonly IDishService _dishService;

        public CartService(IUnitOfWork unitOfWork, IOrderService orderService, ITransactionService transactionService, IDishService dishService)
        {
            _unitOfWork = unitOfWork;
            _orderService = orderService;
            _transactionService = transactionService;
            _dishService = dishService;
        }

        public bool CheckItemExist(int userId, int itemId)
        {
            var item = _unitOfWork.Cart.Find(c => c.UserId == userId && c.Id == itemId).FirstOrDefault();
           return item != null;
        }

        public void Delete(CartDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(InsertCartDTO entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            var item = _unitOfWork.Cart.Get(id);
            _unitOfWork.Cart.Remove(item);
            _unitOfWork.Save();
        }       

        public IQueryable<CartDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public CartDTO GetById(int id)
        {
            throw new NotImplementedException();
        }    

        public int Insert(InsertCartDTO dto, int id)
        {
            var dish = _unitOfWork.Dish.Get(dto.DishId);
            if (dish == null)
                throw new Exception("Dish doesnt exist");
            var cart = new Cart
            {
                DishId = dto.DishId,
                UserId = id,
                Quantity = dto.Quantity,
                Sum = dto.Quantity * dish.Price
            };
            _unitOfWork.Cart.Add(cart);
            _unitOfWork.Save();
            return cart.Id;
        }      

        public int Insert(InsertCartDTO entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CartDTO> ListCart(int id)
        {
            var orders = _unitOfWork.Cart.FindByExpression(c => c.UserId == id).Select(c => new CartDTO()
            {
                DishName = c.Dish.Title,
                DishPrice = c.Dish.Price,
                Quantity = c.Quantity,
                Sum = c.Sum
            });
            if (!orders.ToList().Any())
            {
                throw new Exception("Your cart is empty!");
            }
            return orders;
        }

        public void Purchase(int id)
        {
            var cartItems = _unitOfWork.Cart.GetAll().Where(c => c.UserId == id).Select(c => new CartDTO
            {
                Id = c.Id,
                DishName = c.Dish.Title,
                Quantity = c.Quantity,
                DishPrice = c.Dish.Price,
                Sum = c.Sum
            }).ToList();

            if (!cartItems.Any())
                throw new Exception("There is no items in cart");
            var overall = 0.0;
            var desc = "";
            foreach (var item in cartItems)
            {
                desc += item.DishName + " " + item.DishPrice + ", " + item.Quantity + ", sum= " + item.Sum;
                overall = overall + item.Sum;
            }
            var availableMoney = _unitOfWork.Wallet.Find(w => w.UserId == id).First();
            if (availableMoney.Balance < overall)
            {
               throw new Exception("You dont have enough money in your wallet,please charge it");
            }
            var order = new OrderDTO
            {
                UserId = id,
                Description = desc,
                Total = overall
            };
            _orderService.Insert(order);
            foreach (var item in cartItems)
            {
                this.DeleteById(item.Id);
            }
            availableMoney.Balance = availableMoney.Balance - overall;
            _transactionService.Insert(new TransactionDTO
            {
                Amount = overall,
                WalletId = availableMoney.Id,
                Type = "outcome"                
            });
            _unitOfWork.Save();
        }        

        public void Update(UpdateCartDTO entity, int id)
        {
            var cart = _unitOfWork.Cart.Get(id);
            var dish = _dishService.GetById(cart.DishId);
            cart.Quantity = entity.Quantity;
            cart.Sum = cart.Quantity * dish.Price;
            _unitOfWork.Save();
        }

        public void Update(InsertCartDTO entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
