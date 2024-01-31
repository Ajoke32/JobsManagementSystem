import { Provider } from 'react-redux'
import { store } from './store'
import './App.css';
import MainBody from "./components/ui/MainBody/MainBody.tsx";



function App() {
  

  return (
    <Provider store={store}>
    <div className='main'>
      <MainBody />
    </div>
    </Provider>
  )
}

export default App
