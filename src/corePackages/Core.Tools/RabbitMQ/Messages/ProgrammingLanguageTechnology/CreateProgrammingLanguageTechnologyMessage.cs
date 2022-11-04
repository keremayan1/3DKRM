using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Tools.RabbitMQ.Messages.ProgrammingLanguageTechnology
{
    public class CreateProgrammingLanguageTechnologyMessage
    {
        public int Id { get; set; }
        public string ProgrammingLanguageId { get; set; }
        public string ProgrammingLanguageName { get; set; } 
        public string ProgrammingLanguageTechnologyName { get; set; }
    }
}
