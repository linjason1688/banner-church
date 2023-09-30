import { SortProperty } from "src/api/feature";

export interface PagedRequest {
  page: number;
  size: number;
  sortProperties: SortProperty[];
}
