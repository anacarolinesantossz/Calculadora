using Microsoft.AspNetCore.Mvc;
namespace CalculadoraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculadoraController : ControllerBase
    {
        [HttpGet("calcular")]
        public IActionResult Calcular(double a, double b, string op)
        {
            double resultado;
            switch (op)
            {
                case "+":
                    resultado = a + b;
                    break;
                case "-":
                    resultado = a - b;
                    break;

                case "*":
                    resultado = a * b;
                    break;

                case "/":
                    if (b == 0)
                        return BadRequest(new { mensagem = "Divisão por zero!" });

                    resultado = a / b;
                    break;
                default:
                    return BadRequest(new { mensagem = "Operação inválida!" });
            }
            return Ok(new { resultado });
        }
    }
}