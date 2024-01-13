import { PayloadAction } from "@reduxjs/toolkit";


export interface DefaultFetchState<T>{
   data:T,
   error:string|null,
   loading:boolean
}

interface CreateFetchReducerParams<TState extends DefaultFetchState<TData>, TData>{
    onSuccess?:(state:TState,action:PayloadAction<TData>)=>void,
    onFail?:(state:TState,action:PayloadAction<string|null>)=>void
}

interface FetchReducer<TState,TData>{
    pending:(state:TState)=>void,
    fail:(state:TState,action:PayloadAction<string|null>)=>void,
    success:(state:TState,action:PayloadAction<TData>)=>void
}

export const createFetchReducer = function createDefaultFetchReducers<TState extends DefaultFetchState<TData>,TData>(
    {onSuccess,onFail}:CreateFetchReducerParams<TState,TData>
    ):FetchReducer<TState,TData>
{

    return {
        pending:(state:TState)=>{
            state.loading = true;
        },
        fail:(state:TState,action:PayloadAction<string|null>)=>{
            state.error = action.payload;
            state.loading = false;
            if(onFail!==undefined){
                onFail(state,action);
            }
        },
        success:(state:TState,action:PayloadAction<TData>)=>{
            state.data = action.payload;
            state.loading = false;
            if(onSuccess!==undefined){
                onSuccess(state,action);
            }
        }
    }

}