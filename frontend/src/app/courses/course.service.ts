import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Course } from 'src/models/Course';
import { Discipline } from 'src/models/Discipline';

@Injectable({
    providedIn: 'root'
})
export class CourseService {


    constructor(private http: HttpClient) {}

    private baseUrl = environment.apiUrl;


    getAllCourses(): Observable<Course[]>{
        return this.http.get<Course[]>(`${this.baseUrl}/api/Course`)
    }

    getCourseById(id: number): Observable<Course>{
        return this.http.get<Course>(`${this.baseUrl}/api/Course/${id}`)
    }


    getCourseResumeById(id: number): Observable<Discipline>{
        return this.http.get<Discipline>(`${this.baseUrl}/api/Course/resume/${id}`)
    }

    saveOrUpdate(course: Course){
        if(course.id){
            console.log(course)
            return this.http.put(`${this.baseUrl}/api/Course/${course.id}`, course);
        }else{
            return this.http.post(`${this.baseUrl}/api/Course`, course);
        }
      
    }

    
}