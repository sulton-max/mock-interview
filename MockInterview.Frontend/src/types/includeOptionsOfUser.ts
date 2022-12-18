import {IMappable} from "./common";

export interface IIncludeOptionsOfUser {
    includeModels: string[];
}

export class IncludeOptionsOfUser implements IMappable<IIncludeOptionsOfUser> {
    includeModels!: string[];

    mapFrom(data: IIncludeOptionsOfUser) {
        this.includeModels = data.includeModels
    }
}