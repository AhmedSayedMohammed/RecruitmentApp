import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { IVacancy } from '../shared/wrapper/ivacancy';
import { VacancyService } from '../main.service';
@Component({
  selector: 'app-vacancy',
  templateUrl: './vacancy.component.html',
  styleUrls: ['./vacancy.component.css']
})
export class VacancyComponent implements OnInit {
  vacancies:IVacancy[] = [] ;
  selectedVacancies: IVacancy[] = [];

  constructor(private service:VacancyService,private router:Router,private messageService:MessageService) 
  { 
  }

  ngOnInit(): void {
    this.service.getVacancyList().subscribe({
      next: (res) => {

        this.vacancies = <IVacancy[]>res.data;
          },
      error: (e) => {
            this.messageService.add({
          severity: 'error',
          detail: e.error.Message,
        });
      },
      complete: () => {
  
      },
    });
  }
  applyVacancy(id:any){
    this.router.navigate([
      `form/business/${id}`,
    ]);
    
   }

}
