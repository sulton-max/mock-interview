import {IMappable} from "./common";

export interface IPaginationOptions {
    pageSize: number;
    pageToken: number;
}

export class PaginationOptions implements IMappable<IPaginationOptions> {
    pageSize!: number;
    pageToken!: number;

    mapFrom(data: IPaginationOptions) {
        this.pageSize = data.pageSize;
        this.pageToken = data.pageToken;
    }
}