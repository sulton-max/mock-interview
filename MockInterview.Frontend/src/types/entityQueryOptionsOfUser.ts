import {FilterOptionsOfUser} from "./filterOptionsOfUser";
import {IncludeOptionsOfUser} from "./includeOptionsOfUser";
import {SortOptions} from "./sortOptions";
import {PaginationOptions} from "./paginationOptions";
import {IMappable, Util} from "./common";

export interface IEntityQueryOptionsOfUser {
    filterOptions: FilterOptionsOfUser;
    includeOptions: IncludeOptionsOfUser;
    sortOptions: SortOptions;
    paginationOptions: PaginationOptions;
}

export class EntityQueryOptionsOfUser implements IMappable<IEntityQueryOptionsOfUser> {
    filterOptions!: FilterOptionsOfUser | null;
    includeOptions!: IncludeOptionsOfUser | null;
    sortOptions!: SortOptions | null;
    paginationOptions!: PaginationOptions | null;

    mapFrom(data: IEntityQueryOptionsOfUser) {
        this.filterOptions = Util.mapObject(data.filterOptions, FilterOptionsOfUser);
        this.includeOptions = Util.mapObject(data.includeOptions, IncludeOptionsOfUser);
        this.sortOptions = Util.mapObject(data.sortOptions, SortOptions);
        this.paginationOptions = Util.mapObject(data.paginationOptions, PaginationOptions);
    }
}
