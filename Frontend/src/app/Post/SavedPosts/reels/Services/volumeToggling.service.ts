
export class VolumeToggling{

 volumeIcon: HTMLElement | null;

constructor(){
 this.volumeIcon = document.getElementById('volumeIcon');
}

 initializeToggle():void{
if (this.volumeIcon) {
  this.volumeIcon.addEventListener('click', () => {
    if (this.volumeIcon!.classList.contains('bi-volume-mute-fill')) {
      this.volumeIcon!.classList.remove('bi-volume-mute-fill');
      this.volumeIcon!.classList.add('bi-volume-up-fill');
    } else {
      this.volumeIcon!.classList.remove('bi-volume-up-fill');
      this.volumeIcon!.classList.add('bi-volume-mute-fill');
    }
  });
}
}
}