import { Component, OnInit, Input } from '@angular/core';
import { Item } from '../models/youtube-external-result';
import { YourYoutubeViewModel } from '../viewmodel/your-youtube-viewmodel';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-youtube-channel-item',
  templateUrl: './youtube-channel-item.component.html',
  styleUrls: ['./youtube-channel-item.component.css']
})
export class YoutubeChannelItemComponent implements OnInit {
  @Input() channel: Item;

  constructor(private vm: YourYoutubeViewModel, public dialog: MatDialog) { }

  ngOnInit(): void {
  }

  async saveChannel() {
    var result = await this.vm.saveYoutubeChannel(this.channel);

    if (!result) {
      this.dialog.open(AlreadyExistsChannelDialog);
    }
  }

}

@Component({
  selector: 'already-exists-channel-dialog',
  template: `<h1 mat-dialog-title>Attention!</h1>
  <div mat-dialog-content>This channel was previously saved, choose another one.</div>
  <div mat-dialog-actions>
    <button mat-raised-button mat-dialog-close>Close</button>
  </div>
  `,
})
export class AlreadyExistsChannelDialog { }