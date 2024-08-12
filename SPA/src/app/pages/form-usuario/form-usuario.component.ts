import { CommonModule,Location  } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { UsuarioCreate } from '../../core/interfaces/UsuarioCreate.interface';
import { UsuariosService } from '../../core/Services/Usuario.Service';
import { ToastService } from '../../core/Alerts/toast.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ProfesionesService } from '../../core/Services/profesiones.service';
import { Profesion } from '../../core/interfaces/Profesion.interface';
import { MatIcon } from '@angular/material/icon';

@Component({
  selector: 'app-form-usuario',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    CommonModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule,
    MatIcon
],
  templateUrl: './form-usuario.component.html',
  styleUrl: './form-usuario.component.css'
})
export class FormUsuarioComponent {

  userForm!: FormGroup;
  isCreateMode = true;
  listProfesiones: Profesion[] = []

  constructor(
    private fb: FormBuilder,
    private _usuarioService:UsuariosService,
    private _profesionesService:ProfesionesService,
    private _message:ToastService,
    private _activatedRoute: ActivatedRoute,
    private _location: Location,
    private _router: Router
  ) { }

  ngOnInit(): void {
    this.initForm();
    this.CargarDatosIniciales();

    this._activatedRoute.params.subscribe(param => {
      let guild = param['guild'];
      if(guild !== 'new'){
        this.isCreateMode = false

        this._usuarioService.getUsuarioByGuild(guild)
        .subscribe(resp =>{
          this.userForm.reset(resp);
        })
      }
    })
  }

  onBack() {
    this._location.back();
  }

  CargarDatosIniciales(){
    this._profesionesService.getProfesiones()
    .subscribe(resp => this.listProfesiones = resp);
  }

  initForm(){
    this.userForm = this.fb.group({
      userName: ['', [Validators.required, Validators.minLength(4)]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      passwordConfirm: ['', [Validators.required, Validators.minLength(6)]],
      name: ['', Validators.required],
      correo: ['', [Validators.required, Validators.email]] , // Nuevo campo correo
      profesionId: [null, [Validators.required]]  // Nuevo campo profesionId
    });
  }
  onSubmit() {
    if (this.userForm.valid)
    {
      if(this.isCreateMode){

        const formData : UsuarioCreate = {
          guid: "",  // Valor por defecto como cadena vacía
          ...this.userForm.value
        };
        console.log('Formulario exitoso',formData);
         // Aquí enviarías los datos al backen
        this._usuarioService.createUsuario(formData)
        .subscribe(resp => {
          this._message.showSuccessMesagge(resp.Message);
          this._router.navigate(['users']);
        });
      }else {
        const formData = this.userForm.value;

          this._usuarioService.updateUsuario(formData.id,formData)
              .subscribe(resp => {

                this._message.showSuccessMesagge("Registro creado exitosamente");
                  this._router.navigate(['users']);
              });
      }
    }
    else
    {
      this._message.showErrorMessage('Formulario invalido')
    }
  }
}
