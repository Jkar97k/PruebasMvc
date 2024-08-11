import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { UsuarioDTO } from '../../core/interfaces/Usuario.interface';
import { UsuariosService } from '../../core/Services/Usuario.Service';
import { MatIconModule } from '@angular/material/icon';
import Swal from 'sweetalert2'
import { ToastService } from '../../core/Alerts/toast.service';


@Component({
  selector: 'app-list-usuario',
  standalone: true,
  imports: [
    MatTableModule,
    MatPaginatorModule,
    MatIconModule
  ],
  templateUrl: './list-usuario.component.html',
  styleUrls: ['./list-usuario.component.css']
})
export class ListUsuarioComponent implements OnInit, AfterViewInit {

  user: UsuarioDTO[] = [];
  displayedColumns: string[] = ['userName', 'name', 'profesionId','correo','acciones'];
  dataSource = new MatTableDataSource<UsuarioDTO>(this.user);

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private _usuariosService: UsuariosService,
    private _message:ToastService
  ) {}

  ngOnInit(): void {
    this.cargarUsuarios();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  cargarUsuarios() {
    this._usuariosService.getUsuarios().subscribe( resp => {
      console.log(resp);
      this.user = resp;
      this.dataSource.data = this.user;
    });
  }


  editarUser(usuario:UsuarioDTO){
    console.log('editando:' ,usuario.name)
  }

  async elimiarUser(element:UsuarioDTO):Promise<void>{
    let confirm = await this._message.confirmDelete()
    if (confirm) {
        this._usuariosService.deleteUsuario(element.Id!)
            .subscribe(
              {
                  complete: () => {
                      this._message.showSuccessMesagge('Registro eliminado exitosamente');
                      this.cargarUsuarios();
                  },
                  error: (e) => this._message.showErrorMessage(e.error)
              }
            )
    }
}


}
