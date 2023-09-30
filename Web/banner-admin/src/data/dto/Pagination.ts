import { SortProperty } from "src/api/feature";

export class Pagination {
	totalCount = 0;
	page = 1;
	size = 5;
	sortProperties = [] as SortProperty[];
}
