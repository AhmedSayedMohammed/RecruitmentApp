import { Component, OnInit } from '@angular/core';
import { MainService } from '../main.service';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { IJobApplication } from '../shared/classes/jobApplication';
import { MessageService } from 'primeng/api';
import { IVacancy } from '../shared/wrapper/ivacancy';

@Component({
  selector: 'app-vacancy',
  templateUrl: './job-application.component.html',
  styleUrls: ['./job-application.component.css']
})

export class JobApplicationComponent implements OnInit {
  vacancy$:IVacancy= {} as IVacancy
  jobApp: IJobApplication = {} as IJobApplication;
  id:any
   jobForm = new FormGroup({
    name: new FormControl(''),
    email: new FormControl(''),
    mobile: new FormControl(''),
  });
  constructor(private service:MainService,private route:ActivatedRoute,private messageService:MessageService) 
  {
 
  }
  applyVacancy(form:FormGroup){
    this.id = this.route.snapshot.paramMap.get('id');
    this.jobApp.email=form.value.email
    this.jobApp.mobile=form.value.mobile
    this.jobApp.name=form.value.name
    this.jobApp.vacancyId=this.id
    console.log(this.id)
    console.log(form.value)
  
   this.service.applyVacancy(this.jobApp).subscribe({
    next: (res) => {

      console.log(res)  
        },
    error: (e) => {
      console.log(e)
      this.messageService.add({
        severity: 'error',
        detail: e.error.Message,
      });
    },
    complete: () => {
      this.messageService.add({
        severity: 'message',
        detail: "Applied Successfully",
      });
    },
  });
    
   }
  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id');
    this.service.getVacancyById(this.id).subscribe({
      next: (res) => {

        this.vacancy$ = <IVacancy>res.data;
        console.log(this.vacancy$)
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

}
