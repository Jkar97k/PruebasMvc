import { Routes } from '@angular/router';
import { FormularioComponent } from './pages/formulario/formulario.component';
import { ListUsuarioComponent } from './pages/list-usuario/list-usuario.component';
import { FormUsuarioComponent } from './pages/form-usuario/form-usuario.component';

export const routes: Routes = [
 // {path:'formulario', component:FormularioComponent},

  //Tabla Usuarios
  {path:'users', component:ListUsuarioComponent},
  {path:'users/:Id', component:FormUsuarioComponent}
];
