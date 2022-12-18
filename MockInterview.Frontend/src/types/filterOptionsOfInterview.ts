import {IQueryFilter, QueryFilter} from "./queryFilter";
import {IMappable, Util} from "./common";

export interface IFilterOptionsOfInterview {
    filters: Array<IQueryFilter>;
}

export class FilterOptionsOfInterview implements IMappable<IFilterOptionsOfInterview> {
    filters!: Array<IQueryFilter> | null

    mapFrom(data: IFilterOptionsOfInterview) {
        this.filters = Util.mapArray(data.filters, QueryFilter)
    }
}