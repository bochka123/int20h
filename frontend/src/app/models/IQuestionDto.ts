export interface IQuestionDto{
  id?: string,
  title: string,
  text: string,
  cost: number,
  questionOptions: IQuestionOptionDto[]
}

export interface IQuestionOptionDto {
  text: string;
  isCorrect: boolean;
}
