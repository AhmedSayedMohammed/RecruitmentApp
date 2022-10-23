import{HttpClientModule} from '@angular/common/http'
import{FormsModule,ReactiveFormsModule} from '@angular/forms'
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { PrimengComponentsModule } from './primeng-components/primeng-components.module';
import { AppComponent } from './app.component';
import { VacancyComponent } from './vacancy/vacancy.component';
import { ConfirmationService } from 'primeng/api';
import {MessageService} from 'primeng/api';
import {ToastModule} from 'primeng/toast';
import { VacancyService } from './main.service';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { JobApplicationComponent } from './job-application/job-application.component';
@NgModule({
  declarations: [
    AppComponent,
    VacancyComponent,
    JobApplicationComponent
    
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    PrimengComponentsModule,
    ToastModule,
    AppRoutingModule,
    BrowserAnimationsModule,

    
  ],

  providers: [VacancyService,MessageService,ConfirmationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
