import {PayloadAction} from "@reduxjs/toolkit";





export const setupReducers =  <T>()=>{
   
    return {
        stateFunc:function createStateReducer(callback:(callbackState:T)=>void){
            
            return function(state:T){
                callback(state);
            }
        },
        payloadFunc:function createPayloadReducer<TPayload>(callback:(callbackState:T,callbackAction:PayloadAction<TPayload>)=>void){
        
            return function(state:T,action:PayloadAction<TPayload>){
                callback(state,action)
            }
        }
    }
}