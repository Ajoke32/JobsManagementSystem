import { Provider } from 'react-redux'
import './App.css'
import SomeComponent from './components/SomeComponents'
import { store } from './store'

function App() {
  

  return (
    <Provider store={store}>
    <>
      <div>
          App changed
      </div>
      <SomeComponent />
    </>
    </Provider>
  )
}

export default App
