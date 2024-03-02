import { Role } from "@shared/data/roles"

export const userSidebarInfo: IUserSidebarInfo[] = [
    {
        availableRoles: [Role.admin],
        route: 'lol',
        name: 'Test2',
    },
    {
        availableRoles: [Role.student, Role.teacher, Role.admin],
        route: 'tests',
        name: 'Tests',
    },
    {
        availableRoles: [Role.teacher, Role.admin],
        route: 'students',
        name: 'Students',
    }
]

export interface IUserSidebarInfo {
    availableRoles: Role[];
    route: string;
    name: string;
}
