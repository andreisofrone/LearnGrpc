//using MyGrpcClient;

using GrpcClient;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace Test1
{
    public static class RegisterStartupServices
    {
        public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
        {

            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();
            builder.Services.AddGrpc(opts =>
            {
                opts.EnableDetailedErrors = true;
            });
            builder.Services.AddControllers();

            builder.Services.AddGrpcClient<Greeter.GreeterClient>(o =>
            {
                o.Address = new Uri("http://host.docker.internal:5003");
            });
            builder.Services.AddGrpcClient<Calculator.CalculatorClient>(o =>
            {
                o.Address = new Uri("http://host.docker.internal:5003");
            });


            //builder.WebHost.ConfigureKestrel(options =>
            //{
            //    // gRPC
            //    options.ListenAnyIP(5001, o => o.Protocols = HttpProtocols.Http2);
            //    // HTTP
            //    options.ListenAnyIP(5000, o => o.Protocols = HttpProtocols.Http1);
            //});

            return builder;
        }
    }
}
