import ServiceBase from "@/service/serviceBase";
import {UserDto} from "@/types/userDto";
import {DataResponse, ErrorResponse} from "@/types/common";
import {UserTokenDto} from "@/types/userTokenDto";
import {AuthenticationDetail} from "@/types/authenticationDetail";
import {ProblemDetails} from "@/types/problemDetails";
import {AxiosError} from "axios";

export class AuthService extends ServiceBase {
    public async register(userDto: UserDto): Promise<DataResponse<UserTokenDto | ProblemDetails>>{
        const apiResponse = await this.getClient().request({
            method: 'POST',
            data: userDto,
            url: 'auth/register'
        });

        return new DataResponse(UserTokenDto, apiResponse);
    }

    public async login(authenticationDetail: AuthenticationDetail) {
        try {
            const apiResponse = await this.getClient().request({
                method: 'POST',
                data: authenticationDetail,
                url: 'auth/login'
            });

            return new DataResponse(UserTokenDto, apiResponse)
        }
        catch (error) {
            if (error instanceof AxiosError){
                return new DataResponse(ProblemDetails, error.response)
            }
        }
    }
}