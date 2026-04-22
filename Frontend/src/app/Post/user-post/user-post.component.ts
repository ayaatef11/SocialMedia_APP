import { NgFor, NgIf } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-user-post',
  standalone: true,
  imports: [NgFor,NgIf],
  templateUrl: './user-post.component.html',
  styleUrl: './user-post.component.css'
})
export class UserPostComponent {
  statusFeed = [
    {
      user: { username: 'user1', profileImage: 'https://via.placeholder.com/150' },
      text: 'Enjoying a beautiful day at the beach! 🏖️',
      image: 'https://via.placeholder.com/500x300',
      timestamp: new Date(Date.now() - 3600000),
      likes: 24
    },
    {
      user: { username: 'user2', profileImage: 'https://via.placeholder.com/150' },
      text: 'Just finished this amazing book! Highly recommend it.',
      image: null,
      timestamp: new Date(Date.now() - 7200000),
      likes: 12
    }
  ];
}
