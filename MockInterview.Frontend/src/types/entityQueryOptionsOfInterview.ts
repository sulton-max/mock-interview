import {FilterOptionsOfInterview} from "./filterOptionsOfInterview";
import {IncludeOptionsOfInterview} from "./includeOptionsOfInterview";
import {SortOptions} from "./sortOptions";
import {PaginationOptions} from "./paginationOptions";
import {IMappable, Util} from "./common";

export interface IEntityQueryOptionsOfInterview {
    filterOptions: FilterOptionsOfInterview;
    includeOptions: IncludeOptionsOfInterview;
    sortOptions: SortOptions;
    paginationOptions: PaginationOptions;
}

export class EntityQueryOptionsOfInterview implements IMappable<IEntityQueryOptionsOfInterview> {
    filterOptions!: FilterOptionsOfInterview | null;
    includeOptions!: IncludeOptionsOfInterview | null;
    sortOptions!: SortOptions | null;
    paginationOptions!: PaginationOptions | null;

    mapFrom(data: IEntityQueryOptionsOfInterview) {
        this.filterOptions = Util.mapObject(data.filterOptions, FilterOptionsOfInterview);
        this.includeOptions = Util.mapObject(data.includeOptions, IncludeOptionsOfInterview);
        this.sortOptions = Util.mapObject(data.sortOptions, SortOptions);
        this.paginationOptions = Util.mapObject(data.paginationOptions, PaginationOptions);
    }
}
