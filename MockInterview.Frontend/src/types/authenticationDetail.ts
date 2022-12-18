import {IMappable} from "@/types/common";

export interface IAuthenticationDetail {
    emailAddress: string,
    password: string
}

export class AuthenticationDetail implements IMappable<IAuthenticationDetail> {
    emailAddress!: string;
    password!: string;

    mapFrom(data: IAuthenticationDetail) {
        this.emailAddress = data.emailAddress;
        this.password = data.password;
    }
}