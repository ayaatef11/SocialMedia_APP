import { Component } from '@angular/core';
import { SearchHeaderComponent } from "./search-header/search-header.component";

@Component({
  selector: 'app-search',
  standalone: true,
  imports: [SearchHeaderComponent],
  templateUrl: './search.component.html',
  styleUrl: './search.component.css'
})
export class SearchComponent {

}
