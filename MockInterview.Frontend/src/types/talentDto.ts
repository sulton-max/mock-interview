import {IMappable} from "@/types/common";

export interface ITalentDto {
    id: number;
    level: string;
    experience: string;
    projects: string;
}

export class TalentDto implements IMappable<ITalentDto> {
    id!: number;
    level!: string;
    experience!: string;
    projects!: string;

    mapFrom(data: ITalentDto) {
        this.id = data.id;
        this.level = data.level;
        this.experience = data.experience;
        this.projects = data.projects;
    }
}