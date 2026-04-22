import { Component } from '@angular/core';
import { FriendsHeaderComponent } from "../friends-header/friends-header.component";

@Component({
  selector: 'app-followedFriends',
  standalone: true,
  imports: [FriendsHeaderComponent],
  templateUrl: './Followed-Friends.component.html',
  styleUrl: './Followed-Friends.component.css'
})
export class FollowedFriendsComponent {

}
