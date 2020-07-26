import { Component, OnInit, Input } from '@angular/core';
import { Channels } from '../models/channels';
import { YourYoutubeViewModel } from '../viewmodel/your-youtube-viewmodel';

@Component({
  selector: 'app-channel-item',
  templateUrl: './channel-item.component.html',
  styleUrls: ['./channel-item.component.css']
})
export class ChannelItemComponent implements OnInit {
  @Input() channel: Channels;

  constructor(public vm: YourYoutubeViewModel) { }

  ngOnInit(): void {
  }

  openChannelUrl() {
    window.open(`https://www.youtube.com/channel/${this.channel.channelId}`, '_blank');
  }

  deleteSavedVideo() {
    this.vm.deleteSavedChannel(this.channel.channelId);
  }
  
}
