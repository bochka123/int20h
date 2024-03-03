import { IBaseEntity } from "./IBaseEntity";
import { IGroup } from "./IGroup";
import { ISubject } from "./ISubject";
import { IUser } from "./IUser";

export interface ITeacherInformation extends IBaseEntity {
    user: IUser;
    isVerified: boolean;
    mentorGroups: IGroup[];
    subjects: ISubject;
}