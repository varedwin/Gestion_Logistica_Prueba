import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Observable} from 'rxjs';
import { TipoProducto } from '../Interfaces/tipo-producto';
import { Respuesta } from '../Interfaces/respuesta';

@Injectable({
  providedIn: 'root'
})
export class TipoProductoService {

  private endpoint:string = "http://localhost:5028/api/LogisticaGeneral/"


  constructor(private http:HttpClient) { }

  add(modelo:TipoProducto):Observable<Respuesta>{

    return this.http.post<Respuesta>(this.endpoint + "GuardarTipoProducto",modelo);
  }
}
