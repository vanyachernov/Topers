import Header from '../widgets/Header'
import { ChakraProvider, Box, Flex, Heading, Text, Button, Image } from '@chakra-ui/react'
import HeroSection from '../widgets/HeroSection'


function MainPage() {
  return (
    <ChakraProvider>
      <Box bgColor='#E1F9D9'>
        <Box 
          maxWidth='1280px'
          margin='auto'>
          <Header></Header>
          <HeroSection />
        </Box>
      </Box>
      <Box bgColor='#EAFBFF'>
        <Box 
          maxWidth='1280px'
          margin='auto'>
          
        </Box>
      </Box>
    </ChakraProvider>
  )
}

export default MainPage
