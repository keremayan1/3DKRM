using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Tools.RabbitMQ.Messages.ProgrammingLanguageTechnology
{
    public class UpdateProgrammingLanguageTechnologyMessage
    {
        public string Id { get; set; }
        public string ProgrammingLanguageId { get; set; }

        public string UpdatedProgrammingLanguageTechnologyName { get; set; }
    }
}
