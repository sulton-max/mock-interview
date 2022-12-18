import {FilterOptions} from "./filterOptions";
import {IncludeOptions} from "./includeOptions";
import {SortOptions} from "./sortOptions";
import {PaginationOptions} from "./paginationOptions";
import {IMappable, Util} from "./common";

export interface IEntityQueryOptions {
    filterOptions: FilterOptions;
    includeOptions: IncludeOptions;
    sortOptions: SortOptions;
    paginationOptions: PaginationOptions;
}

export class EntityQueryOptions implements IMappable<IEntityQueryOptions> {
    filterOptions!: FilterOptions | null;
    includeOptions!: IncludeOptions | null;
    sortOptions!: SortOptions | null;
    paginationOptions!: PaginationOptions | null;

    mapFrom(data: IEntityQueryOptions) {
        this.filterOptions = Util.mapObject(data.filterOptions, FilterOptions);
        this.includeOptions = Util.mapObject(data.includeOptions, IncludeOptions);
        this.sortOptions = Util.mapObject(data.sortOptions, SortOptions);
        this.paginationOptions = Util.mapObject(data.paginationOptions, PaginationOptions);
    }
}
