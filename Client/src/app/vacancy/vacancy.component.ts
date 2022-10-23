import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { IVacancy } from '../shared/wrapper/ivacancy';
import { MainService } from '../main.service';
import { AuthService } from '../auth.service';
@Component({
  selector: 'app-vacancy',
  templateUrl: './vacancy.component.html',
  styleUrls: ['./vacancy.component.css']
})
export class VacancyComponent implements OnInit {
  vacancies:IVacancy[] = [] ;
  selectedVacancies: IVacancy[] = [];
  admin!:boolean;
  constructor(private service:MainService,private authService:AuthService,private router:Router,private messageService:MessageService) 
  { 
  }

  ngOnInit(): void {
   if(this.authService.getUserFromSessionStorage()!=null && this.authService.getUserFromSessionStorage()?.isAdmin)
   {
    this.admin=true;
   }
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
