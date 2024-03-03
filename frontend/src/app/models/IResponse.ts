export interface IResponse {
    status: ResponseStatus;
    message: string;
    errors?: string[];
}

export interface IResponseT<T> extends IResponse {
    value?: T;
}

export enum ResponseStatus {
    Success = 0,
    Error = 1,
}
