import { IBaseEntity } from "./IBaseEntity";
import { IQuestion } from "./IQuestion";
import { ISubject } from "./ISubject";

export interface ITest extends IBaseEntity {
    questions: IQuestion[];
    title: string;
    description: string;
    subject: ISubject;
    numberOfAttempts: number;
    cost: number;
}