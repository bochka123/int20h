import { Role } from "@shared/data/roles"

export const userSidebarInfo: IUserSidebarInfo[] = [
    {
        availableRoles: [Role.admin],
        route: '/lol',
        name: 'Test2',
    },
    {
        availableRoles: [Role.teacher, Role.admin],
        route: '/test',
        name: 'Test3',
    },
    {
        availableRoles: [Role.user],
        route: '/user',
        name: 'Test1',
    }
]

export interface IUserSidebarInfo {
    availableRoles: Role[];
    route: string;
    name: string;
}