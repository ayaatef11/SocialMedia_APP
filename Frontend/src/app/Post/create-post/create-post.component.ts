import { NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-create-post',
  standalone: true,
  imports: [NgIf,FormsModule],
  templateUrl: './create-post.component.html',
  styleUrl: './create-post.component.css'
})
export class CreatePostComponent {
 newStatus = '';
  selectedImage: File | null = null;
  selectedImagePreview: string | null = null;
 
  constructor() {
    // super();
    
  }
  currentUser = {
    username: 'your_username',
    profileImage: 'https://via.placeholder.com/150'
  };
  usersWithStatus = [
    { username: 'user1', profileImage: 'https://via.placeholder.com/150', hasUnviewedStatus: true },
    { username: 'user2', profileImage: 'https://via.placeholder.com/150', hasUnviewedStatus: false },
    { username: 'user3', profileImage: 'https://via.placeholder.com/150', hasUnviewedStatus: true },
    { username: 'user4', profileImage: 'https://via.placeholder.com/150', hasUnviewedStatus: false },
    { username: 'user5', profileImage: 'https://via.placeholder.com/150', hasUnviewedStatus: true }
  ];

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
 onFileSelected(event: any): void {
    const file: File = event.target.files[0];
    if (file) {
      this.selectedImage = file;
      
      // Create preview
      const reader = new FileReader();
      reader.onload = (e: any) => {
        this.selectedImagePreview = e.target.result;
      };
      reader.readAsDataURL(file);
    }
  }

  removeImage(): void {
    this.selectedImage = null;
    this.selectedImagePreview = null;
  }

  postStatus(): void {
    if (!this.newStatus && !this.selectedImage) return;

    const newStatus = {
      user: this.currentUser,
      text: this.newStatus,
      image: this.selectedImagePreview,
      timestamp: new Date(),
      likes: 0
    };

    this.statusFeed.unshift(newStatus); // Add to beginning of array
    
    // Reset form
    this.newStatus = '';
    this.selectedImage = null;
    this.selectedImagePreview = null;
  }
}
