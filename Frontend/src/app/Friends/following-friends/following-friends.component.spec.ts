import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FollowingFriendsComponent } from './following-friends.component';

describe('FollowingFriendsComponent', () => {
  let component: FollowingFriendsComponent;
  let fixture: ComponentFixture<FollowingFriendsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FollowingFriendsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FollowingFriendsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
