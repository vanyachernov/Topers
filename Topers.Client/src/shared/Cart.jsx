import React from "react";
import { CiPillsBottle1 } from "react-icons/ci";
import { Text, Box, IconButton, Icon, Flex } from '@chakra-ui/react';

export default function Cart({ cartItemCount, cartTotalPrice, cartOpen, setCartOpen }) {
  return (
    <Box 
      border='1px solid gray'
      borderRadius='15px'
    >
      <Flex alignItems='center'>
        <IconButton
          aria-label="Cart"
          icon={<Icon as={CiPillsBottle1} />}
          variant="transparent"
          size="lg"
          fontSize="25px"
          onClick={() => setCartOpen(!cartOpen)}
          className={cartOpen ? 'active' : ''}
        />
        {cartItemCount > 0 && (
          <Text marginRight='10px'>
            {cartTotalPrice} £
          </Text>
        )}
      </Flex>
    </Box>
  );
}
