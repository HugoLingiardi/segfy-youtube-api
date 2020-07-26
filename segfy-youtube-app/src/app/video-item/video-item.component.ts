import { Component, OnInit, Input } from '@angular/core';
import { Videos } from '../models/videos';
import { YourYoutubeViewModel } from '../viewmodel/your-youtube-viewmodel';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-video-item',
  templateUrl: './video-item.component.html',
  styleUrls: ['./video-item.component.css']
})
export class VideoItemComponent implements OnInit {
  @Input() video: Videos;

  constructor(public vm: YourYoutubeViewModel) { }

  ngOnInit(): void {
  }

  openVideoUrl() {
    window.open(`https://www.youtube.com/watch?v=${this.video.videoId}`, '_blank');
  }

  deleteSavedVideo() {
    this.vm.deleteSavedVideo(this.video.videoId);
  }

}
