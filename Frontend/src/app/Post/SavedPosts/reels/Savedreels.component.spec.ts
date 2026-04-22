import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SavedReelsComponent } from './Savedreels.component';

describe('ReelsComponent', () => {
  let component: SavedReelsComponent;
  let fixture: ComponentFixture<SavedReelsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SavedReelsComponent]
    })
      .compileComponents();

    fixture = TestBed.createComponent(SavedReelsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
