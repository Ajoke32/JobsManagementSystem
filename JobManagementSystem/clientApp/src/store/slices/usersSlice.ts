import {createSlice } from "@reduxjs/toolkit";
import { User } from "../../types/user/UserType";
import { DefaultFetchState, createFetchReducers } from "../generic/defaultFetchReducers";


interface UsersState extends DefaultFetchState<User[]>{
}

const initialState:UsersState = {
    loading:false,
    error:null,
    data:[]
}

const {fail,success,pending} = createFetchReducers<UsersState,User[]>({});

export const userSlice = createSlice({
    name:"users",
    initialState:initialState,
    reducers:{
        fetchUsers:pending,
        fetchUsersSuccess:success,
        fetchUsersFail:fail,
    }
});


export const {fetchUsers,fetchUsersFail,fetchUsersSuccess} = userSlice.actions;

export const usersReducer = userSlice.reducer;