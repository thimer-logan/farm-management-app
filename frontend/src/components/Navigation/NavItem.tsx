import { Flex, Icon, Text } from "@chakra-ui/react";
import { IconType } from "react-icons";
import { NavLink, NavLinkProps } from "react-router-dom";

interface NavItemProps extends NavLinkProps {
  icon: IconType;
  children: React.ReactNode;
}

const NavItem = ({ icon, children, ...rest }: NavItemProps) => {
  return (
    <NavLink {...rest}>
      <Flex
        align="center"
        p="4"
        mx="4"
        borderRadius="lg"
        role="group"
        cursor="pointer"
        _hover={{ bg: "green.400", color: "white" }}
      >
        <Icon mr="4" fontSize="20px" as={icon} />
        <Text fontSize="lg">{children}</Text>
      </Flex>
    </NavLink>
  );
};

export default NavItem;
