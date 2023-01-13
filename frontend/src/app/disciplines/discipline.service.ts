import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Discipline } from 'src/models/Discipline';

@Injectable({
    providedIn: 'root'
})
export class DisciplineService {


    constructor(private http: HttpClient) {}

    private baseUrl = environment.apiUrl;


    getAllDisciplines(): Observable<Discipline[]>{
        return this.http.get<Discipline[]>(`${this.baseUrl}/api/discipline`)
    }

    getDisciplineById(id: number): Observable<Discipline>{
        return this.http.get<Discipline>(`${this.baseUrl}/api/discipline/${id}`)
    }

    saveOrUpdate(discipline: Discipline){
        if(discipline.id){
            console.log(discipline)
            return this.http.put(`${this.baseUrl}/api/discipline/${discipline.id}`, discipline);
        }else{
            return this.http.post(`${this.baseUrl}/api/discipline`, discipline);
        }
      
    }

    
}