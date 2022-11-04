using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Core.Tools.RabbitMQ.Messages.Users
{
    public class DeleteUsersMessage
    {
   
        public string Id { get; set; }
    }
}
