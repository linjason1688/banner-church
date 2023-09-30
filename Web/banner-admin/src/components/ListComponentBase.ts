import { ComponentBase } from "src/components/ComponentBase";
import { PagedRequest, Pagination } from "src/data/dto";
export interface PagedResponse {
  currentPage: number;
  size: number;
  totalCount: number;
}

export class ListComponentBase extends ComponentBase {
  // ========== props ==========

  // ========== data ==========
  isLoading = true;

  pagination = new Pagination();

  // ========== computed ==========

  // ========== watch ==========

  // ========== methods ==========
  updatePagination(req: PagedRequest, res: PagedResponse) {
    this.pagination.sortProperties = req.sortProperties || [];
    this.pagination.size = req.size || this.pagination.size;
    this.pagination.page = req.page || 0;
    this.pagination.totalCount = res.totalCount || 0;
  }
}
