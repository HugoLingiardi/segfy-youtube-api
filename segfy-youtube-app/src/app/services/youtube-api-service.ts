import { HttpClient } from '@angular/common/http';
import { YoutubeQueryParams } from '../models/youtube-query-params';
import { YoutubeExternalResult } from '../models/youtube-external-result';
import { Injectable } from '@angular/core';

@Injectable()
export class YoutubeApiService {

    urlApi: string;

    constructor(private httpClient: HttpClient) {
        // this.urlApi = "https://localhost:44379/api/youtube";
        this.urlApi = "http://segfyyoutubeapi-env.eba-u4hcnqhu.us-east-1.elasticbeanstalk.com/api/youtube";
    }

    getVideos(filter: YoutubeQueryParams): Promise<YoutubeExternalResult> {
        var params = this.getParamsFromFilter(filter);

        return this.httpClient.get<YoutubeExternalResult>(`${this.urlApi}/videos`, { params: params }).toPromise();
    }

    getChannels(filter: YoutubeQueryParams): Promise<YoutubeExternalResult> {
        var params = this.getParamsFromFilter(filter);

        return this.httpClient.get<YoutubeExternalResult>(`${this.urlApi}/channels`, { params: params }).toPromise();
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


}