import { useAppDispatch } from "../store/hooks/useDispatch";
import { useTypedSelector } from "../store/hooks/useTypedSelector";
import { fetchUsers } from "../store/slices/usersSlice";




function SomeComponent() {
    
    const dispatch  = useAppDispatch();

    const {data:users,loading,error} = useTypedSelector((state)=>state.usersReducer);

    if(error!==null){
       return <div>error: {error}</div>
    }

    return <>
    {loading?(<p>loading...</p>)
    :<div>
        {users.map(u=><div key={u.id}>{u.email}</div>)}
    </div>}
    <button onClick={()=>{
        dispatch(fetchUsers());
    }}>Fetch users test</button>
    </>;
}

export default SomeComponent;