import {ContactDto} from "@/types/contactDto";
import {TalentDto} from "@/types/talentDto";
import {IMappable, Util} from "@/types/common";

export interface IUserDto {
    id: number;
    firstName: string;
    lastName: string;
    emailAddress: string;
    gender: string;
    dateOfBirth: Date;
    photoStorageId: number;
    password: string;
    contact: ContactDto;
    talent: TalentDto;
}

export class UserDto implements IMappable<IUserDto> {
    id!: number;
    firstName!: string;
    lastName!: string;
    emailAddress!: string;
    gender!: string;
    dateOfBirth!: Date;
    photoStorageId!: number;
    password!: string;
    contact!: ContactDto | null;
    talent!: TalentDto | null;

    mapFrom(data: IUserDto) {
        this.id = data.id;
        this.firstName = data.firstName;
        this.lastName = data.lastName;
        this.emailAddress = data.emailAddress;
        this.gender = data.gender;
        this.dateOfBirth = data.dateOfBirth;
        this.photoStorageId = data.photoStorageId;
        this.password = data.password;
        this.contact = Util.mapObject(data.contact, ContactDto);
        this.talent = Util.mapObject(data.talent, TalentDto);
    }
}