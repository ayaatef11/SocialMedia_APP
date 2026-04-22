import { Component } from '@angular/core';
import { SettingsSidebarComponent } from "./settings-sidebar/settings-sidebar.component";
import { SidebarComponent } from "../sidebar/sidebar.component";
import { RouterModule, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-settings',
  standalone: true,
  imports: [SettingsSidebarComponent, RouterModule,RouterOutlet],
  templateUrl: './settings.component.html',
  styleUrl: './settings.component.css'
})
export class SettingsComponent {

}
