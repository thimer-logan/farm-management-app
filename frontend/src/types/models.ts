import { Polygon } from "geojson";

export interface User {
  id: string;
  name: string;
  email: string;
  phone: string;
}

export interface Farm {
  id: string;
  name: string;
  location: string;
  totalArea: number;
}

export interface Field {
  id: string;
  farmId: string;
  name: string;
  boundary: Polygon;
  area: number;
}
