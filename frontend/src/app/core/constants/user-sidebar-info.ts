import { Role } from "@shared/data/roles"

export const userSidebarInfo: IUserSidebarInfo[] = [
    {
        availableRoles: [Role.student, Role.teacher, Role.admin],
        route: 'tests',
        name: 'Tests',
    },
    {
      availableRoles: [Role.student, Role.teacher, Role.admin],
      route: 'groups',
      name: 'Groups and subjects',
    },
    {
        availableRoles: [Role.teacher, Role.admin],
        route: 'students',
        name: 'Students',
    },
    {
      availableRoles: [Role.admin],
      route: 'groups/create-group',
      name: 'Create Group',
    },
    {
      availableRoles: [Role.admin],
      route: 'groups/create-subject',
      name: 'Create Subject',
    },
    {
      availableRoles: [Role.admin],
      route: 'teachers',
      name: 'Teachers',
    }
]

export interface IUserSidebarInfo {
    availableRoles: Role[];
    route: string;
    name: string;
}
