import { Epic} from "redux-observable";
import { getUsersQuery } from "../queries/getUsersQuery";
import { createEpic } from "./generic/epicCreators";
import { fetchUsersFail, fetchUsersSuccess} from "../../store/slices/usersSlice";
import { User } from "../../types/user/UserType";
import { DefaultFetchResponse } from "./generic/interfaces/defaultFetchResponse";


export const fetchUsersEpic:Epic = createEpic<User[], {users:{all:DefaultFetchResponse<User[]>}}>({
    query:getUsersQuery,
    oftype:"users/fetchUsers",
    actions:{
        fail:fetchUsersFail,
        success:fetchUsersSuccess
    },
    responseResolver:(res)=>res.response.data.users.all,
});


