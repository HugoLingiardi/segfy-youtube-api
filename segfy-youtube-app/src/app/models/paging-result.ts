export class PagingResult<T> {
    page: number;
    count: number;
    items: T[];
}