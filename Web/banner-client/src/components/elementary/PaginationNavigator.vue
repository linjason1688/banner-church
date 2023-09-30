<template>
  <div class="flex justify-end items-center">
    <div v-if="pagination.pageCount > 1" class="q-my-md">
      <q-pagination
        @update:model-value="handlePageChange"
        v-model="page"
        class="q-mr-lg"
        :max="pagination.pageCount"
        :max-pages="7"
        boundary-numbers
        rounded
      />
    </div>
    <div class="flex items-center">
      <span class="q-mr-md">總筆數：{{ pagination.totalCount || 0 }}</span>
      <span class="q-mr-md">總頁數：{{ pagination.pageCount || 0 }}</span>
      <span>顯示筆數：</span>
      <q-select v-model="size" :options="sizeOptions" class="q-mr-md" @update:model-value="handleSizeChange" />
    </div>
  </div>
</template>

<script lang="ts">
// Component
import { PagedRequest, Pagination } from "src/data/dto";
import { Options } from "vue-class-component";
import { Emit, Prop } from "vue-property-decorator";
import { ElementaryBase } from "./ElementaryBase";

@Options({})
export default class PaginationNavigator extends ElementaryBase {
  @Prop({ default: () => new Pagination() })
  private pagination!: Pagination;

  private page = 1;
  private size = 10;

  private sizeOptions = [10, 25, 50, 100];

  updated() {
    // this.page = this.pagination.currentPage || 1;
    // this.size = this.pagination.size || 10;
  }

  @Emit("change")
  handlePageChange(e: number): PagedRequest {
    this.page = e;
    return {
      page: e,
      size: this.size,
    };
  }

  @Emit("change")
  handleSizeChange(e: number): PagedRequest {
    this.size = e;
    return {
      page: this.page,
      size: e,
    };
  }
}
</script>
