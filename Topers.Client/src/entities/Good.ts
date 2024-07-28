import { Scope } from "./Scope";

export interface Good {
    id: string;
    name: string;
    description: string;
    scopes: Scope[]
}