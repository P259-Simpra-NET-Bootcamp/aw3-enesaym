using SimApiHw.Data.Repository;
using SimApiHw.Data;


namespace SimApiHw.Service.Extensions;

public static class RepositoryExtension
{
    public static void SimRepositoryExtension(this IServiceCollection services)
    {

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

    }
}
