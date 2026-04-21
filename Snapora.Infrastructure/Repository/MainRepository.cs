using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SocialMedia.Infrastructure.Persistence.Context;
using System.Data.Common;
using static Dapper.SqlMapper;

namespace SocialMedia.Infrastructure.Repository
{
    public class MainRepository<TEnity> : IMainRepository<TEnity> where TEnity : class
    {
        private readonly Persistence.Context.AppdbContext _context;
        private readonly DbSet<TEnity> _dbSet;
        private readonly IConfiguration _configuration;
        private readonly DbConnection connection;


        public MainRepository(Persistence.Context.AppdbContext context, IConfiguration configuration)
        {
            this._context = context;
            this._dbSet = context.Set<TEnity>();
            this._configuration = configuration;
            connection = _context.Database.GetDbConnection();
        }

        public async ValueTask<string> CreateAsync(TEnity entity)
        {
            var tableName = typeof(TEnity).Name;
            var properities = typeof(TEnity).GetProperties();
            var columns = string.Join(",", properities.Select(p=>p.Name));
            var values = string.Join(",", properities.Select(p => "@" + p.Name));

            var sql = $"INSERT INTO{tableName} ({columns})VALUES ({values}) ";

            var result = await connection.ExecuteAsync(sql,entity);
            
             return result > 0 ? "Created" : "Failed";
        }

        public async ValueTask<string> DeleteAsync(Guid id)
        {
            var tableName = typeof(TEnity).Name;
            var sql = $"DELETE FROM {tableName} WHERE Id =@Id";
            var result=await connection.ExecuteAsync(sql, id);
            //what if it is not found?
            return result > 0 ? "Deleted" : "Failed";
        }

        public async ValueTask<IEnumerable<TEnity>> GetAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async ValueTask<TEnity> GetAsync(Guid id)
        {
            var Sql = "SELECT * FROM " + typeof(TEnity).Name + " WHERE ID = @Id";
               return  await connection.QuerySingleOrDefaultAsync<TEnity>(Sql, new { Id  = id});
            
        }

        public async ValueTask<string> UpdateAsync(TEnity entity, Guid id)
        {
            var tableName= typeof(TEnity).Name;
            var sql = $"UPDATE {tableName} where Id=@Id";
            var oldEntity = await _dbSet.FindAsync(id);
            var result= await connection.ExecuteAsync(sql, entity);
            return result > 0 ? "Updated" : "Failed";
        }

    }
}
