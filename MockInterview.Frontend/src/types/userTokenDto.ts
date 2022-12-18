import {IMappable} from "@/types/common";

export interface IUserTokenDto {
    id: number,
    talentId: number,
    token: string,
    expireTime: Date | string
}

export class UserTokenDto implements IMappable<IUserTokenDto> {
    id!: number;
    talentId!: number;
    token!: string;
    expireTime!: Date | string;

    mapFrom(data: IUserTokenDto) {
        this.id = data.id;
        this.talentId = data.talentId;
        this.token = data.token;
        this.expireTime = data.expireTime;
    }
}