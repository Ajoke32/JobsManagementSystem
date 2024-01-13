import { DefaultParams } from "./defaultParams";

export interface CreateEpicParams<TData,TResponse>
 extends DefaultParams<TData,TResponse>{
    oftype:string,
};