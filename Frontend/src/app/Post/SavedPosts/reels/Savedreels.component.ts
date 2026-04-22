import { Component ,AfterViewInit} from '@angular/core';
import { VolumeToggling } from './Services/volumeToggling.service';

@Component({
  selector: 'app-reels',
  standalone: true,
  imports: [],
  templateUrl: './Savedreels.component.html',
  styleUrl: './Savedreels.component.css'
})
export class SavedReelsComponent implements AfterViewInit{
private volumeToggler!:VolumeToggling;
//why it doesnt work right
 ngAfterViewInit(): void {
    this.volumeToggler = new VolumeToggling();
    this.volumeToggler.initializeToggle();  
  }
}
