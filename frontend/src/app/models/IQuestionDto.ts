export interface IQuestionDto{
  title: string,
  text: string,
  cost: number,
  questionOptions: IQuestionOptionDto[]
}

export interface IQuestionOptionDto {
  text: string;
  isCorrect: boolean;
}
