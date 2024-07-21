import { AddIcon } from "@chakra-ui/icons";
import {
  Box,
  Button,
  Drawer,
  DrawerBody,
  DrawerCloseButton,
  DrawerContent,
  DrawerFooter,
  DrawerHeader,
  DrawerOverlay,
  Flex,
  FormLabel,
  Input,
  InputGroup,
  InputLeftAddon,
  InputRightAddon,
  Select,
  Stack,
  Textarea,
  useDisclosure,
} from "@chakra-ui/react";
import React from "react";

interface AuthDrawerProps {
  isOpen: boolean;
  onClose: () => void;
}

const AuthDrawer: React.FC<AuthDrawerProps> = ({ isOpen, onClose }) => {
  const firstField = React.useRef<HTMLInputElement>(null);

  return (
    <Drawer
      isOpen={isOpen}
      placement="right"
      initialFocusRef={firstField}
      onClose={onClose}
    >
      <DrawerOverlay />
      <DrawerContent>
        <DrawerCloseButton />
        <DrawerHeader borderBottomWidth="1px">
          Create a new account
        </DrawerHeader>

        <DrawerBody>
          <Stack spacing="24px">
            <Box>
              <FormLabel htmlFor="username">Username</FormLabel>
              <Input
                ref={firstField}
                id="username"
                placeholder="Please enter username"
              />
            </Box>

            <Box>
              <FormLabel htmlFor="password">Password</FormLabel>
              <Input
                ref={firstField}
                id="password"
                placeholder="Please enter password"
              />
            </Box>
            <Box borderTopWidth="1px">
              <Flex justifyContent='space-between'>
                <Button variant="outline" mt='14px' mr={3} onClick={onClose}>
                Cancel
                </Button>
                <Button colorScheme="teal" mt='14px'>Create</Button>
              </Flex>
            </Box>
          </Stack>
        </DrawerBody>
      </DrawerContent>
    </Drawer>
  );
};

export default AuthDrawer;