import { Flex, FlexProps, HStack, IconButton, Text } from "@chakra-ui/react";
import { FiBell, FiMenu } from "react-icons/fi";
import {
  MenuContent,
  MenuItem,
  MenuRoot,
  MenuSeparator,
  MenuTrigger,
} from "../ui/menu";
import { Avatar } from "../ui/avatar";
import { useColorModeValue } from "../ui/color-mode";

interface NavbarProps extends FlexProps {
  onOpen: () => void;
}

const Navbar = ({ onOpen, ...rest }: NavbarProps) => {
  const name = "John Doe"; // Replace with user name

  return (
    <Flex
      ml={{ base: 0, md: 60 }}
      px={{ base: 4, md: 4 }}
      height="20"
      alignItems="center"
      bg={useColorModeValue("white", "gray.900")}
      borderBottomWidth="1px"
      borderBottomColor={useColorModeValue("gray.200", "gray.700")}
      justifyContent={{ base: "space-between", md: "flex-end" }}
      {...rest}
    >
      <IconButton
        display={{ base: "flex", md: "none" }}
        onClick={onOpen}
        variant="outline"
        aria-label="open menu"
      >
        <FiMenu />
      </IconButton>
      <Text
        display={{ base: "flex", md: "none" }}
        fontSize="2xl"
        fontFamily="monospace"
        fontWeight="bold"
      >
        Logo
      </Text>

      <HStack gap={{ base: "2", md: "6" }}>
        <IconButton size="lg" variant="ghost" aria-label="open menu">
          <FiBell />
        </IconButton>
        <Flex alignItems={"center"}>
          <MenuRoot>
            <MenuTrigger asChild>
              <IconButton
                variant="ghost"
                size="sm"
                px="0"
                borderRadius="full"
                aria-label="User menu"
              >
                <Avatar size="sm" name={name} />
              </IconButton>
            </MenuTrigger>
            <MenuContent>
              <MenuItem value="profile">Profile</MenuItem>
              <MenuItem value="settings">Settings</MenuItem>
              <MenuSeparator />
              <MenuItem value="signout">Sign out</MenuItem>
            </MenuContent>
          </MenuRoot>
        </Flex>
      </HStack>
    </Flex>
  );
};

export default Navbar;
