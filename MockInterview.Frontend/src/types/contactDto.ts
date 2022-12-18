import {IMappable} from "@/types/common";

export interface IContactDto {
    id: number;
    phoneNumber: number;
}

export class ContactDto implements IMappable<IContactDto> {
    id!: number;
    phoneNumber!: number;

    mapFrom(data: IContactDto) {
        this.id = data.id;
        this.phoneNumber = data.phoneNumber;
    }
}
