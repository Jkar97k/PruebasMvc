import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { Router, RouterModule } from '@angular/router';
import { LoginDTO } from '../../../core/interfaces/LoginDTO.interface';
import { ToastService } from '../../../core/Alerts/toast.service';
import { AuthService } from '../../../core/Services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    CommonModule,
    RouterModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {

  private readonly fb = inject(FormBuilder);
  private readonly messageService = inject(ToastService);
  private readonly seguridadService = inject(AuthService);
  private readonly router = inject(Router);

  formulario!: FormGroup;

  ngOnInit(): void {
    this.initForm();
  }

  initForm() {
    this.formulario = this.fb.group({
      UserName: ['', [Validators.required]],
      Password: ['', [Validators.required]]
    });
  }



  onSubmit() {
    if (this.formulario.valid) {
      //this.messageService.showSuccessMesagge('valido');
      this.seguridadService.login(this.formulario.value).subscribe({
        next: (resp) => {

          this.seguridadService.guardarToken(resp);
          this.router.navigate(['users']);
        },
        error: () => this.messageService.showErrorMessage("Usuario o contraseña incorrectos")
      });
    } else {
      this.messageService.showErrorMessage("Falla apropocito");
    }
  }
}
