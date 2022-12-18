import {IMappable} from "./common";

export interface ISelectionItemDto {
    id: number;
    type: string;
    value: string;
    displayValue: string;
}

export class SelectionItemDto implements IMappable<ISelectionItemDto> {
    id!: number;
    type!: string;
    value!: string;
    displayValue!: string;

    mapFrom(data: ISelectionItemDto) {
        this.id = data.id;
        this.type = data.type;
        this.value = data.value;
        this.displayValue = data.displayValue;
    }
}
