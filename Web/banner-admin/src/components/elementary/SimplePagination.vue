<template>
  <div class="row q-gutter-sm justify-center">
    <q-pagination class="lt-md" :model-value="page" @update:model-value="change($event - 1)" input
      :max="lastPage" />
    <q-btn class="gt-sm c-gray-color-600" @click="change(firstPage)" :disable="page == firstPage" label="最前頁" outline
      padding="6px 24px" rounded size="sm" />
    <q-btn class="gt-sm c-gray-color-600" @click="change(prevPage)" :disable="page == firstPage" label="上頁" outline
      padding="6px 24px" rounded size="sm" />
    <div class="gt-sm grey-7" style="padding:6px 0">第{{ page }} / {{ lastPage }}頁，共 {{ totalCount }} 筆</div>
    <q-btn class="gt-sm c-gray-color-600" @click="change(nextPage)" :disable="page == lastPage" label="下頁" outline
      padding="6px 24px" rounded size="sm" />
    <q-btn class="gt-sm c-gray-color-600" @click="change(lastPage)" :disable="page == lastPage" label="最後頁" outline
      padding="6px 24px" rounded size="sm" />
  </div>
</template>

<script lang="ts">
import { Emit, Prop } from "vue-property-decorator";
import { ElementaryBase } from "./ElementaryBase";

export default class SimplePagination extends ElementaryBase {
  @Prop() page !: 1;
  @Prop() size !: 5;
  @Prop() totalCount !: 0;
  get firstPage() { return 1; }
  get prevPage() { return this.page > this.firstPage ? this.page - 1 : this.firstPage; }
  get nextPage() { return this.page < this.lastPage ? this.page + 1 : this.lastPage; }
  get lastPage() { return Math.ceil(this.totalCount / this.size); }
  @Emit("change") change(page: number) { return page; }
}
</script>