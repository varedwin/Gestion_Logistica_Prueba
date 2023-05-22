import { Component, OnInit} from '@angular/core';
import{Cliente} from './Interfaces/cliente';
import { ClienteService } from './Services/cliente.service';
import{PlanEntrega} from './Interfaces/plan-entrega';
import { PlanEntregaService } from './Services/plan-entrega.service';
import{TipoProducto} from './Interfaces/tipo-producto';
import { TipoProductoService } from './Services/tipo-producto.service';
import { Respuesta } from './Interfaces/respuesta';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'GestionLogisticaFE';
  public mostrarCrearCliente:boolean = false;
  public mostrarConsultarCliente:boolean = false;
  public mostrarCrearTipoProducto:boolean = false;
  public mostrarCrearPlanEntrega:boolean = false;
  public mostrarResultadoCliente :boolean = false;
  public mostrarResultadoGeneral :boolean = false;
  public documentoConsulta:string = "";
  public resultadoCliente:Cliente = new Cliente();
  public dtoEnviarCliente:Cliente = new Cliente();
  public dtoPlanEntrega:PlanEntrega = new PlanEntrega();
  public dtoTipoProducto:TipoProducto = new TipoProducto();
  public respuestaServicio?:Respuesta = new Respuesta();
  public fecha : Date = new Date();
  
  constructor(
    private _clienteServicio: ClienteService, private _planEntregaServicio :PlanEntregaService, private _tipoProductoServicio:TipoProductoService){
      const now = new Date();
      this.dtoPlanEntrega.FechaEntrega = now;
      this.dtoPlanEntrega.FechaRegistro = now;
  }

  

ngOnInit(): void {
  

}

crearCliente(){
  this.mostrarCrearCliente = true;
  this.mostrarConsultarCliente = false;
  this.mostrarCrearTipoProducto = false;
  this.mostrarCrearPlanEntrega= false;
  this.mostrarResultadoCliente = false;
  this.mostrarResultadoGeneral = false;
  
}

consultarCliente(){
  this.mostrarCrearCliente = false;
  this.mostrarConsultarCliente = true;
  this.mostrarCrearTipoProducto = false;
  this.mostrarCrearPlanEntrega= false;
  this.mostrarResultadoCliente = false;
  this.mostrarResultadoGeneral = false;
}

crearTipoProducto(){
  this.mostrarCrearCliente = false;
  this.mostrarConsultarCliente = false;
  this.mostrarCrearTipoProducto = true;
  this.mostrarCrearPlanEntrega= false;
  this.mostrarResultadoCliente = false;
  this.mostrarResultadoGeneral = false;
}

crearPlanEntrega(){
  this.mostrarCrearCliente = false;
  this.mostrarConsultarCliente = false;
  this.mostrarCrearTipoProducto = false;
  this.mostrarCrearPlanEntrega= true;
  this.mostrarResultadoCliente = false;
  this.mostrarResultadoGeneral = false;
}

ocultarControles(){

  this.mostrarCrearCliente = false;
  this.mostrarConsultarCliente = false;
  this.mostrarCrearTipoProducto = false;
  this.mostrarCrearPlanEntrega= false;
  
}

obtenerCliente(){

this._clienteServicio.get(this.documentoConsulta).subscribe(
  data=> (this.resultadoCliente = data)
);

this.ocultarControles();
this.mostrarResultadoGeneral = false;
this.mostrarResultadoCliente = true;
}

guardarCliente(){

  this._clienteServicio.add(this.dtoEnviarCliente).subscribe(
    data=> (this.respuestaServicio = data)
  );
  this.ocultarControles();
  this.mostrarResultadoGeneral = true;
  this.mostrarResultadoCliente = false;
  this.dtoEnviarCliente = new Cliente()
  
  }


    guardarPlanEntrega(){
      
      this._planEntregaServicio.add(this.dtoPlanEntrega).subscribe(
        data=> (this.respuestaServicio = data)
      );
      ;
      this.ocultarControles();
      this.mostrarResultadoGeneral = true;
      this.mostrarResultadoCliente = false;
      this.dtoPlanEntrega = new PlanEntrega();
      const now = new Date();
      this.dtoPlanEntrega.FechaEntrega = now;
      this.dtoPlanEntrega.FechaRegistro = now;
    }

    guardarTipoProducto(){
      
      this._tipoProductoServicio.add(this.dtoTipoProducto).subscribe(
        data=> (this.respuestaServicio = data)
      );
      ;
      this.ocultarControles();
      this.mostrarResultadoGeneral = true;
      this.mostrarResultadoCliente = false;
      this.dtoTipoProducto = new TipoProducto();
    }

}


