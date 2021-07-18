import { Productos } from "./producto.model";

export class Ordenes{
    idOrden:number | null | undefined;
    fk_sku: Productos = new Productos();
    cantidad:number = 0;
    fechaIngreso:Date = new Date();
    estado:string = "";
}