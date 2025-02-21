import { Button } from "@chakra-ui/react";
import React from "react";
import { useFormStatus } from "react-dom";

interface SubmitButtonProps {
  children: React.ReactNode;
}

const SubmitButton = ({ children }: SubmitButtonProps) => {
  const { pending } = useFormStatus();
  return (
    <Button
      type="submit"
      loading={pending}
      loadingText="Loading"
      spinnerPlacement="start"
    >
      {children}
    </Button>
  );
};

export default SubmitButton;
