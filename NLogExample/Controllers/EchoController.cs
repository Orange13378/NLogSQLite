using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NLogExample.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class EchoController : ControllerBase {
        private readonly ILogger<EchoController> _logger;
        public EchoController(ILogger<EchoController> logger) { 
            _logger = logger;
        }
        [HttpGet]
        public ActionResult Index() {
            _logger.LogInformation("Тестовое сообщение");
            return Ok("success");
        }
        [HttpGet("{id}")]
        public ActionResult Gets(int id) {
            int a = 90;
            try {
                return Ok(a / id);
            } catch (Exception ex) {
                _logger.LogError("Ошибка деления на ноль", ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
