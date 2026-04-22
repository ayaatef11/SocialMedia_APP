import { Component } from '@angular/core';
import { SearchHeaderComponent } from "../search-header/search-header.component";

@Component({
  selector: 'app-search-people',
  standalone: true,
  imports: [SearchHeaderComponent],
  templateUrl: './search-people.component.html',
  styleUrl: './search-people.component.css'
})
export class SearchPeopleComponent {

}
