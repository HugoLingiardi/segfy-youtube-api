import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { YoutubeChannelItemComponent } from './youtube-channel-item.component';

describe('YoutubeChannelItemComponent', () => {
  let component: YoutubeChannelItemComponent;
  let fixture: ComponentFixture<YoutubeChannelItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ YoutubeChannelItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(YoutubeChannelItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
