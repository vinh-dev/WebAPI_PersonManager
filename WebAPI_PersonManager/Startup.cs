using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAPI_PersonManager.Models;
using WebAPI_PersonManager.Models.Repository;
using WebAPI_PersonManager.Models.DataManager;


namespace WebAPI_PersonManager
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var PersonDB = "Server=.\\SQLEXPRESS;Database=QL_Person;Integrated Security=True;MultipleActiveResultSets=True";
    
            services.AddDbContext<ManagerContext>(options => options.UseSqlServer(PersonDB));

            //services.AddDbContext<ManagerContext>(opt => opt.UseInMemoryDatabase("PersonList"));
            services.AddDbContext<CustomerContext>(opt => opt.UseInMemoryDatabase("CustomerList"));
            services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("todoList"));

            services.AddCors(option => option.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCors("AllowAll");
            app.UseMvc();
        }

    }
}