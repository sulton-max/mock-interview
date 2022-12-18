import {IMappable} from "./common";

export interface IIncludeOptionsOfInterview {
    includeModels: string[];
}

export class IncludeOptionsOfInterview implements IMappable<IIncludeOptionsOfInterview> {
    includeModels!: string[];

    mapFrom(data: IIncludeOptionsOfInterview) {
        this.includeModels = data.includeModels;
    }
}