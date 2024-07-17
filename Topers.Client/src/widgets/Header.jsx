import React, { useEffect, useState } from 'react'
import { Image, Box, Divider, Button, Flex, Link, IconButton, Icon } from '@chakra-ui/react';
import Logo from '../app/images/logo.svg';
import '../app/styles/Header.css';
import Cart from '../shared/Cart';

export default function Header() {
    const [cartOpen, setCartOpen] = useState(false);
    const [cartItemCount, setCartItemCount] = useState(2);

    return (
        <header>
            <Box textAlign='right'>
                <Button 
                    colorScheme='transparent' 
                    color='black' 
                    size='sm'>
                        Sign In
                </Button>
            </Box>
            <Divider borderColor='gray' opacity='0.2' />
            <Box>
                <Flex as="nav" p="4" alignItems="center" justifyContent="space-between">
                    <Link href="#" mr="4" alignContent='left'>
                        <Image src={Logo} alt="Topers Logo" width='auto' height='40px' />
                    </Link>
                    <Flex className='navbar-links'>
                        <Link href="#about" className='navlinks'>
                            About
                        </Link>
                        <Link href="#goods" className='navlinks'>
                            Goods
                        </Link>
                        <Link href="#contacts" className='navlinks'>
                            Contacts
                        </Link>
                    </Flex>
                    <Cart 
                        cartItemCount={cartItemCount} 
                        cartOpen={cartOpen} 
                        setCartOpen={setCartOpen} 
                        className='shop-cart-button' />
                </Flex>
            </Box>
        </header>
    )
}