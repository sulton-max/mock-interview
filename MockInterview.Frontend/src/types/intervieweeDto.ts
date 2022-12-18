import {IMappable, Util} from "@/types/common";
import {UserDto} from "@/types/userDto";

export interface IIntervieweeDto {
    id: number;
    user: UserDto;
}

export class IntervieweeDto implements IMappable<IIntervieweeDto> {
    id!: number;
    user!: UserDto | null;

    mapFrom(data: IIntervieweeDto) {
        this.id = data.id;
        this.user = Util.mapObject(data.user, UserDto);
    }
}