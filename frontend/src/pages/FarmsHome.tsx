import Loading from "@/components/Loading";
import CreateFarmDialog from "@/features/farms/components/CreateFarmDialog";
import Farms from "@/features/farms/components/Farms";
import { createFarm, getFarms } from "@/features/farms/services/farmService";
import { Box, Button, HStack, Text } from "@chakra-ui/react";
import { useQuery } from "@tanstack/react-query";
import { useActionState, useState } from "react";
import { useNavigate } from "react-router-dom";

const fetchFarms = async () => {
  const response = await getFarms();
  return response;
};

const FarmsHome = () => {
  const [dialogOpen, setDialogOpen] = useState(false);
  const navigate = useNavigate();

  const query = useQuery({
    queryKey: ["farms"],
    queryFn: fetchFarms,
  });

  const [error, submitAction, isPending] = useActionState(
    async (_previousState: unknown, formData: FormData) => {
      const { data, error } = await createFarm(formData);
      if (error) {
        return error;
      }

      setDialogOpen(false);
      navigate(`/farms/${data.id}`);

      return null;
    },
    null
  );

  const handleOpenDialog = () => {
    setDialogOpen(true);
  };

  if (query.isPending) {
    return <Loading />;
  }

  if (query.isError) {
    return <Text>Error fetching farms</Text>;
  }

  return (
    <Box>
      <HStack mb={4} justifyContent="space-between">
        <Text fontSize="xl" fontWeight="bold">
          Your Farms
        </Text>
        <Button variant="plain" onClick={handleOpenDialog}>
          + Create Farm
        </Button>
      </HStack>
      <Farms farms={query.data} />
      <CreateFarmDialog
        open={dialogOpen}
        setOpen={setDialogOpen}
        isPending={isPending}
        submitAction={submitAction}
      />
    </Box>
  );
};

export default FarmsHome;
