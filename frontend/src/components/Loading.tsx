import { Spinner, Text, VStack } from "@chakra-ui/react";

const Loading = () => {
  return (
    <VStack>
      <Spinner color="colorPalette.600" />
      <Text color="colorPalette.600">Loading...</Text>
    </VStack>
  );
};

export default Loading;
