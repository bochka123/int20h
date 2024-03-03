﻿namespace Int20h.Common.Dtos.Question
{
    public class QuestionDto
    {
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public List<QuestionOptionDto> QuestionOptions { get; set; }
    }
}
