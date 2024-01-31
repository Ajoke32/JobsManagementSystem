import './MainBody.css';
import Header from "../Header/Header.tsx";
import { useRef,useState } from 'react';
import { SubmitHandler, useForm } from 'react-hook-form';
import { DelayType, ParsingOptions } from '../../../types/user/options/parsingOptions.ts';




const MainBody = () => {


    

    const [items,setItems] = useState<string[]>();


    const {register, handleSubmit,getValues} = useForm<ParsingOptions>();


    const eventSourceUrl = "http://localhost:5041/message";

 
    const connectToEvent = function(){
        const eventSource = new EventSource(eventSourceUrl);
        // eventSource.onmessage = function(event){
        //     const item  = JSON.parse(event.data);
        //     console.log(item);
        //     setItems([...items,...item]);
        // }
        eventSource.onmessage = function(event){
            console.log(JSON.parse(event.data));
        }       
    }
    

    /*TODO: TO REDUX*/ 

    const runParsing = function(data:ParsingOptions){
        
        fetch("http://localhost:5041/parse",
        {
            method:"POST",
            body:JSON.stringify(data)
        }).then(res=>{

           console.log(res);

        }).catch(err=>{
            console.log(err);
        })
    }

    const onSubmit: SubmitHandler<ParsingOptions> = data =>{
        connectToEvent();
        runParsing(data);
    };

    return (
        <>
            <Header />
            <div className='main-wrapper'>
    
                <form onSubmit={handleSubmit(onSubmit)}>
                    <div className='select-group'>
                        <span>Delay type</span>
                        <select {...register("delayType")} value={getValues('delayType')}>
                            <option value={DelayType.Thread}>Thread</option>
                            <option value={DelayType.Task}>Task</option>
                            <option value={DelayType.Chrome}>Driver</option>
                        </select>    
                    </div>

                    <div className='select-group'>
                        <span>Enter delay</span>
                        <input {...register('delayMs')} type="number" placeholder='1000' />    
                    </div>

                    
                    <div className='select-group'>
                        <span>Display parsing progrees(parsed pages)</span>
                        <input {...register('sendParsedPagesNotification')} type="checkbox" placeholder='1000' />    
                    </div>

                    <div className='select-group'>
                        <span>Display parsing progress (parsed items)</span>
                        <input {...register('sendPercentageNotification')} type="checkbox" placeholder='1000' />    
                    </div>

                    <button>Submit</button>
                </form>
            
            </div>
        </>
    );
};

export default MainBody;
