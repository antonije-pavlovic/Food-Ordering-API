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
                //unitOfWork.Role.Add(new Role
                //{
                //    Name = "admin",
                //    CreatedtAt = DateTime.Now
                //});
                //unitOfWork.Role.Add(new Role
                //{
                //    Name = "user",
                //    CreatedtAt = DateTime.Now
                //});                
                // for(var i = 0; i < cats.Length; i++)
                // {
                //     var category = new Category
                //     {
                //         Name = cats[i]
                //     };
                //     unitOfWork.Category.Add(category);                    
                // }

                // #region FakeData Category and Dishes
                // //corbe             
                // dishes.Add(new Dish() {
                //     Title = "Govedja",
                //     Ingredients = "govedje meso",
                //     Price = 350.00,
                //     Serving = "500 ml",
                //     CategoryId = 1}
                // );
                // dishes.Add(new Dish()
                // {
                //     Title = "Pileca",
                //     Ingredients = "pilece meso",
                //     Price = 250.00,
                //     Serving = "450 ml",
                //     CategoryId = 1
                // }
                //);
                // dishes.Add(new Dish()
                // {
                //     Title = "Juneca",
                //     Ingredients = "junece meso",
                //     Price = 550.00,
                //     Serving = "350 ml",
                //     CategoryId = 1
                // }
                //);
                // //predjela
                // dishes.Add(new Dish()
                // {
                //     Title = "Ruska salata",
                //     Ingredients = "pilece meso,majonez,grasak",
                //     Price = 150.00,
                //     Serving = "150 gr",
                //     CategoryId = 2
                // }
                // );
                // dishes.Add(new Dish()
                // {
                //     Title = "vitaminska salata",
                //     Ingredients = "vitamini",
                //     Price = 1800.00,
                //     Serving = "50 gr",
                //     CategoryId = 2
                // }
                //);
                // dishes.Add(new Dish()
                // {
                //     Title = "Sopska salata",
                //     Ingredients = "neki sastojci",
                //     Price = 165.00,
                //     Serving = "200 gr",
                //     CategoryId = 2
                // }
                //);
                // //rostilj
                // dishes.Add(new Dish()
                // {
                //     Title = "Pecelje :)",
                //     Ingredients = "pilece meso,majonez,grasak",
                //     Price = 850.00,
                //     Serving = "350 gr",
                //     CategoryId = 3
                // }
                // );
                // dishes.Add(new Dish()
                // {
                //     Title = "Kobasice",
                //     Ingredients = "jeste i bice",
                //     Price = 550,
                //     Serving = "250 gr",
                //     CategoryId = 3
                // }
                //);
                // dishes.Add(new Dish()
                // {
                //     Title = "Cevapi",
                //     Ingredients = "meso",
                //     Price = 165.00,
                //     Serving = "450 gr",
                //     CategoryId = 3
                // }
                //);
                // //pice
                // dishes.Add(new Dish()
                // {
                //     Title = "Tubotg",
                //     Ingredients = "ladno",
                //     Price = 250.00,
                //     Serving = "0.8 l",
                //     CategoryId = 4
                // }
                //);
                // dishes.Add(new Dish()
                // {
                //     Title = "Vinjak",
                //     Ingredients = "kokain",
                //     Price = 50,
                //     Serving = "0.03 l",
                //     CategoryId = 4
                // }
                //);
                // dishes.Add(new Dish()
                // {
                //     Title = "Rakija",
                //     Ingredients = "prepecenica ljuta",
                //     Price = 00.00,
                //     Serving = "0.03 l",
                //     CategoryId = 4
                // }
                //);
                // foreach (var dish in dishes)
                // {
                //     unitOfWork.Dish.Add(dish);
                // }
                // #endregion


                unitOfWork.Save();
                Console.WriteLine("Done");
            }
        }
    }
}
