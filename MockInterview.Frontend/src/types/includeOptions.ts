import {IMappable} from "./common";

export interface IIncludeOptions  {
    includeModels: Array<string>;
}

export class IncludeOptions implements IMappable<IIncludeOptions> {
    includeModels!: Array<string>;

    mapFrom(data: IIncludeOptions) {
        this.includeModels = data.includeModels;
    }
}