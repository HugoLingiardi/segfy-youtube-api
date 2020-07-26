import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatDialogModule } from '@angular/material/dialog';
import { MatTabsModule } from '@angular/material/tabs';
import { MatInputModule } from '@angular/material/input';
import { MatDividerModule } from '@angular/material/divider'
import { MatToolbarModule } from '@angular/material/toolbar'
import { MatIconModule } from '@angular/material/icon'
import { MatSidenavModule } from '@angular/material/sidenav';
import { MainNavComponent } from './main-nav/main-nav.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatButtonModule } from '@angular/material/button';
import { MatListModule } from '@angular/material/list';
import { MatCardModule } from '@angular/material/card';

import { NgxSpinnerModule } from 'ngx-spinner';

import { VideosComponent } from './videos/videos.component';
import { ChannelsComponent } from './channels/channels.component';
import { VideoItemComponent } from './video-item/video-item.component'
import { YourYoutubeViewModel } from './viewmodel/your-youtube-viewmodel';
import { YourYoutubeApiService } from './services/your-youtube-api-service';
import { YoutubeApiService } from './services/youtube-api-service';
import { YoutubeVideoItemComponent, AlreadyExistsVideoDialog } from './youtube-video-item/youtube-video-item.component';
import { HttpConfigInterceptor } from './services/http-config-interceptor';
import { ChannelItemComponent } from './channel-item/channel-item.component';
import { YoutubeChannelItemComponent, AlreadyExistsChannelDialog } from './youtube-channel-item/youtube-channel-item.component';

@NgModule({
  declarations: [
    AppComponent,
    MainNavComponent,
    VideosComponent,
    ChannelsComponent,
    VideoItemComponent,
    YoutubeVideoItemComponent,
    AlreadyExistsVideoDialog,
    AlreadyExistsChannelDialog,
    ChannelItemComponent,
    YoutubeChannelItemComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatIconModule,
    MatSidenavModule,
    LayoutModule,
    MatButtonModule,
    MatListModule,
    MatCardModule,
    HttpClientModule,
    MatDividerModule,
    NgxSpinnerModule,
    MatInputModule,
    MatDialogModule,
    MatTabsModule,
  ],
  exports: [],
  entryComponents: [YoutubeVideoItemComponent, AlreadyExistsVideoDialog, YoutubeChannelItemComponent, AlreadyExistsChannelDialog,],
  providers: [YourYoutubeViewModel, YourYoutubeApiService, YoutubeApiService, { provide: HTTP_INTERCEPTORS, useClass: HttpConfigInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
