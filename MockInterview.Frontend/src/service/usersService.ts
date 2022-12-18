import ServiceBase from "@/service/serviceBase";
import {DataSetResponse} from "@/types/common";
import {UserDto} from "@/types/userDto";
import {EntityQueryOptionsOfUser} from "@/types/entityQueryOptionsOfUser";

export class UsersService extends ServiceBase {
    public async getUserByFilter(entityQueryOptionsOfUser: EntityQueryOptionsOfUser): Promise<DataSetResponse<UserDto>> {
        const apiResponse = await this.getClient().request({
            method: 'POST',
            data: entityQueryOptionsOfUser,
            url: 'users/by-filter'
        })

        return new DataSetResponse(UserDto, apiResponse);
    }
}