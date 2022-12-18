import {IMappable} from "./common";

export interface IQueryFilter {
    key: string;
    value: string;
}

export class QueryFilter implements IMappable<IQueryFilter> {
    key!: string;
    value!: string;

    mapFrom(data: IQueryFilter) {
        this.key = data.key;
        this.value = data.value;
    }
}