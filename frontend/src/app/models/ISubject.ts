import { IBaseEntity } from "./IBaseEntity";
import { ILesson } from "./ILesson";
import { IStudentSubject } from "./IStudentSubject";
import { ITeacherInformation } from "./ITeacherInformation";
import { ITest } from "./ITest";

export interface ISubject extends IBaseEntity {
    name: string;
    studentSubjects?: IStudentSubject[];
    teachers?: ITeacherInformation[];
    lessons?: ILesson[];
    tests?: ITest[];
    mainTeacherEmail?: string;
}
