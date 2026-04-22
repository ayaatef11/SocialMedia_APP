import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-notigications-header',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './notifications-header.component.html',
  styleUrl: './notifications-header.component.css'
})
export class NotificationsHeaderComponent {

markAllAsRead():void{

}
}
