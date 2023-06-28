import { Component, OnInit, Inject } from '@angular/core';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Cliente } from 'src/app/Interfaces/cliente';

import { ClienteService } from 'src/app/Services/cliente.service';
import { UtilidadService } from 'src/app/Reutilizable/utilidad.service';

@Component({
  selector: 'app-modal-cliente',
  templateUrl: './modal-cliente.component.html',
  styleUrls: ['./modal-cliente.component.css']
})
export class ModalClienteComponent implements OnInit {

  formularioCliente:FormGroup;
  tituloAccion:string = "Agregar";
  botonAccion:string = "Guardar";

  constructor(
    private modalActual: MatDialogRef<ModalClienteComponent>,
    @Inject(MAT_DIALOG_DATA) public datosCliente: Cliente,
    private fb: FormBuilder,
    private _clienteServicio: ClienteService,
    private _utilidadServicio: UtilidadService
  ) { 

    this.formularioCliente = this.fb.group({
      nomCli : ['',Validators.required],
      apeCli : ['',Validators.required],
      telCli : ['',Validators.required],
      dirCli : ['',Validators.required],
      correo : ['',Validators.required],
      estado : ['1',Validators.required],
    });

      if(this.datosCliente != null){

        this.tituloAccion = "Editar";
        this.botonAccion = "Actualizar";
      }

  }

  ngOnInit(): void {

    if(this.datosCliente != null){

      this.formularioCliente.patchValue({
        nomCli : this.datosCliente.nomCli,
        apeCli : this.datosCliente.apeCli,
        telCli : this.datosCliente.telCli,
        dirCli : this.datosCliente.dirCli,
        correo : this.datosCliente.correo,
        estado : this.datosCliente.estado.toString()
      })

    }

  }


  guardarEditar_Cliente(){

    const _cliente: Cliente = {
      idCli : this.datosCliente == null ? 0 : this.datosCliente.idCli,
      nomCli : this.formularioCliente.value.nomCli,
      apeCli: this.formularioCliente.value.apeCli,
      telCli: this.formularioCliente.value.telCli,
      dirCli  : this.formularioCliente.value.dirCli,
      correo: this.formularioCliente.value.correo,
      estado: parseInt(this.formularioCliente.value.estado),
    }

    if(this.datosCliente == null){

      this._clienteServicio.guardar(_cliente).subscribe({
        next: (data) =>{
          if(data.status){
            this._utilidadServicio.mostrarAlerta("El cliente fue registrado","Exito");
            this.modalActual.close("true")
          }else
            this._utilidadServicio.mostrarAlerta("No se pudo registrar el cliente","Error")
        },
        error:(e) => {}
      })

    }else{

      this._clienteServicio.editar(_cliente).subscribe({
        next: (data) =>{
          if(data.status){
            this._utilidadServicio.mostrarAlerta("El cliente fue editado","Exito");
            this.modalActual.close("true")
          }else
            this._utilidadServicio.mostrarAlerta("No se pudo editar el cliente","Error")
        },
        error:(e) => {}
      })
    }

  }

}
