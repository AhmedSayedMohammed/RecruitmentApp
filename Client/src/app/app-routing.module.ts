import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddEditVacancyComponent } from './add-edit-vacancy/add-edit-vacancy.component';
import { LoginComponent } from './auth/login/login.component';
import { JobApplicationComponent } from './job-application/job-application.component';
import { VacancyComponent } from './vacancy/vacancy.component';


const routes: Routes = [
  {path:'form/job/:id', component:JobApplicationComponent},
  {path:'admin', component:LoginComponent},
  {path:'vacancies', component:VacancyComponent},
  {path:'vacancies/form/vacancy/edit/:id', component:AddEditVacancyComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
