import {IMappable} from "@/types/common";

export interface IProblemDetails {
    type?: string | undefined;
    title?: string | undefined;
    status?: number | undefined;
    detail?: string | undefined;
    instance?: string | undefined;
    // extensions: null
}

export class ProblemDetails implements IMappable<IProblemDetails> {
    type?: string | undefined;
    title?: string | undefined;
    status?: number | undefined;
    detail?: string | undefined;
    instance?: string | undefined;

    mapFrom(data: IProblemDetails) {
        this.type = data.type;
        this.title = data.title;
        this.status = data.status;
        this.detail = data.detail;
        this.instance = data.instance
    }
}