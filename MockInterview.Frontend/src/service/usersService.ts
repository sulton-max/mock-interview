import ServiceBase from "@/service/serviceBase";
import {DataSetResponse} from "@/types/common";
import {UserDto} from "@/types/userDto";
import {EntityQueryOptions} from "@/types/entityQueryOptions";

export class UsersService extends ServiceBase {
    public async getUserByFilter(entityQueryOptions: EntityQueryOptions): Promise<DataSetResponse<UserDto>> {
        const apiResponse = await this.getClient().request({
            method: 'POST',
            data: entityQueryOptions,
            url: 'users/by-filter'
        })

        return new DataSetResponse(UserDto, apiResponse);
    }

    public async deleteById(id: number) {
        const apiResponse = await this.getClient().request({
            method: 'DELETE',
            url: `users/${id}`
        })

        return apiResponse;
    }

    public async postUser(userDto: UserDto) {
        const apiResponse = await this.getClient().request({
            method: 'POST',
            data: userDto,
            url: 'users'
        });

        return apiResponse
    }

    public async updateById(userDto: UserDto, id: number) {
        const apiResponse = await this.getClient().request({
            method: 'PUT',
            data: userDto,
            url: `user/${id}`
        });

        return apiResponse;
    }
}