import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Observable} from 'rxjs';
import { Cliente } from '../Interfaces/cliente';
import { Respuesta } from '../Interfaces/respuesta';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  private endpoint:string = "http://localhost:5028/api/LogisticaGeneral/"


  constructor(private http:HttpClient) { }

  get(documento:string):Observable<Cliente>{

    return this.http.get<Cliente>(this.endpoint + "ConsultarCliente?documento="+documento);
  }

  add(modelo:Cliente):Observable<Respuesta>{

    return this.http.post<Respuesta>(this.endpoint + "GuardarCliente",modelo);
  }

}