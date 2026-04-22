import { Component } from '@angular/core';
import { SearchHeaderComponent } from "../search-header/search-header.component";

@Component({
  selector: 'app-search-tags',
  standalone: true,
  imports: [SearchHeaderComponent],
  templateUrl: './search-tags.component.html',
  styleUrl: './search-tags.component.css'
})
export class SearchTagsComponent {

}
