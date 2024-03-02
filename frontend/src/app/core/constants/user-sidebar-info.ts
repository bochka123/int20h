import { Role } from "@shared/data/roles"

export const userSidebarInfo: IUserSidebarInfo[] = [
    {
        availableRoles: [Role.admin],
        route: '/lol',
    },
    {
        availableRoles: [Role.teacher, Role.admin],
        route: '/test',
    },
    {
        availableRoles: [Role.user],
        route: '/user',
    }
]

export interface IUserSidebarInfo {
    availableRoles: Role[];
    route: string;
}