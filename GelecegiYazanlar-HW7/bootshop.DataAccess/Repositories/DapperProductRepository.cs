using bootshop.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bootshop.DataAccess.Repositories
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection dbConnection;

        public DapperProductRepository(IConfiguration configuration)
        {
            dbConnection = new SqlConnection(configuration.GetConnectionString("db"));
        }

        public async Task<int> Add(Product entity)
        {
            var addQuery = "insert into Products (Name,Price,Discount,Description,CategoryID,ImageURL) " +
                           "values (@Name,@Price,@Discount,@Description,@CategoryID,@ImageURL)";
            await dbConnection.ExecuteAsync(addQuery, entity);
            return entity.Id;
        }

        public async Task Delete(int id)
        {
            var deleteQuery = "delete Product where Id = @Id";
            await dbConnection.ExecuteAsync(deleteQuery, new { Id = id });
        }

        public async Task<IList<Product>> GetAllEntities()
        {
            var getAllQuery = "select * from Products";
            return (IList<Product>)await dbConnection.QueryAsync<Product>(getAllQuery);
        }

        public async Task<Product> GetEntityById(int id)
        {
            var getByIdQuery = "select * from Products where Id = @Id";
            return await dbConnection.QueryFirstOrDefaultAsync<Product>(getByIdQuery, new { Id = id });
        }

        public async Task<IList<Product>> SearchProductsByName(string name)
        {
            var searchByNameQuery = "select * from Products where Name = @Name";
            return (IList<Product>)await dbConnection.QueryAsync<Product>(searchByNameQuery, new { Name = name });
        }

        public async Task<int> Update(Product entity)
        {
            var updateQuery = "update Product set Name = @Name,Price = @Price,Discount = @Discount,Description = @Description," +
                "CategoryID = @CategoryID,ImageURL = @ImageURL where Id = @Id";
            return await dbConnection.ExecuteAsync(updateQuery, entity);
        }
    }
}
