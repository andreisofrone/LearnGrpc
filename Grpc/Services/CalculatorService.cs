using Grpc.Core;

namespace Grpc.Services
{
    public class CalculatorService : Calculator.CalculatorBase
    {
        private readonly ILogger<GreeterService> _logger;
        public CalculatorService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<SumResponse> Sum(SumRequest request, ServerCallContext context)
        {
            return Task.FromResult(new SumResponse
            {
                Message = request.FirstNumber + request.SecondNumber
            });
        }
    }
}