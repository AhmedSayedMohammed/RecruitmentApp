import{HttpClientModule} from '@angular/common/http'
import{FormsModule,ReactiveFormsModule} from '@angular/forms'
import { NgModule,CUSTOM_ELEMENTS_SCHEMA  } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { PrimengComponentsModule } from './primeng-components/primeng-components.module';
import { AppComponent } from './app.component';
import { VacancyComponent } from './vacancy/vacancy.component';
import { ConfirmationService } from 'primeng/api';
import {MessageService} from 'primeng/api';
import {ToastModule} from 'primeng/toast';
import { MainService } from './main.service';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { JobApplicationComponent } from './job-application/job-application.component';
import { LoginComponent } from './auth/login/login.component';
import { AddEditVacancyComponent } from './add-edit-vacancy/add-edit-vacancy.component';
@NgModule({
  declarations: [
    AppComponent,
    VacancyComponent,
    JobApplicationComponent,
    LoginComponent,
    AddEditVacancyComponent,
    
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
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ],
  providers: [MainService,MessageService,ConfirmationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
