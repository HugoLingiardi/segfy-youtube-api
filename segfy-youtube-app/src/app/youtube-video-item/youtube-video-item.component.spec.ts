import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { YoutubeVideoItemComponent } from './youtube-video-item.component';

describe('YoutubeVideoItemComponent', () => {
  let component: YoutubeVideoItemComponent;
  let fixture: ComponentFixture<YoutubeVideoItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ YoutubeVideoItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(YoutubeVideoItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
