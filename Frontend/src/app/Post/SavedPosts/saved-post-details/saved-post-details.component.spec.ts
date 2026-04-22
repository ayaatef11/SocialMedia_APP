import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SavedPostDetailsComponent } from './saved-post-details.component';

describe('SavedPostDetailsComponent', () => {
  let component: SavedPostDetailsComponent;
  let fixture: ComponentFixture<SavedPostDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SavedPostDetailsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SavedPostDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
