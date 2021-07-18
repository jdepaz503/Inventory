import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Productos } from 'src/app/models/producto.model';
import { InventoryService } from '../../services/inventory.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html'
})
export class ProductsComponent implements OnInit {

  botonCambio:string = "Agregar nuevo Producto";
  botonGuardar:string = "";
  productos:any[] = [];
  producto:Productos = new Productos();
  idProducto:string = "";
  guardar:boolean = false;

  p:number = 1;

  constructor(private inv: InventoryService) { }

  ngOnInit(): void {
    this.inv.getProductos()?.subscribe((data:any) => {this.productos = data; });    
  }

  buscarProducto(form:NgForm){

    if (form.invalid) {return;}
    
    if (Number(this.idProducto)! > 0 ){
      this.inv.getProducto(Math.round(Number(this.idProducto)))?.subscribe((data:any) => {        
        this.productos = [];
        this.productos.push(data);
      });
    }else{
      this.inv.getProductos()?.subscribe((data:any) => {this.productos = data; });    
    }
  };

  guardarProducto(form:NgForm){
  if (form.invalid) {return;}

  if (this.producto.sku! > 0){
    this.inv.putActualizarProducto(this.producto.sku!,this.producto.descripcion)?.subscribe((data:any) => {
      if(data != null){
        console.log("Edición correcta");      
      }else{
        console.log("Error");      
      }
  
      this.inv.getProductos()?.subscribe((data:any) => this.productos = data);
    });
  }else{
    this.inv.postNuevoProducto(this.producto.descripcion)?.subscribe((data:any) => {
      if(data != null){
        console.log("Inserción correcta");      
      }else{
        console.log("Error");      
      }
  
      this.inv.getProductos()?.subscribe((data:any) => this.productos = data);
    });
  }

  this.producto = new Productos();
  this.changeView();
  };
  
  getProducto(id:number){
    this.inv.getProducto(id)?.subscribe((data:any) => this.producto = data);
    this.changeView();
  }

  changeView(){
    this.guardar = !this.guardar;
    
    console.log(this.producto);
    
    if(this.botonCambio == "Regresar"){
      this.producto = new Productos();
    }

    if (this.guardar){
      this.botonCambio = "Regresar";
    }else{
      this.botonCambio = "Agregar nuevo Producto";
    }

    this.inv.getProductos()?.subscribe((data:any) => {this.productos = data; });    
  }
}
