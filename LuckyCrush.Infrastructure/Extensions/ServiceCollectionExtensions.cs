using LuckyCrush.Domain.Entities.Account;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Services;
using LuckyCrush.Infrastructure.Persistence;
using LuckyCrush.Infrastructure.Repositories;
using LuckyCrush.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LuckyCrush.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("LuckyCrushDb");
        //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("Server=ouzondb.mssql.somee.com;Database=ouzondb;User Id=majdlouka_SQLLogin_1;Password=majd2003;TrustServerCertificate=True;MultipleActiveResultSets=True;"));

        var mySqlVersion = new MySqlServerVersion(new Version(8, 0, 3));
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(connectionString, mySqlVersion));

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IGlobalTypeRepository, GlobalTypeRepository>();
        services.AddScoped<IRewardRepository, RewardRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<IWheelRepository, WheelRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IPrizeRepository, PrizeRepository>();
        services.AddScoped<ISpinRepository, SpinRepository>();
        services.AddScoped<IUnlockableRepository, UnlockableRepository>();
        services.AddScoped<IRockRepository, RockRepository>();
        services.AddScoped<ILevelRepository, LevelRepository>();

        //this for identity and jwt when needed
        services.AddIdentityCore<User>(options =>
        {
            options.User.RequireUniqueEmail = true;
        })
            .AddRoles<IdentityRole>()
            .AddTokenProvider<DataProtectorTokenProvider<User>>("LuckyCrushProvider")
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
    }
}
