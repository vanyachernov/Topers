import {
  Card,
  CardBody,
  Image,
  Text,
  Heading,
  Stack,
  ButtonGroup,
  Button,
  CardFooter,
  Divider,
} from "@chakra-ui/react";
import React from "react";

interface GoodCardProps {
  goodId: string;
  goodTitle: string;
  goodDescription: string;
  goodLitre: number;
  goodImage: string;
  goodPrice: number;
}

const GoodCard: React.FC<GoodCardProps> = ({
  goodId,
  goodTitle,
  goodDescription,
  goodLitre,
  goodImage,
  goodPrice
}) => {
  return (
    <Card maxW="sm" key={goodId}>
      <CardBody>
        <Image
          src={goodImage}
          alt={goodTitle}
          borderRadius="lg"
          objectFit="contain"
          h="160px"
          mx="auto"
        />
        <Stack mt="6" spacing="3">
          <Heading size="md">{goodLitre} litre</Heading>
          <Text>
            {goodDescription}
          </Text>
          <Text color="teal" fontSize="sm" fontWeight="bold">
            {goodPrice} $
          </Text>
        </Stack>
      </CardBody>
      <Divider />
      <CardFooter>
        <ButtonGroup spacing="2">
          <Button variant="solid" colorScheme="teal">
            Buy now
          </Button>
          <Button variant="ghost" colorScheme="teal">
            Add to cart
          </Button>
        </ButtonGroup>
      </CardFooter>
    </Card>
  );
};

export default GoodCard;