using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Tools.RabbitMQ.Messages
{
    public class CreateProgrammingLanguageMessage
    {
        public string Id { get; set; }
        public string ProgrammingLanguageName { get; set; }
    }
}
