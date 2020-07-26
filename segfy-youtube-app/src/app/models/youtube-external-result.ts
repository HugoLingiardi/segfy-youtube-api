export interface Id {
    kind: string;
    videoId: string;
    channelId?: any;
}

export interface Medium {
    url: string;
    width: number;
    height: number;
}

export interface High {
    url: string;
    width: number;
    height: number;
}

export interface Thumbnails {
    _default?: any;
    medium: Medium;
    high: High;
}

export interface Snippet {
    publishedAt: Date;
    channelId: string;
    title: string;
    description: string;
    thumbnails: Thumbnails;
    channelTitle: string;
    liveBroadcastContent: string;
    publishTime: Date;
}

export interface Item {
    kind: string;
    etag: string;
    id: Id;
    snippet: Snippet;
}

export interface YoutubeExternalResult {
    previousPageToken?: string;
    nextPageToken?: string;
    items: Item[];
}