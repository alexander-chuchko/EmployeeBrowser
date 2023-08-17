import { EntityBase } from "../entitybase";

export interface User extends EntityBase{
    teamId?: number;
    FirstName?: string;
    lastName?: string;
    email?: string;
    registeredAt: string;
    birthDay: string;
}
