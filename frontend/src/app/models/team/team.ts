import { EntityBase } from "../entitybase";

export interface Team extends EntityBase {
    name?:string; 
    createdAt:string;
}