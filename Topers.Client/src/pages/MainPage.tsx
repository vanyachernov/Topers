import Header from '../widgets/Header'
import { ChakraProvider, Box, Flex, Heading, Text, Button, Image } from '@chakra-ui/react'
import HeroSection from '../shared/HeroSection'
import GoodsSection from '../shared/GoodsSection'


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
            <GoodsSection />
        </Box>
      </Box>
    </ChakraProvider>
  )
}

export default MainPage
