using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Telegram.Bot.Types;

using Message = Telegram.Bot.Types.Message;

namespace InterviewHelper.Services.DTOs
{
    public class ChatMessage
    {
        private readonly ChatUser _user;
        private readonly string _text;
        private readonly Message _message;
        public ChatMessage(Update update)
        {
            if (update is null)
            {
                throw new ArgumentNullException(nameof(update));
            }
            _user = new ChatUser(update);
            _text = update?.Message?.Text ?? "";
            _message = update?.Message;
        }

        public ChatUser GetCurrentUser() => _user;
        public Message GetCurrentMessage() => _message;
        public string GetCurrentMessageText() => _text ?? "";
    }
}
