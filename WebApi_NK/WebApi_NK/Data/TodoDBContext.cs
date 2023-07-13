using Microsoft.EntityFrameworkCore;
using WebApi_NK.Models;

namespace WebApi_NK.Data
{
    public class TodoDBContext : DbContext
    {

        public TodoDBContext(DbContextOptions<TodoDBContext> options):base(options)
        {
            
        }


        public DbSet<TodoItem> TodoItems =>Set<TodoItem>(); 


    }
}
