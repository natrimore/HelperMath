using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelperMath.Domain.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace HelperMath.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BotController : ControllerBase
    {
        private readonly IEnumerable<ICommand> _commands;
        private readonly ITelegramBotClient _client;
        public BotController(IEnumerable<ICommand> commands, ITelegramBotClient client)
        {
            _commands = commands;
            _client = client;
        }

        [HttpGet("Get")]
        public IActionResult Get()
        {
            return Ok("hello");
        }



        [HttpPost("update")]
        public IActionResult Update([FromBody] Update update)
        {
            if (update == null) return Ok();

            var message = update.Message;

            foreach (var command in _commands)
            {
                if (command.Contains(message.Text))
                {
                    command.Execute(message, _client);
                }
            }

            return Ok();
        }
    }
}