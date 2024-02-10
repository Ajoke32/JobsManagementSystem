import {PayloadAction, createSlice } from "@reduxjs/toolkit";
import { ParsingOptions } from "../../types/user/options/parsingOptions";
import { setupReducers } from "../generic/reducerFucntions";


interface EventSourceState{
    connected:boolean,
    parsingStarted:boolean,
    parsingOptions:ParsingOptions|null
}

const initialState:EventSourceState = {
    connected:false,
    parsingStarted:false,
    parsingOptions:null
}

const {payloadFunc,stateFunc} = setupReducers<EventSourceState>();

export const eventSourceSlice = createSlice({
    name:"eventSource",
    initialState:initialState,
    reducers:{
        runParsing:payloadFunc<ParsingOptions>((state,action)=>{
            state.parsingOptions = action.payload;
            state.parsingStarted = true;
            state.connected = true;
        }),
        stopParsing:stateFunc((state)=>{
            state.parsingStarted = false;
        }),
        disconect:stateFunc((state)=>{
            state.connected = false;
        })
    }
});


export const {runParsing,disconect,stopParsing} = eventSourceSlice.actions;

export const eventSourceReducer = eventSourceSlice.reducer;