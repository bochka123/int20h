import { IBaseEntity } from "./IBaseEntity";
import { ISubject } from "./ISubject";

export interface ILesson extends IBaseEntity {
    subject: ISubject;
    topic: string;
}