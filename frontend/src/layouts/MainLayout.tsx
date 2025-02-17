import { useColorModeValue } from "@/components/ui/color-mode";
import { DrawerContent, DrawerRoot } from "@/components/ui/drawer";
import { Box } from "@chakra-ui/react";
import { useState } from "react";
import Navbar from "@/components/Navigation/Navbar";
import Sidebar from "@/components/Navigation/Sidebar";
import { Outlet } from "react-router-dom";

const MainLayout = () => {
  const [open, setOpen] = useState(false);

  return (
    <Box minH={"100vh"} bg={useColorModeValue("gray.100", "gray.900")}>
      <Sidebar
        onClose={() => setOpen(false)}
        display={{ base: "none", md: "block" }}
      />

      <Navbar onOpen={() => setOpen(true)} />
      <DrawerRoot
        open={open}
        placement="start"
        onOpenChange={(e) => setOpen(e.open)}
        size="full"
        closeOnInteractOutside
      >
        <DrawerContent>
          <Sidebar onClose={() => setOpen(false)} />
        </DrawerContent>
      </DrawerRoot>
      <Box as="main" ml={{ base: 0, md: 60 }} p={4}>
        <Outlet />
      </Box>
    </Box>
  );
};

export default MainLayout;
