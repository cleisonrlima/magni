import { Course } from "./Course";

export class Student {

    constructor(){
        this.id = 0;
    }

    id: number;
    name: string;
    registrationNumber: string;
    birthDate: string;
    courseId: number;
    course: Course;
    grades: any;

}