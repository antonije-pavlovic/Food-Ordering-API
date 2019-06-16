using Application.Services;
using DataAccess;
using Domain;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;

namespace FakeData
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var unitOfWork = new UnitOfWork(new RestaurantContext()))
            {
                //adding Categories
                List<Dish> dishes = new List<Dish>();
                string[] cats = new String[] { "Corbe","Salate","Rostil","Pice" };
                //roles
                unitOfWork.Role.Add(new Role
                {
                    Name = "admin",
                    CreatedtAt = DateTime.Now
                });
                unitOfWork.Role.Add(new Role
                {
                    Name = "user",
                    CreatedtAt = DateTime.Now
                });
                unitOfWork.Save();
                //categories
                for (var i = 0; i < cats.Length; i++)
                {
                    var category = new Category
                    {
                        Name = cats[i]
                    };
                    unitOfWork.Category.Add(category);
                }
                unitOfWork.Save();
                //users
                unitOfWork.User.Add(new User
                {
                    CreatedtAt = DateTime.Now,
                    Email = "admin@admin.com",
                    FirstName = "Admin",
                    IsDeleted = 0,
                    LastName = "Admin",
                    Password = Compute256Hash.ComputeSha256Hash("admin"),
                    RoleId = 1
                });

                unitOfWork.User.Add(new User
                {
                    CreatedtAt = DateTime.Now,
                    Email = "korisnik@korisnik.com",
                    FirstName = "Korinsik",
                    IsDeleted = 0,
                    LastName = "Korisnik",
                    Password = Compute256Hash.ComputeSha256Hash("korisnik"),
                    RoleId = 2                    
                });

                unitOfWork.Wallet.Add(new Wallet
                {
                    UserId = 1,
                    Balance = 0.00
                });
                unitOfWork.Wallet.Add(new Wallet
                {
                    UserId = 2,
                    Balance = 0.00
                });
                #region FakeData Category and Dishes
                //corbe             
                dishes.Add(new Dish()
                {
                    Title = "Govedja",
                    Ingredients = "govedje meso",
                    Price = 350.00,
                    Serving = "500 ml",
                    Image = "govedja-corba.jpg",
                    CategoryId = 1
                }
                );
                dishes.Add(new Dish()
                {
                    Title = "Pileca",
                    Ingredients = "pilece meso",
                    Price = 250.00,
                    Serving = "450 ml",
                    Image = "pileca-corba.jpg",
                    CategoryId = 1
                }
               );
                dishes.Add(new Dish()
                {
                    Title = "Juneca",
                    Ingredients = "junece meso",
                    Price = 550.00,
                    Serving = "350 ml",
                    Image = "juneca-corba.jpg",
                    CategoryId = 1
                }
               );
                //predjela
                dishes.Add(new Dish()
                {
                    Title = "Ruska salata",
                    Ingredients = "pilece meso,majonez,grasak",
                    Price = 150.00,
                    Serving = "150 gr",
                    Image = "ruska-salata.jpg",
                    CategoryId = 2
                }
                );
                dishes.Add(new Dish()
                {
                    Title = "vitaminska salata",
                    Ingredients = "vitamini",
                    Price = 1800.00,
                    Serving = "50 gr",
                    Image = "vitaminska_salata.jpg",
                    CategoryId = 2
                }
               );
                dishes.Add(new Dish()
                {
                    Title = "Sopska salata",
                    Ingredients = "neki sastojci",
                    Price = 165.00,
                    Serving = "200 gr",
                    Image = "sopska-salata.jpg",
                    CategoryId = 2
                }
               );
                //rostilj
                dishes.Add(new Dish()
                {
                    Title = "Pecelje :)",
                    Ingredients = "pilece meso,majonez,grasak",
                    Price = 850.00,
                    Serving = "350 gr",
                    Image = "pecenje.jpg",
                    CategoryId = 3
                }
                );
                dishes.Add(new Dish()
                {
                    Title = "Kobasice",
                    Ingredients = "jeste i bice",
                    Price = 550,
                    Serving = "250 gr",
                    Image = "kobasice.jpg",
                    CategoryId = 3
                }
               );
                dishes.Add(new Dish()
                {
                    Title = "Cevapi",
                    Ingredients = "meso",
                    Price = 165.00,
                    Serving = "450 gr",
                    Image = "cevapi.jpg",
                    CategoryId = 3
                }
               );
                //pice
                dishes.Add(new Dish()
                {
                    Title = "Tubotg",
                    Ingredients = "ladno",
                    Price = 250.00,
                    Serving = "0.8 l",
                    Image = "tuborg.jpg",
                    CategoryId = 4
                }
               );
                dishes.Add(new Dish()
                {
                    Title = "Vinjak",
                    Ingredients = "kokain",
                    Price = 50,
                    Serving = "0.03 l",
                    Image = "vinjak.jpg",
                    CategoryId = 4
                }
               );
                dishes.Add(new Dish()
                {
                    Title = "Rakija",
                    Ingredients = "prepecenica ljuta",
                    Price = 00.00,
                    Serving = "0.03 l",
                    Image = "rakija.jpg",
                    CategoryId = 4
                }
               );
                foreach (var dish in dishes)
                {
                    unitOfWork.Dish.Add(dish);
                }
                #endregion


                unitOfWork.Save();
                Console.WriteLine("Done");
            }
        }
    }
}
