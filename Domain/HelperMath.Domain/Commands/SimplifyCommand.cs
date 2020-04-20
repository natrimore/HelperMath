using HelperMath.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace HelperMath.Domain.Commands
{
    public class SimplifyCommand : ICommand
    {
        private readonly string _messageName = @"/calculate";
        private readonly ICalculateService _calculateService;
        public SimplifyCommand(ICalculateService calculateService)
        {
            _calculateService = calculateService;
        }


        public bool Contains(string messageName)
        {
            return messageName.Contains(_messageName);
        }

        public async Task Execute(Message message, ITelegramBotClient client)
        {
            var expression = message.Text.Substring(10).Trim();
            Console.WriteLine($"Expression: {expression}");
            
            var responseModel = _calculateService.Simplify(expression);

            string textMessage = $"{responseModel.Expression} ifodasini hisoblash natijasi quyidagicha: {responseModel.Result}";

            await client.SendTextMessageAsync(message.Chat.Id, textMessage, Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, null);

        }
    }
}
