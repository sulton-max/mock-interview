import {QueryFilter} from "./queryFilter";
import {IMappable, Util} from "./common";

export interface IFilterOptions {
    filters: Array<QueryFilter>;
}

export class FilterOptions implements IMappable<IFilterOptions> {
    filters!: Array<QueryFilter> | null;

    mapFrom(data: IFilterOptions) {
        this.filters = Util.mapArray(data.filters, QueryFilter);
    }
}