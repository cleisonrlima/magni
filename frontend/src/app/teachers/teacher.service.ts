import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Teacher } from 'src/models/Teacher';


@Injectable({
    providedIn: 'root'
})
export class TeacherService {


    constructor(private http: HttpClient) {}

    private baseUrl = environment.apiUrl;


    getAllTeachers(): Observable<Teacher[]>{
        return this.http.get<Teacher[]>(`${this.baseUrl}/api/teacher`)
    }

    getTeacherById(id: number): Observable<Teacher>{
        return this.http.get<Teacher>(`${this.baseUrl}/api/teacher/${id}`)
    }

    saveOrUpdate(teacher: Teacher){
        if(teacher.id){
            console.log(teacher)
            return this.http.put(`${this.baseUrl}/api/teacher/${teacher.id}`, teacher);
        }else{
            return this.http.post(`${this.baseUrl}/api/teacher`, teacher);
        }
      
    }

    
}