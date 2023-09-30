import { ComponentBase } from "src/components/ComponentBase";
/* eslint-enable */
import { Pagination } from "src/data/dto";

export class ListComponentBase extends ComponentBase {
  // ========== props ==========

  // ========== data ==========
  isLoading = true;

  pagination = new Pagination();

  // ========== computed ==========

  // ========== watch ==========

  // ========== methods ==========
  updatePagination(paging: Pagination) {
    const { currentPage, size, totalCount, pageCount } = paging;

    this.pagination.currentPage = currentPage;
    this.pagination.size = size;
    this.pagination.totalCount = totalCount;
    this.pagination.pageCount = pageCount;
  }
}
