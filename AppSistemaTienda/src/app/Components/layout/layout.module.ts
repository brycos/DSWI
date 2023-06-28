import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LayoutRoutingModule } from './layout-routing.module';

import { DashBoardComponent } from './Pages/dash-board/dash-board.component';
import { ClienteComponent } from './Pages/cliente/cliente.component';
import { EmpleadoComponent } from './Pages/empleado/empleado.component';
import { ProductoComponent } from './Pages/producto/producto.component';
import { VentaComponent } from './Pages/venta/venta.component';
import { HistorialVentaComponent } from './Pages/historial-venta/historial-venta.component';
import { ReporteComponent } from './Pages/reporte/reporte.component';

import { SharedModule } from 'src/app/Reutilizable/shared/shared.module';
import { ModalClienteComponent } from './Modales/modal-cliente/modal-cliente.component';
import { ModalEmpleadoComponent } from './Modales/modal-empleado/modal-empleado.component';
import { ModalProductoComponent } from './Modales/modal-producto/modal-producto.component';
import { ModalDetalleVentaComponent } from './Modales/modal-detalle-venta/modal-detalle-venta.component';




@NgModule({
  declarations: [
    DashBoardComponent,
    ProductoComponent,
    VentaComponent,
    HistorialVentaComponent,
    ReporteComponent,
    ModalProductoComponent,
    ModalDetalleVentaComponent,
    ClienteComponent,
    EmpleadoComponent,
    ModalClienteComponent,
    ModalEmpleadoComponent
  ],
  imports: [
    CommonModule,
    LayoutRoutingModule,

    SharedModule
  ]
})
export class LayoutModule { }
