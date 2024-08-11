import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Usuario } from '../../core/interfaces/Usuario.interface';
import { SharedService } from '../../core/Services/shared.service';

@Component({
  selector: 'app-formulario',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './formulario.component.html',
  styleUrls: ['./formulario.component.css']
})
export class FormularioComponent implements OnInit {

  userForm!: FormGroup;
  msmResp = '';

  constructor(private fb: FormBuilder, private _sharedService:SharedService) { }

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
      const formData : Usuario = {
        guid: "",  // Valor por defecto como cadena vacía
        ...this.userForm.value
      };

      console.log('Formulario exitoso',formData);

       // Aquí enviarías los datos al backen
      this._sharedService.createUsuario(formData)
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
