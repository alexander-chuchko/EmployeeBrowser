import { EntityBase } from "../entitybase";

export interface Project extends EntityBase {
    userId?: number;
    teamId?: number;
    name?: string;
    description?: string;
    createdAt: string;
    deadline: string;
}