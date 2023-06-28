import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';


import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';

import { ModalEmpleadoComponent} from '../../Modales/modal-empleado/modal-empleado.component';
import { Empleado } from 'src/app/Interfaces/empleado';
import { EmpleadoService } from 'src/app/Services/empleado.service';
import { UtilidadService } from 'src/app/Reutilizable/utilidad.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-empleado',
  templateUrl: './empleado.component.html',
  styleUrls: ['./empleado.component.css']
})
export class EmpleadoComponent implements OnInit, AfterViewInit {

  
  columnasTabla: string[] = ['nomEmp','apeEmp','telEmp','dirEmp','correo','estado','acciones'];
  dataInicio:Empleado[] = [];
  dataListaEmpleados = new MatTableDataSource(this.dataInicio);
  @ViewChild(MatPaginator) paginacionTabla! : MatPaginator;

  constructor(
    private dialog: MatDialog,
    private _empleadoServicio:EmpleadoService,
    private _utilidadServicio: UtilidadService
  ) { }

  obtenerEmpleados(){

      this._empleadoServicio.lista().subscribe({
        next: (data) => {
          if(data.status)
            this.dataListaEmpleados.data = data.value;
          else
            this._utilidadServicio.mostrarAlerta("No se encontraron datos","Oops!")
        },
        error:(e) =>{}
      })

    }

  ngOnInit(): void {
    this.obtenerEmpleados();
  }

  ngAfterViewInit(): void {
    this.dataListaEmpleados.paginator = this.paginacionTabla;
  }

  aplicarFiltroTabla(event: Event){
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataListaEmpleados.filter = filterValue.trim().toLocaleLowerCase();
  }

  nuevoEmpleado(){
    this.dialog.open(ModalEmpleadoComponent, {
      disableClose:true
    }).afterClosed().subscribe(resultado =>{
      if(resultado === "true") this.obtenerEmpleados();
    });
  }

  editarEmpleado(empleado:Empleado){
    this.dialog.open(ModalEmpleadoComponent, {
      disableClose:true,
      data: empleado
    }).afterClosed().subscribe(resultado =>{
      if(resultado === "true") this.obtenerEmpleados();
    });
  }

  eliminarEmpleado(empleado:Empleado){

    Swal.fire({
      title: '¿Desea eliminar el empleado?',
      text: empleado.nomEmp,
      icon:"warning",
      confirmButtonColor: '#3085d6',
      confirmButtonText: "Si, eliminar",
      showCancelButton: true,
      cancelButtonColor: '#d33',
      cancelButtonText: 'No, volver'
    }).then((resultado) =>{

      if(resultado.isConfirmed){

        this._empleadoServicio.eliminar(empleado.idEmp).subscribe({
          next:(data) =>{

            if(data.status){
              this._utilidadServicio.mostrarAlerta("El empleado fue eliminado","Listo!");
              this.obtenerEmpleados();
            }else
              this._utilidadServicio.mostrarAlerta("No se pudo eliminar el empleado","Error");

          },
          error:(e) =>{}
        })

      }

    })

  }


}
