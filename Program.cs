using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Application.Services;
using WebApplication1.Domain.Entities;
using WebApplication1.Application.Interfaces.Services;
using WebApplication1.Infrastructure.Data;
using WebApplication1.Infrastructure.Repositories;
using WebApplication1.Infrastructure.Middlewares;
using WebApplication1.Domain.Interfaces.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình dịch vụ cho Identity
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Cấu hình DB Context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("KhiemConnection"))
);



// Đăng ký GenreService và các dịch vụ khác
builder.Services.AddScoped<IGenreService,GenreService>();
builder.Services.AddScoped<IMovieGenreService,MovieGenreService>();
builder.Services.AddScoped<IMovieService,MovieService>();
builder.Services.AddScoped<IOrderService,OrderService>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<IRoomService,RoomService>(); 
builder.Services.AddScoped<ISeatService,SeatService>();
builder.Services.AddScoped<IShowTimeService,ShowTimeService>();
builder.Services.AddScoped<ITheaterService,TheaterService>();
builder.Services.AddScoped<ITicketService,TicketService>(); 
builder.Services.AddScoped<IUserService,UserService>(); 


// Đăng ký các Repository và AutoMapper
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IMovieGenreRepository, MovieGenreRepository>();
builder.Services.AddScoped<IMovieGenreRepository, MovieGenreRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<ISeatRepository, SeatRepository>();
builder.Services.AddScoped<IShowTimeRepository, ShowTimeRepository>();
builder.Services.AddScoped<ITheaterRepository, TheaterRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Đăng ký các dịch vụ khác
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();



//middleware register
app.UseMiddleware<GlobalExceptionMiddleware>();

// Seed roles và user
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<User>>();

    try
    {
        await SeedRolesAndUsers.Initialize(roleManager, userManager);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
