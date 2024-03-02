import { IBaseEntity } from "./IBaseEntity";
import { IQuestionOption } from "./IQuestionOption";
import { ITest } from "./ITest";

export interface IQuestion extends IBaseEntity {
    title: string;
    text: string;
    test: ITest;
    questionOptions: IQuestionOption[];
    cost: number;
}