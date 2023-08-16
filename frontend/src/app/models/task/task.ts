import { EntityBase } from "../entitybase";
import { TaskState } from "../enum/task-state";

export interface Task extends EntityBase{
    projectId?: number;
    userId?: number;
    name: string;
    description?: string;
    state: TaskState;
    createdAt: string;
    finishedAt?: string;
}