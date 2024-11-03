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
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { ProfesionesService } from '../../core/Services/profesiones.service';
import { Profesion } from '../../core/interfaces/Profesion.interface';
import { MatIcon } from '@angular/material/icon';
import { UsuarioDTO } from '../../core/interfaces/Usuario.interface';

@Component({
  selector: 'app-form-usuario',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    CommonModule,
    RouterModule,
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
  listProfesiones: Profesion[] = [];
  userDTO! : UsuarioDTO;

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

      let guild = param['guid'];

      if(guild !== 'new'){

        this.isCreateMode = false
        this._usuarioService.getUsuarioByGuild(guild)
        .subscribe((resp : UsuarioDTO) =>{
          this.userDTO = resp;
          console.log(this.userDTO);
          this.userForm.patchValue(resp);
          this.userForm.reset(resp);

          // Después de cargar los datos, ajustamos las validaciones
          this.userForm.get('password')?.clearValidators();
          this.userForm.get('passwordConfirm')?.clearValidators();
          this.userForm.get('password')?.updateValueAndValidity();
          this.userForm.get('passwordConfirm')?.updateValueAndValidity();
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
      password: ['', this.isCreateMode ? [Validators.required, Validators.minLength(6)] : []],
      passwordConfirm: ['', this.isCreateMode ? [Validators.required, Validators.minLength(6)] : []],
      name: ['', Validators.required],
      correo: ['', [Validators.required, Validators.email]],
      profesionId: [null, [Validators.required]]
    });

    if (!this.isCreateMode) {
      // Quitar las validaciones de password y passwordConfirm si estamos en modo edición
      this.userForm.get('password')?.clearValidators();
      this.userForm.get('passwordConfirm')?.clearValidators();
      this.userForm.get('password')?.updateValueAndValidity();
      this.userForm.get('passwordConfirm')?.updateValueAndValidity();
    }
}

  onSubmit() {
    if (this.userForm.valid)
    {
      console.log(this.userForm.valid);
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
      }
      else {
        this.userDTO = { ...this.userDTO, ...this.userForm.value };

        console.log(this.userDTO);

        this._usuarioService.updateUsuario(this.userDTO)
          .subscribe(resp => {
            if (resp && resp.Message) {  // Verifica que resp y resp.Message existan
              this._message.showSuccessMesagge(resp.Message);
              this._router.navigate(['users']);
            } else {
              this._message.showErrorMessage('Error al actualizar el usuario');
            }
          }, error => {
            // Maneja el error que viene del servidor
            this._message.showErrorMessage(error.error);
          });
      }
    }
    else
    {
      this._message.showErrorMessage('Formulario invalido')
    }
  }
}
