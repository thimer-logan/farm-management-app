import SubmitButton from "@/components/SubmitButton";
import {
  DialogActionTrigger,
  DialogBody,
  DialogCloseTrigger,
  DialogContent,
  DialogFooter,
  DialogHeader,
  DialogRoot,
  DialogTitle,
} from "@/components/ui/dialog";
import { Field } from "@/components/ui/field";
import { Button, Flex, Input, Stack } from "@chakra-ui/react";

interface CreateFarmDialogProps {
  open: boolean;
  setOpen: (isOpen: boolean) => void;
  isPending: boolean;
  submitAction: (payload: any) => void;
}

const CreateFarmDialog = ({
  open,
  setOpen,
  isPending,
  submitAction,
}: CreateFarmDialogProps) => {
  const handleOpenChange = (isOpen: boolean) => {
    setOpen(isOpen);
  };

  return (
    <DialogRoot open={open} onOpenChange={(e) => handleOpenChange(e.open)}>
      <DialogContent>
        <DialogHeader>
          <DialogTitle>Create Farm</DialogTitle>
        </DialogHeader>
        <DialogBody>
          <form action={submitAction}>
            <Stack gap="4" w="full">
              <Field label="Farm Name" required>
                <Input name="name" />
              </Field>
              <Field label="Address">
                <Input name="location" />
              </Field>
            </Stack>
            <Flex gap="4" mt="4" justifyContent="flex-end">
              <DialogActionTrigger asChild>
                <Button variant="outline">Cancel</Button>
              </DialogActionTrigger>
              <SubmitButton>Save</SubmitButton>
            </Flex>
          </form>
        </DialogBody>
        <DialogCloseTrigger />
      </DialogContent>
    </DialogRoot>
  );
};

export default CreateFarmDialog;
