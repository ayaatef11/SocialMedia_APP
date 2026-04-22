import { NgFor } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-saved-posts',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './All.component.html',
  styleUrl: './All.component.css'
})
export class AllComponent {


  constructor() {    
  }

  //  setActiveTab(tab: string) {
  //   this.activeTab = tab;
  // }

  // get filteredPosts() {
  //   if (this.activeTab === 'All') {
  //     return this.savedPosts;
  //   }
    
  // viewPost(post: SavedPost) {
  //   console.log('Viewing post:', post);
  //   // Implement view functionality
  // }

  // unsavePost(post: SavedPost) {
  //   this.savedPosts = this.savedPosts.filter(p => p.id !== post.id);
  //   console.log('Unsaved post:', post);
  // }

  // sharePost(post: SavedPost) {
  //   console.log('Sharing post:', post);
  //   // Implement share functionality
  // }
}
