import { Farm } from "@/types";
import { Flex } from "@chakra-ui/react";
import FarmCard from "./FarmCard";
import { useNavigate } from "react-router-dom";

interface FarmsProps {
  farms?: Farm[];
}

const Farms = ({ farms }: FarmsProps) => {
  const navigate = useNavigate();

  const handleFarmClick = (id: string) => {
    navigate(`/farms/${id}`);
  };

  return (
    <Flex gap="4" wrap="wrap">
      {farms?.map((farm) => (
        <FarmCard
          key={farm.id}
          farm={farm}
          onClick={() => handleFarmClick(farm.id)}
        />
      ))}
    </Flex>
  );
};

export default Farms;
