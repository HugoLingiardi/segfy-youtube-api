import { Component, OnInit, Input } from '@angular/core';
import { Item } from '../models/youtube-external-result';
import { YourYoutubeViewModel } from '../viewmodel/your-youtube-viewmodel';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-youtube-video-item',
  templateUrl: './youtube-video-item.component.html',
  styleUrls: ['./youtube-video-item.component.css']
})
export class YoutubeVideoItemComponent implements OnInit {
  @Input() video: Item;

  constructor(private vm: YourYoutubeViewModel, public dialog: MatDialog) { }

  ngOnInit(): void {
  }

  async saveVideo() {
    var result = await this.vm.saveYoutubeVideo(this.video);

    if (!result) {
      this.dialog.open(AlreadyExistsVideoDialog);
    }
  }

}


@Component({
  selector: 'already-exists-channel-dialog',
  template: `<h1 mat-dialog-title>Attention!</h1>
  <div mat-dialog-content>This video was previously saved, choose another one.</div>
  <div mat-dialog-actions>
    <button mat-raised-button mat-dialog-close>Close</button>
  </div>
  `,
})
export class AlreadyExistsVideoDialog { }