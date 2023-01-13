import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Student } from '../../models/Student';

@Injectable({
    providedIn: 'root'
})
export class StudentService {


    constructor(private http: HttpClient) {}

    private baseUrl = environment.apiUrl;


    getAllStudents(): Observable<Student[]>{
        return this.http.get<Student[]>(`${this.baseUrl}/api/Student`)
    }

    getStudentById(id: number): Observable<Student>{
        return this.http.get<Student>(`${this.baseUrl}/api/Student/${id}`)
    }


    getStudentGradeByCourseId(id: number): Observable<Student[]>{
        return this.http.get<Student[]>(`${this.baseUrl}/api/Student/${id}/course`)
    }


    saveOrUpdate(student: Student){
        if(student.id){
            console.log(student)
            return this.http.put(`${this.baseUrl}/api/student/${student.id}`, student);
        }else{
            return this.http.post(`${this.baseUrl}/api/student`, student);
        }
      
    }

    
}