import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { JobApplicationComponent } from '../job-application/job-application.component';

const routes: Routes = [
  {
    path: 'form/business/:id',
    component: JobApplicationComponent,

  },
  { path: '**', redirectTo:  ''},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VacancyRoutingModule { }
