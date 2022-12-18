import {IMappable} from "./common";

export interface ISortOptions {
    sortField: string;
    sortAscending: boolean;
}

export class SortOptions implements IMappable<ISortOptions> {
    sortField!: string;
    sortAscending!: boolean;

    mapFrom(data: ISortOptions) {
        this.sortField = data.sortField;
        this.sortAscending = data.sortAscending;
    }
}