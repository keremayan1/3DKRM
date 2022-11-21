using Core.Persistance.Repositories.EntityFramework;

namespace Domain.Entities
{
    public class Question : Entity
    {
        public string Id { get; set; }
        public string QuestionTitleId { get; set; }
        public string QuestionName { get; set; }
        public QuestionTitle QuestionTitle { get; set; }
        public ICollection<QuestionAnswer> QuestionAnswers { get; set; }
        public Question()
        {

        }

        public Question(string id, string questionTitleId, string questionName):this()
        {
            Id = id;
            QuestionTitleId = questionTitleId;
            QuestionName = questionName;
        }
    }
}
