import {QueryFilter} from "./queryFilter";
import {IMappable, Util} from "./common";

export interface IFilterOptionsOfTalent {
    filters: Array<QueryFilter>;
}

export class FilterOptionsOfTalent implements IMappable<IFilterOptionsOfTalent> {
    filters!: Array<QueryFilter> | null;

    mapFrom(data: IFilterOptionsOfTalent) {
        this.filters = Util.mapArray(data.filters, QueryFilter);
    }
}