import React from "react";
import { CiPillsBottle1 } from "react-icons/ci";
import { Text, Box, IconButton, Icon } from '@chakra-ui/react';

export default function Cart({ cartItemCount, cartOpen, setCartOpen }) {
  return (
    <Box position="relative">
      <IconButton
        aria-label="Cart"
        icon={<Icon as={CiPillsBottle1} />}
        variant="transparent"
        size="lg"
        fontSize="25px"
        onClick={() => setCartOpen(cartOpen = !cartOpen)}
        className={cartOpen ? 'active' : ''}
      />
      {cartItemCount > 0 && (
        <Box
          position="absolute"
          bottom="0"
          right="0"
          width="20px"
          height="20px"
          bg="green.500"
          borderRadius="full"
          display="flex"
          alignItems="center"
          justifyContent="center"
        >
          <Text fontSize="xs" color="white">
            {cartItemCount}
          </Text>
        </Box>
      )}
    </Box>
  );
}
