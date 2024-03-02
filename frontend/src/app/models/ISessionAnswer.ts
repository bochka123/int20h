import { IBaseEntity } from "./IBaseEntity";
import { IQuestionOption } from "./IQuestionOption";
import { ITestSession } from "./ITestSession";

export interface ISessionAnswer extends IBaseEntity {
    answer: IQuestionOption;
    session: ITestSession;
    isCorrect: boolean;
}