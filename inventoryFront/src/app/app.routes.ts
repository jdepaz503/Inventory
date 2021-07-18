import { RouterModule, Routes } from "@angular/router";
import { ProductsComponent } from './components/products/products.component';
import { OrdersComponent } from './components/orders/orders.component';

const APP_ROUTES: Routes = [
    {path : 'home', component: ProductsComponent},
    {path : 'orders', component: OrdersComponent},
    {path : 'orders/:id', component: OrdersComponent},
    {path : '*', pathMatch: 'full', redirectTo: 'home'},
    {path : '', pathMatch: 'full', redirectTo: 'home'}
];

export const APP_ROUTING= RouterModule.forRoot(APP_ROUTES);