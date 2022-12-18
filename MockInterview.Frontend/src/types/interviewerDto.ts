import {IMappable, Util} from "@/types/common";
import {UserDto} from "@/types/userDto";

export interface IInterviewerDto {
    id: number;
    user: UserDto;
}

export class InterviewerDto implements IMappable<IInterviewerDto> {
    id!: number;
    user!: UserDto | null;

    mapFrom(data: IInterviewerDto) {
        this.id = data.id;
        this.user = Util.mapObject(data.user, UserDto);
    }
}