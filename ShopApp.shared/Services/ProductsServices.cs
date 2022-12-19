using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ShopApp.shared.Models;



namespace ShopApp.shared.Services
{
    public class ProductsServices : IProductsServices
    {
        private readonly IMongoCollection<Product> _products;
        private readonly IMongoCollection<Category> _categories;
        public ProductsServices(IOptions<ShopAppSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _products = client.GetDatabase(options.Value.DatabaseName).GetCollection<Product>(options.Value.CollectionProducts);
            _categories = client.GetDatabase(options.Value.DatabaseName).GetCollection<Category>(options.Value.CollectionCategories);
        }

       
        public async Task<IEnumerable<Product>> GetProducts() => await _products.Find(x => true).ToListAsync();
        public async Task<IEnumerable<Category>> GetCategories() => await _categories.Find(x => true).ToListAsync();
        public async Task<Category> GetCategoryById(string id) => await _categories.Find(c => c.Id == id).SingleOrDefaultAsync();
        public async Task<Product> GetProductById(string id) => await _products.Find(x => x.Id == id).FirstOrDefaultAsync();
        //public async Task CreateAsync(Product newProduct) => await _products.InsertOneAsync(newProduct);

        //Get By Movie Title
        public async Task<IEnumerable<Product>> GetByName(string keyword) => await _products.Find(p => p.ProductName.ToLower().Contains(keyword.ToLower())).ToListAsync();
        

        public async Task<Product> CreateAsync(string name, string description, string url, double price, int quantity, string category)
        {
            var product = new Product();
            product.ProductName = name;
            product.Description = description;
            product.ImageURL = url;
            product.Price = price;
            product.Quantity = quantity;
            product.Category = category;
            await _products.InsertOneAsync(product);
            return product;
        }
        public async Task Update(string id, Product updateProduct) => await _products.ReplaceOneAsync(id, updateProduct);

        //public async Task<Movie> Update(string id, Movie updateMovie) 
        //{
        //    Movie ExistingMovie = await _movies.Find(x => x.Id == id).SingleOrDefaultAsync();
        //    if (ExistingMovie != null)
        //    {
        //        ExistingMovie.Title = updateMovie.Title;
        //        ExistingMovie.Genre = updateMovie.Genre;
        //        ExistingMovie.Year = updateMovie.Year;
        //        ExistingMovie.Rate = updateMovie.Rate;
        //        ExistingMovie.Summary = updateMovie.Summary;
        //        ExistingMovie.Actors = updateMovie.Actors;
        //        ExistingMovie.ImageUrl = updateMovie.ImageUrl;
        //    }
        //    return ExistingMovie;
        //}
        public async Task Remove(string id) => await _products.DeleteOneAsync(p => p.Id == id);
    }
}
