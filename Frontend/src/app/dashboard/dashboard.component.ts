import { NgFor, NgIf } from '@angular/common';
import { Component, HostListener } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { SidebarComponent } from '../Common/sidebar/sidebar.component';
import { Router, RouterModule } from '@angular/router';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { SearchHeaderComponent } from "../Common/search/search-header/search-header.component";

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [FormsModule, SidebarComponent, RouterModule, NgIf],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css',
  animations: [
    trigger('slideInOut', [
      state('in', style({
        transform: 'translateY(0)',
        opacity: 1
      })),
      state('out', style({
        transform: 'translateY(-100%)',
        opacity: 0
      })),
      transition('in => out', animate('300ms ease-in-out')),
      transition('out => in', animate('300ms ease-in-out'))
    ])
  ]
})
export class DashboardComponent {
follow() {
throw new Error('Method not implemented.');
}
  searchQuery: string = '';
  isOpen = false;
  users: any[] = [];
  constructor(private router:Router){}
  onSearch() {
    this.isOpen = !this.isOpen;
    if (this.isOpen) {
      setTimeout(() => {
        const input = document.getElementById('searchInput');
        if (input) input.focus();
      }, 300);
    }
    this.router.navigate(['/search/all'])
  }
  @HostListener('document:keydown.escape', ['$event'])
  handleEscape(event: KeyboardEvent) {
    if (this.isOpen) {
      this.isOpen = false;
    }
  }

  currentUser = {
    username: 'your_username',
    profileImage: 'https://via.placeholder.com/150'
  };

  newStatus = '';
  selectedImage: File | null = null;
  selectedImagePreview: string | null = null;

  usersWithStatus = [
    { username: 'user1', profileImage: 'https://via.placeholder.com/150', hasUnviewedStatus: true },
    { username: 'user2', profileImage: 'https://via.placeholder.com/150', hasUnviewedStatus: false },
    { username: 'user3', profileImage: 'https://via.placeholder.com/150', hasUnviewedStatus: true },
    { username: 'user4', profileImage: 'https://via.placeholder.com/150', hasUnviewedStatus: false },
    { username: 'user5', profileImage: 'https://via.placeholder.com/150', hasUnviewedStatus: true }
  ];



  ngOnInit(): void {
    // You might want to load actual data from a service here
  }



  viewStatus(user: any): void {
    // In a real app, you would navigate to a status viewer component
    console.log(`Viewing ${user.username}'s status`);
    user.hasUnviewedStatus = false; // Mark as viewed
  }

}
