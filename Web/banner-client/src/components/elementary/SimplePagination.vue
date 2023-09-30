<template>
  <div class="row q-gutter-sm justify-center">
    <q-pagination class="lt-sm" :model-value="page" @change="change" input
      :max="lastPage"></q-pagination>
    <q-btn class="gt-xs c-gray-color-600" @click="change(firstPage)" :disable="page == firstPage" label="最前頁" outline
      padding="6px 12px" rounded size="sm" />
    <q-btn class="gt-xs c-gray-color-600" @click="change(prevPage)" :disable="page == firstPage" label="上頁" outline
      padding="6px 12px" rounded size="sm" />
    <div class="gt-xs grey-7" style="padding:6px 0">第{{ page }} / {{ lastPage }}頁，共 {{ rowsNumber }} 筆</div>
    <q-btn class="gt-xs c-gray-color-600" @click="change(nextPage)" :disable="page == lastPage" label="下頁" outline
      padding="6px 12px" rounded size="sm" />
    <q-btn class="gt-xs c-gray-color-600" @click="change(lastPage)" :disable="page == lastPage" label="最後頁" outline
      padding="6px 12px" rounded size="sm" />
  </div>
</template>

<script lang="ts">
import { Emit, Prop } from "vue-property-decorator";
import { ElementaryBase } from "./ElementaryBase";

export default class SimplePagination extends ElementaryBase {
  @Prop() page = 1;
  @Prop() rowsPerPage = 5;
  @Prop() rowsNumber = 0;
  get firstPage() { return 1; }
  get prevPage() { return this.page > this.firstPage ? this.page - 1 : this.firstPage; }
  get nextPage() { return this.page < this.lastPage ? this.page + 1 : this.lastPage; }
  get lastPage() { return Math.floor(this.rowsNumber / this.rowsPerPage) + 1 }
  @Emit("change") change(page: number) { return page; }
}
</script>