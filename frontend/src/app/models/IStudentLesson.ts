import { IBaseEntity } from "./IBaseEntity";
import { ILesson } from "./ILesson";
import { IStudentInformation } from "./IStudentInformation";

export interface IStudentLesson extends IBaseEntity {
    student: IStudentInformation;
    lesson: ILesson;
    mark: number;
    isAttended: boolean;
}