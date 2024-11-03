import { Routes } from '@angular/router';
import { ListUsuarioComponent } from './pages/list-usuario/list-usuario.component';
import { FormUsuarioComponent } from './pages/form-usuario/form-usuario.component';
import { LayoutsComponent } from './layouts/layouts.component';
import { LoginComponent } from './pages/Auth/login/login.component';
import { authGuard } from './core/guards/auth.guard';

export const routes: Routes = [
 // {path:'formulario', component:FormularioComponent},

  {path:'login',component:LoginComponent},

  //layout
  {path:'',
    component:LayoutsComponent,
    canActivate: [authGuard],
    canActivateChild: [authGuard],
    children:[
      //Tabla Usuarios
      {path:'users', component:ListUsuarioComponent},
      {path:'users/:guid', component:FormUsuarioComponent},
    ]}
];
