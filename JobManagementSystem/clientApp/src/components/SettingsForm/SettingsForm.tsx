import { SubmitHandler, useForm } from "react-hook-form";
import { DelayType, ParsingOptions } from "../../types/user/options/parsingOptions";
import { useAppDispatch } from "../../store/hooks/useDispatch";
import {runParsing } from "../../store/slices/eventSourceSlice";
import './SettingsForm.css';



export const SettingsForm = ()=>{

    const dispatch = useAppDispatch();
    

    const {register, handleSubmit,getValues} = useForm<ParsingOptions>();
    

    const onSubmit: SubmitHandler<ParsingOptions> = data =>{
        dispatch(runParsing(data));
    };


    return (
        <form className="setting-form" onSubmit={handleSubmit(onSubmit)}>
            <div className='select-group'>
                <span>Delay type</span>
                <select {...register("delayType")} value={getValues('delayType')}>
                    <option value="Thread">Thread</option>
                    <option value="Task">Task</option>
                    <option value="Driver">Driver</option>
                </select>    
            </div>

            <div className='select-group'>
                <span>Enter delay</span>
                <input {...register('delayMs')} type="number" placeholder='1000' />    
            </div>

            
            <div className='select-group'>
                <input {...register('sendParsedPagesNotification')} type="checkbox" placeholder='1000' />
                <span>Display parsing progrees (parsed pages)</span>    
            </div>

            <div className='select-group'>
                <input {...register('sendPercentageNotification')} type="checkbox" placeholder='1000' />
                <span>Display parsing progress (parsed items)</span>
            </div>

            <button>Start parsing</button>
    </form>
    )
}