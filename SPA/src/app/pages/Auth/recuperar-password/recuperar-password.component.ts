import { Component, inject } from '@angular/core';
// import { MaterialModule } from '../../../Core/Common/material/material.module';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../../core/Services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-recuperar-password',
  standalone: true,
  imports: [
    FormsModule,

  ],
  templateUrl: './recuperar-password.component.html',
  styleUrl: './recuperar-password.component.css'
})
export class RecuperarPasswordComponent {

  private readonly authService = inject(AuthService);
  private readonly router = inject(Router);

    onRecuperarContrasenna() {
      // this.loading = true;
      // this.authService.validarCorreo(this.correo)
      //     .subscribe(
      //         {
      //             complete: () => {
      //                 this.validacionCorreoExitosa = true;
      //                 this.errorMessage = '';
      //                 this.loading = false;
      //             },
      //             error: (e) => {
      //                 this.errorMessage = e.error
      //                 this.loading = false;
      //             }
      //         }
      //     )
  }

  onValidarCodigo() {
      // this.loading = true;
      // this.authService.validarCodigo(this.correo, this.codigoValdiacion)
      //     .subscribe(
      //         {
      //             complete: () => {
      //                 this.validacionCodigoExitosa = true;
      //                 this.errorMessage = '';
      //                 this.loading = false;
      //             },
      //             error: (e) => {
      //                 this.errorMessage = e.error
      //                 this.loading = false;
      //             }
      //         }
      //     )
  }

  onCambiarContrasenna() {
      // this.loading = true;
      // if (this.contrasennaNueva !== this.contrasennaNuevaValidacion) {
      //     this.errorMessage = 'Las contraseñas no coinciden';
      //     this.loading = false;
      //     return;
      // }

    //   this.authService.changePassword(
    //       {
    //           correo: this.correo,
    //           contrasena: this.contrasennaNueva,
    //           codigo: this.codigoValdiacion
    //       }
    // )
    // .subscribe(
    //     {
    //         next: (resp) => {
    //             // logear y mandar al home
    //             this.authService.guardarToken(resp);
    //             this.router.navigate(['empleados']);
    //             this.loading = false;
    //         },
    //         error: (e) => {
    //             this.errorMessage = e.error
    //             this.loading = false;
    //         }
    //     }
    // )
  }
}
