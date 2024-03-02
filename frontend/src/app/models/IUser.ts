import { RegisterRoles } from "@shared/data/register-roles";

export interface IUser {
    firstName: string;
    lastName: string;
    email?: string;
    password?: string;
    phone?: string;
    avatarUrl? : string;
    role?: RegisterRoles;
}

export interface IAccessToken {
    accessToken: string;
}
