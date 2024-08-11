import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import {  UsuarioCreate } from '../../core/interfaces/UsuarioCreate.interface';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { UsuariosService } from '../../core/Services/Usuario.Service';


@Component({
  selector: 'app-formulario',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    CommonModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule
],
  templateUrl: './formulario.component.html',
  styleUrls: ['./formulario.component.css']
})
export class FormularioComponent implements OnInit {

  userForm!: FormGroup;
  msmResp = '';

  constructor(private fb: FormBuilder, private _usuarioService:UsuariosService) { }

  ngOnInit(): void {
    this.initForm();
  }

  initForm(){
    this.userForm = this.fb.group({
      userName: ['', [Validators.required, Validators.minLength(4)]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      passwordConfirm: ['', [Validators.required, Validators.minLength(6)]],
      name: ['', Validators.required],
      correo: ['', [Validators.required, Validators.email]]  // Nuevo campo correo
    });
  }
  onSubmit() {
    if (this.userForm.valid)
    {
      const formData : UsuarioCreate = {
        guid: "",  // Valor por defecto como cadena vacía
        ...this.userForm.value
      };

      console.log('Formulario exitoso',formData);

       // Aquí enviarías los datos al backen
      this._usuarioService.createUsuario(formData)
      .subscribe(resp => {
        console.log(resp);
        this.msmResp = resp.Message;
      });
    }
    else
    {
      console.log('Formulario invalido');
    }
  }
}
