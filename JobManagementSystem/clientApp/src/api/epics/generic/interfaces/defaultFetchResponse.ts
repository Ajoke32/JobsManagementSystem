


interface ResponseError{
    code:string,
    message:string
}

export interface DefaultFetchResponse<TData>{
    data:TData,
    isSuccess:boolean,
    errors:ResponseError[]|null
}