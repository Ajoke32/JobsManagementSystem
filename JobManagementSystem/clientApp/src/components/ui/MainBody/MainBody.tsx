import './MainBody.css';
import Header from "../Header/Header.tsx";
import { useEffect, useState } from 'react';
import { ParsingOptions } from '../../../types/user/options/parsingOptions.ts';
import { useTypedSelector } from '../../../store/hooks/useTypedSelector.ts';
import { SettingsForm } from '../../SettingsForm/SettingsForm.tsx';
import { useAppDispatch } from '../../../store/hooks/useDispatch.ts';
import { stopParsing } from '../../../store/slices/eventSourceSlice.ts';




const MainBody = () => {

    const dispatch = useAppDispatch();


    const {parsingOptions,parsingStarted} = useTypedSelector(s=>s.eventSourceReducer);


    const notificationsMap:Map<NotificationType,NotificationBase>  = new Map<NotificationType,NotificationBase>();

    const [notifications,setNotifications] = useState<Map<NotificationType,NotificationBase>>();

    const [items,setItems] = useState<NotificationBase[]>();


    const eventSourceUrl = "http://localhost:5041/message";

 
    const connectToEvent = function(){
        const eventSource = new EventSource(eventSourceUrl);
        // eventSource.onmessage = function(event){
        //     const item  = JSON.parse(event.data);
        //     console.log(item);
        //     setItems([...items,...item]);
        // }
        eventSource.onmessage = function(event){
            const data:NotificationBase = event.data as NotificationBase;
            
            if(data.type === NotificationType.Terminated
                ||data.type === NotificationType.Fail
                ||data.type === NotificationType.Finished){
                

                dispatch(stopParsing())
            }

            if(data.type === NotificationType.Success){
                notificationsMap.set(data.type,data);
                setNotifications({...notificationsMap});
            }
            
            console.log(JSON.parse(event.data));
        }       
    }
        
    useEffect(()=>{
        if(parsingOptions!==null){
            connectToEvent();
            runParsing(parsingOptions);
        }
    },[parsingOptions]);
    

    const runParsing = function(data:ParsingOptions){
        fetch("http://localhost:5041/parse",{
            method:"POST",
            body:JSON.stringify(data)
        }).then(res=>{
           console.log(res);
        }).catch(err=>{
            console.log(err);
        })
    }


    return (
        <>
            <Header />
            <div className='main-wrapper'>
    
               <div>
                <SettingsForm/>
               </div>
               {notifications!==undefined?
                <div>
                    <h4>Parsing status info</h4>
                    <div>
                        <span>{notifications.get(NotificationType.Success)?.description}</span>
                    </div>
                    <div>
                        <span>{(notifications.get(NotificationType.SuccessWithValue) as GenericNotification)?.description}</span>
                        <span>{(notifications.get(NotificationType.SuccessWithValue) as GenericNotification)?.message}</span>
                    </div>
                    <div>
                        <span>{notifications.get(NotificationType.Terminated)?.description}</span>
                    </div>
                    <div>
                        <span>{notifications.get(NotificationType.Fail)?.description}</span>
                    </div>
                    <div>
                        <span>{notifications.get(NotificationType.Finished)?.description}</span>
                    </div>
                </div>
                :
                <div>
                    Parsing information will displayed here
                </div>}
                <div>
                    Parsing values can be displayed here
                </div>
            </div>
        </>
    );
};

export default MainBody;
