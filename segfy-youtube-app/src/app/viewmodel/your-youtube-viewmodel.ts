import { YourYoutubeApiService } from '../services/your-youtube-api-service';
import { YoutubeApiService } from '../services/youtube-api-service';
import { Videos } from '../models/videos';
import { Injectable } from '@angular/core';
import { Item } from '../models/youtube-external-result';
import { Channels } from '../models/channels';

@Injectable()
export class YourYoutubeViewModel {

    constructor(private yourtubeApi: YourYoutubeApiService,
        private youtubeApi: YoutubeApiService) {
    }

    savedVideos: Videos[];

    isLoadingSavedVideos: boolean = false;
    errorLoadingSavedVideos: boolean = false;

    actualPageVideos: number = 1;
    maxResultsSavedVideos: number = 10;
    isThereNextPageVideos: boolean = false;

    async loadNextPageSavedVideos() {
        this.actualPageVideos += 1;

        await this.loadSavedVideos();
    }

    async loadPreviousPageSavedVideos() {
        this.actualPageVideos -= 1;

        await this.loadSavedVideos();
    }

    async loadSavedVideos() {
        this.isLoadingSavedVideos = true;
        this.errorLoadingSavedVideos = false;

        try {
            const resultado = await this.yourtubeApi.getVideos({ page: this.actualPageVideos, maxResults: this.maxResultsSavedVideos });

            this.savedVideos = resultado.items;
            this.isThereNextPageVideos = (resultado.count / (this.maxResultsSavedVideos * this.actualPageVideos)) > 1;
        } catch (error) {
            this.errorLoadingSavedVideos = true;
        } finally {
            this.isLoadingSavedVideos = false;
        }
    }

    filterYoutubeVideos: string = "";

    isLoadingYoutubeVideos: boolean = false;
    errorLoadingYoutubeVideos: boolean = false;

    filteredYoutubeVideos: Item[] = [];
    nextPageTokenYoutubeVideos: string = "";
    previousPageTokenYoutubeVideos: string = "";

    async loadPreviousYoutubeVideos() {
        await this.loadYoutubeVideos(this.previousPageTokenYoutubeVideos);
    }

    async loadNextYoutubeVideos() {
        await this.loadYoutubeVideos(this.nextPageTokenYoutubeVideos);
    }

    async loadYoutubeVideos(pageToken: string) {
        this.isLoadingYoutubeVideos = true;
        this.errorLoadingYoutubeVideos = false;

        try {
            const results = await this.youtubeApi.getVideos({ search: this.filterYoutubeVideos, pageToken: pageToken });

            this.filteredYoutubeVideos = results.items;
            this.nextPageTokenYoutubeVideos = results.nextPageToken;
            this.previousPageTokenYoutubeVideos = results.previousPageToken;
        } catch (error) {
            this.errorLoadingYoutubeVideos = true;
        } finally {
            this.isLoadingYoutubeVideos = false;
        }
    }

    async saveYoutubeVideo(video: Item) : Promise<boolean> {
        const newVideo: Videos = {
            title: video.snippet.title,
            channelTitle: video.snippet.channelTitle,
            description: video.snippet.description,
            thumbnailUrl: video.snippet.thumbnails.medium.url,
            videoId: video.id.videoId,
        };

        var result = await this.yourtubeApi.getVideo(newVideo.videoId);

        if (result && result.videoId) {
            return false;
        }

        await this.yourtubeApi.saveVideo(newVideo);
        await this.loadSavedVideos();

        return true;
    }

    async deleteSavedVideo(videoId: string) {
        await this.yourtubeApi.deleteVideo(videoId);
        await this.loadSavedVideos();
    }


    //channels

    savedChannels: Channels[];

    isLoadingSavedChannels: boolean = false;
    errorLoadingSavedChannels: boolean = false;

    actualPageChannels: number = 1;
    maxResultsSavedChannels: number = 10;
    isThereNextPageChannels: boolean = false;

    async loadNextPageSavedChannels() {
        this.actualPageChannels += 1;

        await this.loadSavedChannels();
    }

    async loadPreviousPageSavedChannels() {
        this.actualPageChannels -= 1;

        await this.loadSavedChannels();
    }

    async loadSavedChannels() {
        this.isLoadingSavedChannels = true;
        this.errorLoadingSavedChannels = false;

        try {
            const resultado = await this.yourtubeApi.getChannels({ page: this.actualPageChannels, maxResults: this.maxResultsSavedChannels });

            this.savedChannels = resultado.items;
            this.isThereNextPageChannels = (resultado.count / (this.maxResultsSavedChannels * this.actualPageChannels)) > 1;
        } catch (error) {
            this.errorLoadingSavedChannels = true;
        } finally {
            this.isLoadingSavedChannels = false;
        }
    }

    filterYoutubeChannels: string = "";

    isLoadingYoutubeChannels: boolean = false;
    errorLoadingYoutubeChannels: boolean = false;

    filteredYoutubeChannels: Item[] = [];
    nextPageTokenYoutubeChannels: string = "";
    previousPageTokenYoutubeChannels: string = "";

    async loadPreviousYoutubeChannels() {
        await this.loadYoutubeChannels(this.previousPageTokenYoutubeChannels);
    }

    async loadNextYoutubeChannels() {
        await this.loadYoutubeChannels(this.nextPageTokenYoutubeChannels);
    }

    async loadYoutubeChannels(pageToken: string) {
        this.isLoadingYoutubeChannels = true;
        this.errorLoadingYoutubeChannels = false;

        try {
            const results = await this.youtubeApi.getChannels({ search: this.filterYoutubeChannels, pageToken: pageToken });

            this.filteredYoutubeChannels = results.items;
            this.nextPageTokenYoutubeChannels = results.nextPageToken;
            this.previousPageTokenYoutubeChannels = results.previousPageToken;
        } catch (error) {
            this.errorLoadingYoutubeChannels = true;
        } finally {
            this.isLoadingYoutubeChannels = false;
        }
    }

    async saveYoutubeChannel(video: Item) : Promise<boolean> {
        const newChannel: Channels = {
            title: video.snippet.title,
            description: video.snippet.description,
            thumbnailUrl: video.snippet.thumbnails.medium.url,
            channelId: video.id.channelId,
        };

        var result = await this.yourtubeApi.getChannel(newChannel.channelId);

        if (result && result.channelId) {
            return false;
        }

        await this.yourtubeApi.saveChannel(newChannel);
        await this.loadSavedChannels();

        return true;
    }

    async deleteSavedChannel(channelId: string) {
        await this.yourtubeApi.deleteChannel(channelId);
        await this.loadSavedChannels();
    }

}