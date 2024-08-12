import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { UsuarioCreate } from '../interfaces/UsuarioCreate.interface';
import { UsuarioDTO } from '../interfaces/Usuario.interface';

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {

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

  getUsuarios(): Observable<UsuarioDTO[]> {
    return this.http.get<UsuarioDTO[]>(`${this.apiURL}/GetAll`);
  }

   // Actualizar un usuario existente
  updateUsuario(id: number, usuario: UsuarioDTO): Observable<void> {
    return this.http.put<void>(`${this.apiURL}/${id}`, usuario);
  }

  // Eliminar un usuario
  deleteUsuario(id: any): Observable<void> {
      return this.http.delete<void>(`${this.apiURL}/Delete/${id}`);
  }

  getUsuarioByGuild(guild: string): Observable<UsuarioDTO> {
    return this.http.get<UsuarioDTO>(`${this.apiURL}/GetUsuarioByGuid/${guild}`);
  }

  // getEmpleados(usuario?:any) {
  //   return mockUsuarios;
  // }

}

const mockUsuarios: UsuarioDTO[] = [
  {
    Id: '1',
    guid: '1234-abcd-5678-efgh',
    userName: 'jdoe',
    name: 'John Doe',
    correo: 'jdoe@example.com',
    profesionId: 2
  },
  {
    Id: '2',
    guid: '2345-bcde-6789-fghi',
    userName: 'asmith',
    name: 'Alice Smith',
    correo: 'asmith@example.com',
    profesionId: 1
  },
  {
    Id: '3',
    guid: '3456-cdef-7890-ghij',
    userName: 'bjohnson',
    name: 'Bob Johnson',
    correo: 'bjohnson@example.com',
    profesionId: 3
  },
  {
    Id: '4',
    guid: '4567-defg-8901-hijk',
    userName: 'mwhite',
    name: 'Mary White',
    correo: 'mwhite@example.com',
    profesionId: 4
  },
  {
    Id: '5',
    guid: '5678-efgh-9012-klmn',
    userName: 'rwilliams',
    name: 'Robert Williams',
    correo: 'rwilliams@example.com',
    profesionId: 2
  },
  {
    Id: '6',
    guid: '6789-fghi-0123-mnop',
    userName: 'kthompson',
    name: 'Karen Thompson',
    correo: 'kthompson@example.com',
    profesionId: 1
  },
  {
    Id: '7',
    guid: '7890-ghij-1234-nopq',
    userName: 'dlee',
    name: 'David Lee',
    correo: 'dlee@example.com',
    profesionId: 3
  },
  {
    Id: '8',
    guid: '8901-hijk-2345-opqr',
    userName: 'hclark',
    name: 'Helen Clark',
    correo: 'hclark@example.com',
    profesionId: 2
  },
  {
    Id: '9',
    guid: '9012-ijkl-3456-pqrs',
    userName: 'gmartin',
    name: 'George Martin',
    correo: 'gmartin@example.com',
    profesionId: 1
  },
  {
    Id: '10',
    guid: '0123-jklm-4567-rstu',
    userName: 'cmiller',
    name: 'Christine Miller',
    correo: 'cmiller@example.com',
    profesionId: 3
  },
  {
    Id: '11',
    guid: '1234-klmn-5678-stuv',
    userName: 'djones',
    name: 'Daniel Jones',
    correo: 'djones@example.com',
    profesionId: 2
  },
  {
    Id: '12',
    guid: '2345-lmno-6789-tuvw',
    userName: 'lroberts',
    name: 'Laura Roberts',
    correo: 'lroberts@example.com',
    profesionId: 1
  },
  {
    Id: '13',
    guid: '3456-mnop-7890-uvwx',
    userName: 'mjackson',
    name: 'Michael Jackson',
    correo: 'mjackson@example.com',
    profesionId: 3
  },
  {
    Id: '14',
    guid: '4567-nopq-8901-vwxy',
    userName: 'jrodriguez',
    name: 'Jessica Rodriguez',
    correo: 'jrodriguez@example.com',
    profesionId: 2
  },
  {
    Id: '15',
    guid: '5678-opqr-9012-wxyz',
    userName: 'tking',
    name: 'Thomas King',
    correo: 'tking@example.com',
    profesionId: 1
  }
];

