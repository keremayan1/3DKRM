using Application.Features.Question.DTOs;
using Application.Features.QuestionTitle.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.QuestionAnswer.DTOs
{
    public class GetQuestionAnswerDto
    {
        public GetQuestionTitleDto QuestionTitles { get; set; }
        public GetQuestionDto Questions { get; set; }
        public string QuestionsAnswer { get; set; }
    }
}
