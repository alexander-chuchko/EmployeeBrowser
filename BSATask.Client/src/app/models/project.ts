import { EntityBaseDTO } from "./entitybase";

export interface ProjectDTO extends EntityBaseDTO {
    userId?: number;
    teamId?: number;
    name?: string;
    description?: string;
    createdAt: string;
    deadline: string;
}