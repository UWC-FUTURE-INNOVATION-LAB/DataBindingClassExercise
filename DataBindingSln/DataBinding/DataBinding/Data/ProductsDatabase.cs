using System.Collections.Generic;
using System.Threading.Tasks;
using DataBinding.Models;
using SQLite;
using System.Linq;

namespace DataBinding.Data
{
    public class ProductsDatabase
    {
        private SQLiteAsyncConnection database;

        public ProductsDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Product>().Wait();


            SeedData();
        }

        public Task<List<Product>> GetProducts()
        {
            return database.Table<Product>().ToListAsync();
        }

        public async Task<Product> GetLatestProduct()
        {
            int count = await database.Table<Product>().CountAsync();
            var latest = await database.Table<Product>().Where(x => x.Id == count).FirstOrDefaultAsync();

            return latest;
        }

       public void DeleteProduct(Product product)
       {
            database.DeleteAsync(product);
       }

        public async void UpdateProduct(Product product)
        {

            await database.UpdateAsync(product);
         
        }

        private async void SeedData()
        {
            if (await database.Table<Product>().CountAsync() == 0)
            {
                var product = new Product
                {
                    Name = "Xamarin",
                    Price = 500,
                    Category = "Software"
                };

                await database.InsertAsync(product);

                 product = new Product
                {
                    Name = "Banana",
                    Price = 10,
                    Category = "Fruit"
                };

                await database.InsertAsync(product);

                product = new Product
                {
                    Name = "Pumpkin",
                    Price = 40,
                    Category = "Vegetable"
                };

                await database.InsertAsync(product);

                product = new Product
                {
                    Name = "TV",
                    Price = 5999,
                    Category = "Electronics"
                };

                await database.InsertAsync(product);

            }


        }
    }
}

