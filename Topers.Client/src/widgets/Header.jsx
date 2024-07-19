import React, { useState } from 'react';
import { Image, Box, Divider, Button, Flex, Link, IconButton, Collapse, VStack } from '@chakra-ui/react';
import Logo from '../app/images/logo.svg';
import Cart from '../shared/Cart';
import { HamburgerIcon } from '@chakra-ui/icons';

export default function Header() {
    const [cartOpen, setCartOpen] = useState(false);
    const [cartItemCount, setCartItemCount] = useState(1);
    const [cartTotalPrice, setCartTotalPrice] = useState(100);
    const [isOpen, setIsOpen] = useState(false);

    const toggleMenu = () => setIsOpen(!isOpen);

    return (
        <header>
            <Divider borderColor='gray' opacity='0.2' />
            <Box>
                <Flex as="nav" p="4" alignItems="center" justifyContent="space-between">
                    <Link href="#" mr="4">
                        <Image src={Logo} alt="Topers Logo" width='auto' height='40px' />
                    </Link>
                    <Flex flex="1" justifyContent="center" display={{ base: 'none', md: 'flex' }}>
                        <Link href="#about" className='navlinks' mx={2}>
                            About
                        </Link>
                        <Link href="#goods" className='navlinks' mx={2}>
                            Goods
                        </Link>
                        <Link href="#contacts" className='navlinks' mx={2}>
                            Contacts
                        </Link>
                    </Flex>
                    <Flex flex='0.3' justifyContent="center" display={{ base: 'none', md: 'flex' }}>
                        <Button  
                            colorScheme='transparent' 
                            color='black' 
                            size='sm'
                            border='1px solid gray'>
                            Sign In
                        </Button>
                    </Flex>
                    <Flex alignItems="center" display={{ base: 'none', md: 'flex' }}>
                        <Cart 
                            cartItemCount={cartItemCount} 
                            cartTotalPrice={cartTotalPrice}
                            cartOpen={cartOpen} 
                            setCartOpen={setCartOpen} 
                            className='shop-cart-button' 
                        />
                    </Flex>
                    <IconButton
                        aria-label="Menu"
                        bgColor='transparent'
                        icon={<HamburgerIcon />}
                        onClick={toggleMenu}
                        display={{ base: 'block', md: 'none' }}
                    />
                </Flex>
                <Collapse in={isOpen} animateOpacity>
                    <VStack spacing={4} align="stretch" p={4} rounded='md' bgColor="#2ecc71" display={{ md: 'none' }}>
                        <Box width="100%" mb='10px'>
                            <Link href="#about" className='navlinks'>
                                About
                            </Link>
                        </Box>
                        <Box width="100%" mb='10px'>
                            <Link href="#goods" className='navlinks'>
                                Goods
                            </Link>
                        </Box>
                        <Box width="100%" mb='10px'>
                            <Link href="#contacts" className='navlinks'>
                                Contacts
                            </Link>
                        </Box>
                        <Box width="100%" display="flex" justifyContent="space-between" alignItems="center">
                            <Cart 
                                cartItemCount={cartItemCount} 
                                cartTotalPrice={cartTotalPrice}
                                cartOpen={cartOpen} 
                                setCartOpen={setCartOpen} 
                                className='shop-cart-button' 
                            />
                        </Box>
                    </VStack>
                </Collapse>
            </Box>
        </header>
    );
}
