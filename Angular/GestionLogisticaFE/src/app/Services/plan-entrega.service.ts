import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Observable} from 'rxjs';
import { PlanEntrega } from '../Interfaces/plan-entrega';
import { Respuesta } from '../Interfaces/respuesta';

@Injectable({
  providedIn: 'root'
})
export class PlanEntregaService {

  private endpoint:string = "http://localhost:5028/api/LogisticaPlanEntrega/"


  constructor(private http:HttpClient) { }

  add(modelo:PlanEntrega):Observable<Respuesta>{

    return this.http.post<Respuesta>(this.endpoint + "GuardarPlanEntrega",modelo);
  }
}