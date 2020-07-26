import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MainNavComponent } from './main-nav/main-nav.component';
import { VideosComponent } from './videos/videos.component';
import { ChannelsComponent } from './channels/channels.component';


const routes: Routes = [    
  {
    path: 'videos',
    component: VideosComponent,
  },
  {
    path: 'channels',
    component: ChannelsComponent,
  },
  {
    path: '',
    redirectTo: '/videos',
    pathMatch: 'full',
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

}
