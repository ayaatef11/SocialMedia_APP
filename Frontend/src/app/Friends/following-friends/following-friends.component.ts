import { Component } from '@angular/core';
import { FriendsHeaderComponent } from '../friends-header/friends-header.component';

@Component({
  selector: 'app-following-friends',
  standalone: true,
  imports: [FriendsHeaderComponent],
  templateUrl: './following-friends.component.html',
  styleUrl: './following-friends.component.css'
})
export class FollowingFriendsComponent {

}
