import Header from '../widgets/Header'
import { ChakraProvider } from '@chakra-ui/react'

function App() {
  return (
    <ChakraProvider>
      <div className="root">
        <div className='wrapper'>
          <Header></Header>
        </div>
      </div>
    </ChakraProvider>
  )
}

export default App
