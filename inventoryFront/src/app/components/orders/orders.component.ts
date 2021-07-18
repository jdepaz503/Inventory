import { Component, OnInit } from '@angular/core';
import { Ordenes } from 'src/app/models/ordenes.model';
import { InventoryService } from '../../services/inventory.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html'
})
export class OrdersComponent implements OnInit {

  botonCambio:string = "Agregar nueva Orden";
  botonGuardar:string = "";
  ordenes:any[] = [];
  orden:Ordenes = new Ordenes();

  productos:any[] = [];
  estados:any[] = [{"value":"INGRESO"}, {"value":"SALIDA"}];
  seleccion:string = "";
  guardar:boolean = false;
  p:number = 1;

  constructor(private inv: InventoryService) { }

  ngOnInit(): void {
    this.inv.getOrdenes()?.subscribe((data:any) => {this.ordenes = data});
    this.inv.getProductos()?.subscribe((data:any) => {this.productos = data; });   
  }

  guardarOrden(form:NgForm){
    if (form.invalid) {return;}
    
    this.inv.postNuevaOrden(this.orden.fk_sku.sku!, this.orden.cantidad, this.orden.estado)
    ?.subscribe((data:any) => {
      this.inv.getOrdenes()?.subscribe((data:any) => {this.ordenes = data});
    })

    this.orden = new Ordenes();
    this.changeView();
  }

  anularOrden(id:number){
    console.log(id);
    
    this.inv.postAnularOrden(id)?.subscribe((data:any)=>{
      if(data!=null){
        this.inv.getOrdenes()?.subscribe((data:any) => {this.ordenes = data},
        err => console.log(err));
      }
    }, err => console.log(err));
  }

  changeView(){
    this.guardar = !this.guardar;

    if(this.botonCambio == "Regresar"){
      this.orden = new Ordenes();
    }

    if (this.guardar){
      this.botonCambio = "Regresar";
      if(this.orden.idOrden! > 0){
        this.botonGuardar = "Actualizar";
      }else{
        this.botonGuardar = "Insertar";
        // this.cleanFields();
      }
    }else{
      this.botonCambio = "Insertar nueva Orden";
    }
  }
}
