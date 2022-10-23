import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { IResponse } from './shared/wrapper/iresponse';
import { IVacancy } from './shared/wrapper/ivacancy';


@Injectable({
  providedIn: 'root'
})
export class VacancyService {
  readonly baseUrl="https://localhost:7052/api"
  constructor(private http:HttpClient, private router: Router,) {}
  getVacancyList():Observable<IResponse<IVacancy>>{
    return this.http.get<IResponse<IVacancy>>(this.baseUrl+'/Vacancies');
   }
   applyVacancy(data:any){
    return this.http.post<any>(this.baseUrl+'/JobApplications',data);
   }
}

