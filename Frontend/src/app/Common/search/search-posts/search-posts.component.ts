import { Component } from '@angular/core';
import { SearchHeaderComponent } from "../search-header/search-header.component";

@Component({
  selector: 'app-search-posts',
  standalone: true,
  imports: [SearchHeaderComponent],
  templateUrl: './search-posts.component.html',
  styleUrl: './search-posts.component.css'
})
export class SearchPostsComponent {

}
