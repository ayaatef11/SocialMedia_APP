import { NgFor } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-saved-post-details',
  standalone: true,
  imports: [RouterLink,NgFor],
  templateUrl: './saved-post-details.component.html',
  styleUrl: './saved-post-details.component.css'
})
export class SavedPostDetailsComponent {
savedPosts=[
  { id: 1, title: 'Post 1' },
  { id: 2, title: 'Post 2'}
]
}
