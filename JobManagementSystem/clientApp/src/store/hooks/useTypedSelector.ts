import { RootState } from "..";
import { useSelector } from 'react-redux'
import type { TypedUseSelectorHook } from 'react-redux'


export const useTypedSelector: TypedUseSelectorHook<RootState> = useSelector;