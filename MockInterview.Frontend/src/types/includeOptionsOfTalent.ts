import {IMappable} from "./common";

export interface IIncludeOptionsOfTalent {
    includeModels: string[];
}

export class IncludeOptionsOfTalent implements IMappable<IIncludeOptionsOfTalent> {
    includeModels!: string[];

    mapFrom(data: IIncludeOptionsOfTalent) {
        this.includeModels = data.includeModels
    }
}