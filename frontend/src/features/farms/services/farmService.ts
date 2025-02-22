import { Farm } from "@/types";
import { ApiResult } from "@/types/api";

const demoFarms: Farm[] = [
  {
    id: "1",
    name: "Farm 1",
    location: "Location 1",
    totalArea: 100,
  },
  {
    id: "2",
    name: "Farm 2",
    location: "Location 2",
    totalArea: 200,
  },
];

export async function getFarms(): Promise<Farm[]> {
  // Simulate API request
  return new Promise((resolve) => {
    setTimeout(() => {
      resolve(demoFarms);
    }, 1000);
  });
}

export async function getFarmById(id: string): Promise<Farm | null> {
  // Simulate API request
  return new Promise((resolve) => {
    setTimeout(() => {
      const farm = demoFarms.find((farm) => farm.id === id);
      resolve(farm || null);
    }, 1000);
  });
}

export async function createFarm(formData: FormData): Promise<ApiResult<Farm>> {
  const farm = {
    name: formData.get("name") as string,
    location: formData.get("location") as string,
    totalArea: 0, // TODO: Get this value from the form
  };

  // Simulate API request
  return new Promise((resolve) => {
    setTimeout(() => {
      const newFarm = { ...farm, id: String(demoFarms.length + 1) };
      demoFarms.push(newFarm);
      resolve({ data: newFarm, error: null });
    }, 1000);
  });
}
