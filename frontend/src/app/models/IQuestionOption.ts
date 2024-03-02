import { IBaseEntity } from "./IBaseEntity";
import { IQuestion } from "./IQuestion";

export interface IQuestionOption extends IBaseEntity {
    isCorrect: boolean;
    text: string;
    question: IQuestion;
}