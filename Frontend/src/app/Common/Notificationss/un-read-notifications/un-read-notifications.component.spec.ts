import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UnReadNotificationsComponent } from './un-read-notifications.component';

describe('UnReadNotificationsComponent', () => {
  let component: UnReadNotificationsComponent;
  let fixture: ComponentFixture<UnReadNotificationsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UnReadNotificationsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UnReadNotificationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
