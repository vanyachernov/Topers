import React from "react";
import { Box, Flex, Text, Heading, Button, Image } from "@chakra-ui/react";
import { FaLongArrowAltRight } from "react-icons/fa";
import handsImage from "../app/images/stock_bg_hands.jpg";

export default function HeroSection() {
  return (
    <Flex
      className="first-screen"
      direction={["column", "row"]}
      align="center"
      justify="space-between"
      height="80vh"
      px={4}
    >
      <Box flex="1">
        <Heading as="h1" size="xl" mb={6} maxWidth="16em">
          A reliable helper for your plant
        </Heading>
        <Text fontSize="lg" mb={10} maxWidth="28em">
          TOPERS is a manufacturer and supplier of complex water-soluble
          fertilisers for good and safe plant growth
        </Text>
        <Button
          colorScheme="teal"
          size="lg"
          rightIcon={<FaLongArrowAltRight />}
        >
          Goods
        </Button>
      </Box>
      <Box flex="1" minWidth="200px" minHeight="200px" posi>
        <Image
          src={handsImage}
          alt="Hands"
          boxSize="100%"
          minWidth="200px"
          minHeight="200px"
          sx={{
            mixBlendMode: "multiply",
            backgroundColor: "transparent",
          }}
        />
      </Box>
    </Flex>
  );
}
