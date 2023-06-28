import { Component, OnInit , Inject} from '@angular/core';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Empleado } from 'src/app/Interfaces/empleado';

import { EmpleadoService } from 'src/app/Services/empleado.service';
import { UtilidadService } from 'src/app/Reutilizable/utilidad.service';


@Component({
  selector: 'app-modal-empleado',
  templateUrl: './modal-empleado.component.html',
  styleUrls: ['./modal-empleado.component.css']
})
export class ModalEmpleadoComponent implements OnInit {

  formularioEmpleado:FormGroup;
  tituloAccion:string = "Agregar";
  botonAccion:string = "Guardar";

  constructor(
    private modalActual: MatDialogRef<ModalEmpleadoComponent>,
    @Inject(MAT_DIALOG_DATA) public datosEmpleado: Empleado,
    private fb: FormBuilder,
    private _empleadoServicio: EmpleadoService,
    private _utilidadServicio: UtilidadService
  ) { 

    this.formularioEmpleado = this.fb.group({
      nomEmp : ['',Validators.required],
      apeEmp : ['',Validators.required],
      telEmp : ['',Validators.required],
      dirEmp : ['',Validators.required],
      correo : ['',Validators.required],
      estado : ['1',Validators.required],
    });

      if(this.datosEmpleado != null){

        this.tituloAccion = "Editar";
        this.botonAccion = "Actualizar";
      }

  }

  ngOnInit(): void {

    if(this.datosEmpleado != null){

      this.formularioEmpleado.patchValue({
        nomEmp : this.datosEmpleado.nomEmp,
        apeEmp : this.datosEmpleado.apeEmp,
        telEmp : this.datosEmpleado.telEmp,
        dirEmp : this.datosEmpleado.dirEmp,
        correo : this.datosEmpleado.correo,
        estado : this.datosEmpleado.estado.toString()
      })

    }

  }


  guardarEditar_Empleado(){

    const _empleado: Empleado = {
      idEmp : this.datosEmpleado == null ? 0 : this.datosEmpleado.idEmp,
      nomEmp : this.formularioEmpleado.value.nomEmp,
      apeEmp: this.formularioEmpleado.value.apeEmp,
      telEmp: this.formularioEmpleado.value.telEmp,
      dirEmp  : this.formularioEmpleado.value.dirEmp,
      correo: this.formularioEmpleado.value.correo,
      estado: parseInt(this.formularioEmpleado.value.estado),
    }

    if(this.datosEmpleado == null){

      this._empleadoServicio.guardar(_empleado).subscribe({
        next: (data) =>{
          if(data.status){
            this._utilidadServicio.mostrarAlerta("El empleado fue registrado","Exito");
            this.modalActual.close("true")
          }else
            this._utilidadServicio.mostrarAlerta("No se pudo registrar el empleado","Error")
        },
        error:(e) => {}
      })

    }else{

      this._empleadoServicio.editar(_empleado).subscribe({
        next: (data) =>{
          if(data.status){
            this._utilidadServicio.mostrarAlerta("El empleado fue editado","Exito");
            this.modalActual.close("true")
          }else
            this._utilidadServicio.mostrarAlerta("No se pudo editar el empleado","Error")
        },
        error:(e) => {}
      })
    }

  }


}
