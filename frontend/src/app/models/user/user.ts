import { EntityBase } from "../entitybase";

export interface User extends EntityBase{
    teamId?: number;
    firstName?: string;
    lastName?: string;
    email?: string;
    registeredAt: string;
    birthDay: string;
}
