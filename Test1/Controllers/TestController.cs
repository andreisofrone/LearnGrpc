using GrpcClient;
using Microsoft.AspNetCore.Mvc;

namespace MyGrpc.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly Greeter.GreeterClient _greeterClient;
        private readonly Calculator.CalculatorClient _calculatorClient;
        public TestController(ILogger<TestController> logger, Greeter.GreeterClient client, Calculator.CalculatorClient calculatorClient)
        {
            _logger = logger;
            _greeterClient = client;
            _calculatorClient = calculatorClient;
        }

        [HttpGet(Name = "Test")]
        public async Task<IActionResult> Get()
        {
            var reply = await _greeterClient.SayHelloAsync(new HelloRequest { Name = "gRPC Demo" });

            return Ok(reply.Message);
        }

        [HttpGet]
        [Route("test-message")]
        public async Task<IActionResult> GetTestMessage()
        {
            return Ok("Here am I.");
        }

        [HttpPost]
        [Route("calculate/{first}/{second}")]
        public async Task<IActionResult> Calculate(int first, int second)
        {
            var reply = await _calculatorClient.SumAsync(new SumRequest()
            {
                FirstNumber = first,
                SecondNumber = second
            });

            return Ok(reply.Message);
        }
    }
}