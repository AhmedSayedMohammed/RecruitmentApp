import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { MessageService } from 'primeng/api';
import { MainService } from '../main.service';
import { IVacancy } from '../shared/wrapper/ivacancy';

@Component({
  selector: 'app-add-edit-vacancy',
  templateUrl: './add-edit-vacancy.component.html',
  styleUrls: ['./add-edit-vacancy.component.css']
})
export class AddEditVacancyComponent implements OnInit {
  id!:any
  vacancy$:IVacancy= {} as IVacancy
 appForm = new FormGroup({
    name: new FormControl(''),
    responsibilities: new FormControl(''),
    jobCategory: new FormControl(''),
    skills: new FormControl(''),
  });
  constructor(private service:MainService,private route:ActivatedRoute,private messageService:MessageService) { }
  editvacancy(form:FormGroup){
    this.id = this.route.snapshot.paramMap.get('id');
    this.vacancy$.name=form.value.name
    this.vacancy$.skills=form.value.skills
    this.vacancy$.responsibilities=form.value.responsibilities
    this.vacancy$.jobCategory=form.value.jobCategory
    console.log(this.id)
    console.log(form.value)
  
   this.service.editVacancy(this.vacancy$).subscribe({
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
