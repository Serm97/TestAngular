import { Roles } from './roles';

export class User {

    id: number;
    username: string;
    name: String;
    roles: Roles[];
    active: boolean = false;

}
