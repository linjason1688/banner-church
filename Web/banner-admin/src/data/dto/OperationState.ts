import { HashMap } from "src/data/dto/HashMap";

export interface OperationState extends HashMap<boolean> {
  create: boolean;
  edit: boolean;
  remove: boolean;
}
