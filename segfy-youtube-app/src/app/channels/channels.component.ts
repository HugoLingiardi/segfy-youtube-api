import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { YourYoutubeViewModel } from '../viewmodel/your-youtube-viewmodel';

@Component({
  selector: 'app-channels',
  templateUrl: './channels.component.html',
  styleUrls: ['./channels.component.css']
})
export class ChannelsComponent implements OnInit {

  constructor(private spinner: NgxSpinnerService, public vm: YourYoutubeViewModel) { }

  ngOnInit(): void {
    this.loadData();
  }

  async loadData() {
    this.spinner.show();

    await this.vm.loadSavedChannels();
    window.scroll(0, 0);
    
    this.spinner.hide();
  }

  async nextPageLoadData() {
    this.spinner.show();

    await this.vm.loadNextPageSavedChannels();
    window.scroll(0, 0);

    this.spinner.hide();
  }

  async previousPageLoadData() {
    this.spinner.show();

    await this.vm.loadPreviousPageSavedChannels();
    window.scroll(0, 0);

    this.spinner.hide();
  }

  async filterYoutubeChannels() {
    this.spinner.show();

    await this.vm.loadYoutubeChannels(null);
    window.scroll(0, 0);

    this.spinner.hide();
  }

  async filterNextYoutubeChannels() {
    this.spinner.show();

    await this.vm.loadNextYoutubeChannels();
    window.scroll(0, 0);

    this.spinner.hide();
  }

  async filterPreviousYoutubeChannels() {
    this.spinner.show();

    await this.vm.loadPreviousYoutubeChannels();
    window.scroll(0, 0);

    this.spinner.hide();
  }
}
