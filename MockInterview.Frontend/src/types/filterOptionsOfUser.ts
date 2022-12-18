import {QueryFilter} from "./queryFilter";
import {IMappable, Util} from "./common";

export interface IFilterOptionsOfUser {
    filters: Array<QueryFilter>;
}

export class FilterOptionsOfUser implements IMappable<IFilterOptionsOfUser> {
    filters!: Array<QueryFilter> | null;

    mapFrom(data: IFilterOptionsOfUser) {
        this.filters = Util.mapArray(data.filters, QueryFilter);
    }
}