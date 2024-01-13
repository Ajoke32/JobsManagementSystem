import { EpicAction } from "./epicAction";
import {AjaxResponse} from 'rxjs/ajax';
import { OperationStructure } from "../../../../utils/operationStructure";


export interface DefaultParams<TData,TResponse>{
    query:string,
    actions:EpicAction<TData>,
    responseResolver:(res:AjaxResponse<OperationStructure<TResponse>>)=>TData
};