import { Component, OnInit } from '@angular/core';
import { YourYoutubeViewModel } from '../viewmodel/your-youtube-viewmodel';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-videos',
  templateUrl: './videos.component.html',
  styleUrls: ['./videos.component.css']
})
export class VideosComponent implements OnInit {

  constructor(private spinner: NgxSpinnerService, public vm: YourYoutubeViewModel) { }

  ngOnInit(): void {
    this.loadData();
  }

  async loadData() {
    this.spinner.show();

    await this.vm.loadSavedVideos();
    window.scroll(0, 0);
    
    this.spinner.hide();
  }

  async nextPageLoadData() {
    this.spinner.show();

    await this.vm.loadNextPageSavedVideos();
    window.scroll(0, 0);

    this.spinner.hide();
  }

  async previousPageLoadData() {
    this.spinner.show();

    await this.vm.loadPreviousPageSavedVideos();
    window.scroll(0, 0);

    this.spinner.hide();
  }

  async filterYoutubeVideos() {
    this.spinner.show();

    await this.vm.loadYoutubeVideos(null);
    window.scroll(0, 0);

    this.spinner.hide();
  }

  async filterNextYoutubeVideos() {
    this.spinner.show();

    await this.vm.loadNextYoutubeVideos();
    window.scroll(0, 0);

    this.spinner.hide();
  }

  async filterPreviousYoutubeVideos() {
    this.spinner.show();

    await this.vm.loadPreviousYoutubeVideos();
    window.scroll(0, 0);

    this.spinner.hide();
  }

}
