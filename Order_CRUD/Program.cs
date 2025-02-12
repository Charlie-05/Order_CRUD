
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Order_CRUD.Database;
using Order_CRUD.IRepositories;
using Order_CRUD.IServices;
using Order_CRUD.Repositories;
using Order_CRUD.Services;

namespace Order_CRUD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDBcontext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<ICustomerRepository , CustomerRepository>();    
            builder.Services.AddScoped<ICustomerService , CustomerService>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]));

            builder.Services.AddAuthentication()
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = key,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                });
            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy(
                    name: "CORSPolicy",
                    builder =>
                    {
                        builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                    }
                    );
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("CORSPolicy");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
