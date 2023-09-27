using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Von.Crate.Core;

namespace Von.Crate.UnitTestMock.ProductApi
{
    public class ProductCrate : IRouterCrate, IServiceCrate
    {

        public void AddEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("api/name", () => {
                return ProductEndpoint.GetProductName();
            });
            app.MapPost("api/add", (string product) =>
            {
                return ProductEndpoint.AddProduct(product);
            });
        }

        public void AddService(IServiceCollection services)
        {
            //
        }
    }

    public static class ProductEndpoint
    {

        public static string GetProductName()
        {
            return "Crocodile Wallet";
        }

        public static IResult AddProduct(string product)
        {
            return Results.Accepted(product);
        }
    }
}