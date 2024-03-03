import { IBaseEntity } from "./IBaseEntity";
import { IStudentInformation } from "./IStudentInformation";
import { IStudentLesson } from "./IStudentLesson";
import { ISubject } from "./ISubject";
import { ITestSession } from "./ITestSession";

export interface IStudentSubject extends IBaseEntity {
    studentInformation: IStudentInformation;
    subject: ISubject;
    testSessions: ITestSession[];
    mark: number;
    isCompleted: boolean;
    attendedLessons: IStudentLesson[];
    attendencePercentage: number;
}

export interface IPinToSubject {
    email: string;
    subjectId: string;
}