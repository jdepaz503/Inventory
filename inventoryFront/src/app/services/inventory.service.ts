import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { map } from 'rxjs/operators'

@Injectable({
  providedIn: 'root'
})
export class InventoryService {

  private url = 'https://localhost:5001/api/v1.0/';

  constructor(private http: HttpClient) { }

  doRequest(url:string, method:string, params:any){
    try {
      
      if (method == "GET"){
        
        const httpOptions = {
          headers: new HttpHeaders({
            'Content-Type': 'application/json',
            'timeout':'200000'
          }),
          params:params
        };

        return this.http.get(this.url + url,httpOptions)
        .pipe(map(data => data));

      }else if (method == "POST"){
        
        const httpOptions = {
          headers: new HttpHeaders({
            'Content-Type': 'application/json',
            'timeout':'200000'
          })
        };

        return this.http.post(this.url + url, params, httpOptions)
        .pipe(map(data => data, (err:any) => console.log(err)));
      };
      
      return null;

    } catch (e) {
      console.log(e);      
      return null;
    }
  }
  
  //Métodos de Productos
  getProductos(){
    return this.doRequest('ObtenerProductos', 'GET', null);
  }

  getProducto(id:number){
    let params = new HttpParams().set("id",id)
    return this.doRequest('ObtenerProducto', 'GET', params);
  }

  postNuevoProducto(descripcion:string){
    return this.doRequest('AgregarProducto', 'POST', JSON.stringify({"Descripcion":descripcion}));
  }

  putActualizarProducto(id:number, descripcion:string){
    return this.doRequest('ActualizarProducto', 'POST', JSON.stringify({"Sku":id,"Descripcion":descripcion}));
  }

  //Métodos de Ordenes
  getOrdenes(){
    return this.doRequest('ObtenerOrdenes', 'GET', null);
  }

  getOrden(id:number){
    let params = new HttpParams().set("id",id)
    return this.doRequest('ObtenerOrden', 'GET', params);
  }

  postNuevaOrden(id:number, cantidad:number, estatus:string){
    return this.doRequest('CrearOrden', 'POST', JSON.stringify({"sku":id, "cantidad":cantidad, "estatus":estatus}));
  }

  postAnularOrden(id:number){
    return this.doRequest('AnularOrden', 'POST', id);
  }
}
