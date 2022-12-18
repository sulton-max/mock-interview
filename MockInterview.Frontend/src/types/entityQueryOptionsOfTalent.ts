import {FilterOptionsOfTalent} from "./filterOptionsOfTalent";
import {IncludeOptionsOfTalent} from "./includeOptionsOfTalent";
import {SortOptions} from "./sortOptions";
import {PaginationOptions} from "./paginationOptions";
import {IMappable, Util} from "./common";

export interface IEntityQueryOptionsOfTalent {
    filterOptions: FilterOptionsOfTalent;
    includeOptions: IncludeOptionsOfTalent;
    sortOptions: SortOptions;
    paginationOptions: PaginationOptions;
}

export class EntityQueryOptionsOfTalent implements IMappable<IEntityQueryOptionsOfTalent> {
    filterOptions!: FilterOptionsOfTalent | null;
    includeOptions!: IncludeOptionsOfTalent | null;
    sortOptions!: SortOptions | null;
    paginationOptions!: PaginationOptions | null;

    mapFrom(data: IEntityQueryOptionsOfTalent) {
        this.filterOptions = Util.mapObject(data.filterOptions, FilterOptionsOfTalent);
        this.includeOptions = Util.mapObject(data.includeOptions, IncludeOptionsOfTalent);
        this.sortOptions = Util.mapObject(data.sortOptions, SortOptions);
        this.paginationOptions = Util.mapObject(data.paginationOptions, PaginationOptions);
    }
}
