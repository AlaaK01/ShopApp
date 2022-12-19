using Microsoft.AspNetCore.Mvc;
using ShopApp.shared.Dtos;
using ShopApp.shared.Models;

namespace ShopApp.server.Extension
{
    public static class DtoConversion
    {

        public static IEnumerable<ProductDto> ConvertToDto(this IEnumerable<Product> products)
        {
            return (from product in products
                   
                    select new ProductDto
                    {
                        Id = product.Id,
                        ProductName = product.ProductName,
                        Description = product.Description,
                        ImageUrl = product.ImageURL,
                        Price = product.Price,
                        Qty = product.Quantity,
                        Category = product.Category
                    }).ToList();
        }
        //public static IEnumerable<ProductDto> ConvertToDto(this IEnumerable<Product> products, IEnumerable<Category> categories)
        //{
        //    return (from product in products
        //            join category in categories 
        //            on product.Category equals category.CategoryName
        //            select new ProductDto
        //            {
        //                Id= product.Id,
        //                ProductName= product.ProductName,
        //                Description= product.Description,
        //                ImageUrl = product.ImageURL,
        //                Price= product.Price,
        //                Qty = product.Quantity,
        //                Category = product.Category
        //            }).ToList();
        //}

        public static ProductDto ConvertToDto(this Product product)
        {
            return new ProductDto
                    {
                        Id =product.Id,
                        ProductName = product.ProductName,
                        Description = product.Description,
                        ImageUrl = product.ImageURL,
                        Price = product.Price,
                        Qty = product.Quantity,
                        Category = product.Category,
                        
                    };
        }


        public static IEnumerable<ItemCartDto> ConvertToDto(this IEnumerable<Item> items, IEnumerable<User> users, IEnumerable<Product> products)
        {
            return (from item in items
                    join user in users
                    on item.UserId equals user.Id
                    join product in products
                    on item.ProductId equals product.Id
                    select new ItemCartDto
                    {
                        Id = item.Id,
                        ProductName = product.ProductName,
                        UserName = user.UserName,
                        Description = product.Description,
                        ImageURL = product.ImageURL,
                        Price = product.Price,
                        Quantity = item.Quantity,
                        TotalPrice = item.Quantity * product.Price,
                    }).ToList();
        }

        public static ItemCartDto ConvertToDto(this Item item, User user, Product product)
        {
            return new ItemCartDto
            {
                Id = item.Id,
                ProductName = product.ProductName,
                UserName = user.UserName,
                Description = product.Description,
                ImageURL = product.ImageURL,
                Price = product.Price,
                Quantity = item.Quantity,
                TotalPrice = item.Quantity * product.Price,
            };
        }
    }
}
