
import {ajax} from 'rxjs/ajax';
import { OperationStructure } from './operationStructure';

export const ajaxQuery = <T>(query:string, variables = null)=>{

    return ajax<OperationStructure<T>>({
        url:"/graphql",
        method:"POST",
        body:{
            query,
            variables
        }
    })
}