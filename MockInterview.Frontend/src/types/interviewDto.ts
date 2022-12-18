import {InterviewerDto} from "./interviewerDto";
import {IntervieweeDto} from "./intervieweeDto";
import {IMappable} from "./common";

export interface IInterviewDto {
    id: number;
    createdDate: Date;
    updatedDate: Date;
    interviewTime: Date;
    status: string;
    interviewer: InterviewerDto;
    interviewee: IntervieweeDto;
}

export class InterviewDto implements IMappable<IInterviewDto> {
    id!: number;
    createdDate!: Date;
    updatedDate!: Date;
    interviewTime!: Date;
    status!: string;
    interviewer!: InterviewerDto | null;
    interviewee!: IntervieweeDto | null;

    mapFrom(data: IInterviewDto) {
        this.id = data.id;
        this.createdDate = data.createdDate;
        this.updatedDate = data.updatedDate;
        this.interviewTime = data.interviewTime;
        this.status = data.status;
        this.interviewer = data.interviewer;
        this.interviewee = data.interviewee;
    }
}