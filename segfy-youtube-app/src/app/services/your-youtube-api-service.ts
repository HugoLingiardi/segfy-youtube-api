import { HttpClient } from '@angular/common/http';
import { PagingResult } from '../models/paging-result';

import { Videos } from '../models/videos';
import { Channels } from '../models/channels';
import { GetFilter } from '../models/get-filter';
import { Injectable } from '@angular/core';

@Injectable()
export class YourYoutubeApiService {
    urlApi: string;

    constructor(private httpClient: HttpClient) {
        // this.urlApi = "https://localhost:44379/api/youryoutube";
        this.urlApi = "http://segfyyoutubeapi-env.eba-u4hcnqhu.us-east-1.elasticbeanstalk.com/api/youryoutube";
    }

    getVideos(filter: GetFilter): Promise<PagingResult<Videos>> {
        const params = this.getParamsFromFilter(filter);

        return this.httpClient.get<PagingResult<Videos>>(`${this.urlApi}/videos`, { params: params }).toPromise();
    }

    getChannels(filter: GetFilter): Promise<PagingResult<Channels>> {
        const params = this.getParamsFromFilter(filter);

        return this.httpClient.get<PagingResult<Channels>>(`${this.urlApi}/channels`, { params: params }).toPromise();
    }

    getVideo(videoId: string): Promise<Videos> {
        return this.httpClient.get<Videos>(`${this.urlApi}/video/${videoId}`).toPromise();
    }

    getChannel(channelId: string): Promise<Channels> {
        return this.httpClient.get<Channels>(`${this.urlApi}/channel/${channelId}`).toPromise();
    }

    private getParamsFromFilter(params: any): any {
        var r = {};

        for (const key in params) {
            if (params.hasOwnProperty(key)) {
                const element = params[key];

                if (element) {
                    var keyLower = key.toLocaleLowerCase();
                    r[keyLower] = element;
                }
            }
        }

        return r;
    }

    saveVideo(video: Videos): Promise<Object> {
        return this.httpClient.post<Object>(`${this.urlApi}/video`, video).toPromise();
    }

    deleteVideo(videoId: string): Promise<Object> {
        return this.httpClient.delete<Object>(`${this.urlApi}/video/${videoId}`).toPromise();
    }

    saveChannel(channel: Channels): Promise<Object> {
        return this.httpClient.post<Object>(`${this.urlApi}/channel`, channel).toPromise();
    }

    deleteChannel(channelId: string): Promise<Object> {
        return this.httpClient.delete<Object>(`${this.urlApi}/channel/${channelId}`).toPromise();
    }

}