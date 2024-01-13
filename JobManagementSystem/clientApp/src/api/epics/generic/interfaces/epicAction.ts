import {ActionCreatorWithPayload } from '@reduxjs/toolkit';


export interface EpicAction<Tdata>{
    success:ActionCreatorWithPayload<Tdata>,
    fail:ActionCreatorWithPayload<string|null>,
}