import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { ClienteService } from './Services/cliente.service';
import { PlanEntregaService } from './Services/plan-entrega.service';
import { TipoProductoService } from './Services/tipo-producto.service';
import {FormsModule} from '@angular/forms';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
    
  ],
  providers: [ClienteService,PlanEntregaService,TipoProductoService],
  bootstrap: [AppComponent],
  
})
export class AppModule { }