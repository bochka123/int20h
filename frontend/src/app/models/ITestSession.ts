import { IBaseEntity } from "./IBaseEntity";
import { ISessionAnswer } from "./ISessionAnswer";
import { IStudentInformation } from "./IStudentInformation";
import { ITest } from "./ITest";

export interface ITestSession extends IBaseEntity {
    student: IStudentInformation;
    test: ITest;
    answers: ISessionAnswer[];
    mark: number;
}