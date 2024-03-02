import { IBaseEntity } from "./IBaseEntity";
import { IGroup } from "./IGroup";
import { IStudentSubject } from "./IStudentSubject";
import { IUser } from "./IUser";

export interface IStudentInformation extends IBaseEntity {
    user: IUser;
    isVerified: boolean;
    group: IGroup;
    studentSubjects: IStudentSubject[];
}