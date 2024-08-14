import { Component } from '@angular/core';
import { SideMenuComponent } from './side-menu/side-menu.component';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-layouts',
  standalone: true,
  imports: [SideMenuComponent,NgIf],
  templateUrl: './layouts.component.html',
  styleUrl: './layouts.component.css'
})
export class LayoutsComponent {

}
