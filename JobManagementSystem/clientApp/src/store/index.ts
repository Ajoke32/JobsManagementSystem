import { combineReducers, configureStore} from '@reduxjs/toolkit';
import { counterReducer } from './slices/counterSlice';
import { usersReducer } from './slices/usersSlice';
import { combineEpics, createEpicMiddleware } from 'redux-observable';
import { fetchUsersEpic } from '../api/epics/fetchUsersEpic';
import { eventSourceReducer } from './slices/eventSourceSlice';


const rootEpic = combineEpics(fetchUsersEpic);

const epicMiddleware = createEpicMiddleware();


const rootReducer = combineReducers({
    countReducer:counterReducer,
    usersReducer:usersReducer,
    eventSourceReducer:eventSourceReducer
});

export const store = configureStore({
    reducer:rootReducer,
    middleware:(getDefaultMiddleware) => getDefaultMiddleware().concat(epicMiddleware)
});

epicMiddleware.run(rootEpic);


export type RootState = ReturnType<typeof store.getState>


export type AppDispatch = typeof store.dispatch;