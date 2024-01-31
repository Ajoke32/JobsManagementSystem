import './Header.css';
import {useRef, useState} from "react";

interface HeaderItem{
    id:number,
    title:string,
    style:string
}
const headerItems:HeaderItem[] = [
    {id:0,title:'Main',style:"active-item"},
    {id:1,title:'Recommendations',style:""},
    {id:2,title:'Settings',style:""},
    {id:3,title:'Scrap',style:""},
]

const Header = () => {

    const activeItem = useRef(0);

    const [items, setItems] = useState<HeaderItem[]>(headerItems);
    const handleClick = (i:number)=>{
        headerItems[activeItem.current].style = "";
        headerItems[i].style = "active-item";
        activeItem.current = i;

        setItems([...headerItems]);
    }

    return (
        <div className='header'>
            {items.map((i,index)=>{
                return <div onClick={()=>handleClick(index)} className={i.style}>{i.title}</div>
            })}
        </div>
    );
};

export default Header;
