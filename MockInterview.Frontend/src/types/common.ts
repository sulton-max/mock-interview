type Constructor<T extends {} = {}> = new (...args: any[]) => T;

export interface IMappable<T> {
    mapFrom(data: object): void
}

export enum ErrorCode{
    Unknown,
    InternalServerError,
    BadRequest,
    ValidationError,
    NotFound,
    Unauthorized
}

export interface IErrorResponse {
    message: string;
    code: ErrorCode
}

export class ErrorResponse {
    public message!: string;
    public code!: ErrorCode;

    public mapFrom(data: IErrorResponse): void{
        this.message = data['message'];
        this.code = data['code'];
    }
}

export class ApiResponse implements IMappable<ApiResponse> {
    public successful!: boolean;
    public error!: ErrorResponse | null;


    public constructor(initialData?: object) {
        if (initialData != null) {
            this.mapFrom(initialData);
        }
    }

    public mapFrom(data: object): void {
        this.successful = data["successful" as keyof object];
        this.error = Util.mapObject(data["error" as keyof object], ErrorResponse);
    }
}

export class DataResponse<T extends IMappable<T>> extends ApiResponse{
    public data!: T;
    type!: Constructor<T>;

    constructor(type: Constructor<T>, initialData: object) {
        super();
        this.type = type;

        if(initialData != null) {
            this.mapFrom(initialData);
        }
    }

    public mapFrom(data: object): void{
        super.mapFrom(data);

        const dataObj = data["data" as keyof object];
        if(dataObj != null) {
            this.data = new this.type();
            this.data.mapFrom(dataObj);
        }
    }
}

export class DataSetResponse<T extends IMappable<T>> {
    public data!: Array<T>;
    type!: Constructor<T>;

    constructor(type: Constructor<T>, initialData: object) {
        this.type = type;

        if(initialData != null) {
            this.mapFrom(initialData);
        }
    }

    public mapFrom(data: object) {
        const dataObjArray = data["data" as keyof object] as Array<object>;
        if (dataObjArray != null) {
            this.data = new Array<T>();

            dataObjArray.forEach(dataObj => {
                const objInst = new this.type();
                objInst.mapFrom(dataObj);
                this.data.push(objInst)
            })
        }
    }

}


export class Util {
    public static mapArray<T extends IMappable<T>>(source: Array<object>, TCreator: Constructor<T>): Array<T> | null {
        if (source === null) {
            return null;
        }

        const mapped = new Array<T>();

        if (source == null) {
            return mapped;
        }

        for (let i = 0; i < source.length; i++) {
            // eslint-disable-next-line @typescript-eslint/ban-ts-comment
            // @ts-ignore
            if (source[i]['id'] === null) {
                // eslint-disable-next-line @typescript-eslint/ban-ts-comment
                // @ts-ignore
                source[i]['id'] = i + 1;
            }
            // eslint-disable-next-line @typescript-eslint/ban-ts-comment
            // @ts-ignore
            mapped.push(Util.mapObject(source[i], TCreator));
        }

        return mapped;
    }

    public static mapObject<T extends IMappable<T>>(source: object, TCreator: Constructor<T>): T | null {
        if (source == null) {
            return null;
        }
        const inst = new TCreator();
        inst.mapFrom(source);
        return inst;
    }

    public static parseDate(dateString: string): Date | null {
        if ((dateString == null) || (dateString == "")) {
            return null;
        }
        return new Date(dateString);
    }
}