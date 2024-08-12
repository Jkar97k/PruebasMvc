import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UsuarioDTO } from '../interfaces/Usuario.interface';
import { Observable } from 'rxjs';
import { Profesion } from '../interfaces/Profesion.interface';

@Injectable({
  providedIn: 'root'
})
export class ProfesionesService {

  private apiURL = 'https://localhost:7289/api/Profecion';

  constructor(private http: HttpClient) { }

  getProfesiones(): Observable<Profesion[]> {
    return this.http.get<Profesion[]>(`${this.apiURL}/GetProfesiones`);
  }

}
