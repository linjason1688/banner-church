export class Pagination {
  /**
   *
   * @type {number}
   */
  totalCount = 0;
  /**
   *
   * @type {number}
   */
  pageCount = 0;
  /**
   *
   * @type {number}
   */
  currentPage = 0;
  /**
   *
   * @type {number}
   */
  size = 0;

  /**
   *
   * @type {number}
   */
  pageSize = 0;
  /**
   *
   * @type {boolean}
   */
  hasPreviousPages = false;
  /**
   *
   * @type {boolean}
   */
  hasNextPages = false;
  /**
   *
   * @type {number}
   */
  previousLastPageNo = 0;
  /**
   *
   * @type {number}
   */
  nextStartPageNo = 0;
  /**
   *
   * @type {Array<number>}
   */
  navigationPages: number[] = [];
}
