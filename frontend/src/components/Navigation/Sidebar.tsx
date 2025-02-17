import { Box, BoxProps, Flex, Text } from "@chakra-ui/react";
import { CloseButton } from "../ui/close-button";
import { useColorModeValue } from "../ui/color-mode";
import { FaHome, FaMap } from "react-icons/fa";
import NavItem from "./NavItem";

const links = [
  {
    to: "/",
    icon: FaHome,
    label: "Home",
  },
  {
    to: "/map",
    icon: FaMap,
    label: "Map",
  },
];

interface SidebarProps extends BoxProps {
  onClose: () => void;
}

const Sidebar = ({ onClose, ...rest }: SidebarProps) => {
  return (
    <Box
      // transition="3s ease"
      bg={useColorModeValue("white", "gray.900")}
      borderRightWidth="1px"
      borderRightColor={useColorModeValue("gray.200", "gray.700")}
      w={{ base: "full", md: 60 }}
      pos="fixed"
      h="full"
      {...rest}
    >
      <Flex h="20" alignItems="center" mx="8" justifyContent="space-between">
        <Text fontSize="2xl" fontFamily="monospace" fontWeight="bold">
          Logo
        </Text>
        <CloseButton display={{ base: "flex", md: "none" }} onClick={onClose} />
      </Flex>
      {links.map((link) => (
        <NavItem key={link.to} to={link.to} icon={link.icon}>
          {link.label}
        </NavItem>
      ))}
    </Box>
  );
};

export default Sidebar;
