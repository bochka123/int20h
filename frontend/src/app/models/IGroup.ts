import { IBaseEntity } from "./IBaseEntity";
import { IStudentInformation } from "./IStudentInformation";
import { ITeacherInformation } from "./ITeacherInformation";

export interface IGroup extends IBaseEntity {
    name?: string;
    students?: IStudentInformation[];
    mentor?: ITeacherInformation;
    year?: number;
    mentorEmail?: string;
}
