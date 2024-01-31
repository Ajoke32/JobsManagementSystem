import { EpicAction } from "./epicAction";
import {AjaxResponse} from 'rxjs/ajax';
import { OperationStructure } from "../../../../utils/operationStructure";
import { DefaultFetchResponse } from "./defaultFetchResponse";


/*here resolver it`s not a graphQL resolver, it`s just function, that resolvers some value*/
export interface DefaultParams<TData,TResponse>{
    query:string,
    actions:EpicAction<TData>,
    responseResolver:(res:AjaxResponse<OperationStructure<TResponse>>)=>DefaultFetchResponse<TData>,
};