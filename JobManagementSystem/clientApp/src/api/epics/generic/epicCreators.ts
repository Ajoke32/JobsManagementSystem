import { Epic, ofType } from "redux-observable";
import {map, mergeMap,catchError, of} from 'rxjs';
import { ajaxQuery } from '../../../utils/query';
import { CreateEpicParams } from "./interfaces/epicParms";
import { DefaultParams } from "./interfaces/defaultParams";


const defaultQueryFlow = <TData, TResponse>({responseResolver,query,actions}:DefaultParams<TData,TResponse>) => {
    
    const {fail,success} = actions;
    return mergeMap(()=>{
        return ajaxQuery<TResponse>(query).pipe(
            map(res=>{
                const {isSuccess,data,errors} = responseResolver(res);
                
                if(errors!==null && errors.length!==0){
                    return fail(errors[0].message);        
                }
        
                if(!isSuccess){
                    return fail('operation failed, try again later or inform our support');
                }
                
                return success(data);
            }),
            catchError(err=>of(fail(err)))
        );
    });
};


export const createEpic = function createDefaultApiEpic<TData, TResponse>(
    {oftype,query, actions,responseResolver:respRes}:CreateEpicParams<TData,TResponse>
    ){
    
    const epic:Epic = $action =>$action.pipe(
        ofType(oftype),
        defaultQueryFlow({
            query:query,
            responseResolver:respRes,
            actions:actions
        }),    
    );

    return epic;
};






