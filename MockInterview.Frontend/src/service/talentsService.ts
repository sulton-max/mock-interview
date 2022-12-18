import ServiceBase from "@/service/serviceBase";
import {DataResponse} from "@/types/common";
import {TalentDto} from "@/types/talentDto";

export class TalentsService extends ServiceBase {
    public async getById(id: number): Promise<DataResponse<TalentDto>>{
        const apiResponse = await this.getClient().request({
            method: 'GET',
            url: `talents/${id}`
        })

        return new DataResponse(TalentDto, apiResponse);
    }

    public async updateById(talentDto: TalentDto, id: number) {
        const apiResponse = await this.getClient().request({
            method: 'PUT',
            url: `talents/${id}`
        })

        return apiResponse;
    }

    public async deleteById(id: number) {
        const apiResponse = await this.getClient().request({
            method: 'DELETE',
            url: `talents/${id}`
        })

        return apiResponse
    }

}