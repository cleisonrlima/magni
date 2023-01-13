import { Teacher } from "./Teacher";

export class Discipline {


    constructor(){
        this.id = 0;
    }

    id: number;
    name: string;
    teacherId: number;
    teacher: Teacher;
    grades: any;

}