import { Student } from "./Student";

export class Course {


    constructor(){
        this.id = 0;
    }


    id: number;
    name: string;
    courseDisciplines: any
    students: Student[]

}