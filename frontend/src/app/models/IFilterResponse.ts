import { IResponseT } from "./IResponse";

export interface IFilterResponse<T> extends IResponseT<T> {
    count: number;
    page: number;
    skip: number;
}

export interface IGetRequest {
    filter?: Record<string, any>;
    skip?: number;
    take?: number;
}