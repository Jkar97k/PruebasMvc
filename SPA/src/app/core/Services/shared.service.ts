import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, throwError } from 'rxjs';
import { UsuarioCreate } from '../interfaces/UsuarioCreate.interface';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  private apiURL = 'https://localhost:7289/api/Usuario';

  constructor(private http: HttpClient) { }

  createUsuario(usuario: UsuarioCreate) {
    return this.http.post<any>(`${this.apiURL}/CreateUsuario`, usuario)
      .pipe(
        catchError(error => {
          console.error('Error creating user:', error);
          return throwError(() => new Error('Error creating user, please try again later.'));
        })
      );
  }

  // passwordMatchValidator(control: AbstractControl): ValidationErrors | null {
  //   const password = control.get('password');
  //   const passwordConfirm = control.get('passwordConfirm');

  //   if (password && passwordConfirm && password.value !== passwordConfirm.value) {
  //     return { passwordMismatch: true };
  //   }
  //   return null;
  // }

}
