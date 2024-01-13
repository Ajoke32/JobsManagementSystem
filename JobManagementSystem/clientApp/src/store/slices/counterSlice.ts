import { createSlice } from "@reduxjs/toolkit";
import { RootState } from "..";



interface counterState{
    value:number;
}

const initialState = {
    value:0
}


export const counterSlice = createSlice({
    name:"counter",
    initialState,
    reducers:{
        increment:(state:counterState)=>{
            state.value+=1;
        }
    }
});



export const {increment} = counterSlice.actions;


export const selectCount = (state:RootState) => state.counter.value;

export const counterReducer = counterSlice.reducer;