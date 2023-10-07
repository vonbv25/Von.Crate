
using Crate;

namespace TestWebHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.MapCrate();

            app.Run();
        }
    }
}
