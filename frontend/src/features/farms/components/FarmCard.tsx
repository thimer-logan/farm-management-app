import { Farm } from "@/types";
import { Box, Button, Card, HStack, Text } from "@chakra-ui/react";

interface FarmCardProps {
  farm: Farm;
  onClick?: () => void;
}

const FarmCard = ({ farm, onClick }: FarmCardProps) => {
  const handleClick = () => {
    if (onClick) {
      onClick();
    }
  };

  return (
    <Card.Root variant="elevated" flexBasis="320px">
      <Card.Body>
        <HStack justifyContent="space-between">
          <Box>
            <Card.Title>{farm.name}</Card.Title>
            <Card.Description>{farm.location}</Card.Description>
          </Box>
          <Text textStyle="lg">{farm.totalArea} acres</Text>
        </HStack>
      </Card.Body>
      <Card.Footer>
        <Button onClick={handleClick}>View</Button>
      </Card.Footer>
    </Card.Root>
  );
};

export default FarmCard;
