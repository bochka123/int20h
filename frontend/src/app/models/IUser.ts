import { RegisterRoles } from "@shared/data/register-roles";
import { IBaseEntity } from "./IBaseEntity";

export interface IUser extends IBaseEntity {
    firstName: string;
    lastName: string;
    email?: string;
    password?: string;
    phone?: string;
    avatarUrl? : string;
}

export interface ICreateUser {
    firstName?: string;
    lastName?: string;
    email?: string;
    password?: string;
    phone?: string;
    role?: RegisterRoles | null;
}

export interface IAccessToken {
    accessToken: string;
}
