<template>
  <q-table class="q-mb-md" :loading="loading" :rows="rows" :columns="columns" :pagination="pagination"
    @update:pagination="paginate" loading-label="載入中，請稍候..." no-data-label="查無資料" bordered flat>
    <!-- <template v-slot:header="props">
      <q-tr :props="props">
        <q-th v-if="detail" auto-width />
        <q-th v-for="col in props.cols" :class="[`text-${col.thAlign || 'center'}`]" :props="props" :style="col.style"
          :key="col.name">
          <slot :name="`header-cell-${col.name}`" v-bind="props">
            {{ col.label }}
          </slot>
        </q-th>
      </q-tr>
    </template> -->
    <template v-slot:body="props">
      <q-tr :props="props">
        <q-td v-if="detail" auto-width>
          <q-btn size="sm" color="primary" round dense @click="props.expand = !props.expand"
            :icon="props.expand ? 'expand_more' : 'navigate_next'" />
        </q-td>
        <q-td :class="`text-${col.align||'center'}`" v-for="col in props.cols" :key="col.name">
          <slot :name="`body-cell-${col.name}`" v-bind="props">
            {{ col.value }}
          </slot>
        </q-td>
      </q-tr>
      <q-tr v-if="props.expand" :props="props">
        <q-td colspan="100">
          <slot name="expand" v-bind="props"></slot>
        </q-td>
      </q-tr>
    </template>
    <template v-slot:bottom>
      <q-space></q-space>
      <c-simple-pagination :page="pagination.page" :rowsPerPage="pagination.rowsPerPage"
        :rowsNumber="rowsNumber"></c-simple-pagination>
      <div class="q-mx-sm">每頁筆數</div>
      <q-select outlined dense v-model="pagination.rowsPerPage" :options="[5, 10, 15, 20]"></q-select>
    </template>
  </q-table>
</template>

<script lang="ts">
// Component
import { Options, Vue } from "vue-class-component";
import { Emit, Prop } from "vue-property-decorator";
import QuasarPagination from "./QuasarPagination";

@Options({})
export default class Table extends Vue {
  @Prop({ default: false }) detail!: boolean;
  @Prop({ default: 0 }) rowsNumber!: number;
  @Prop({ default: false }) loading!: boolean;
  @Prop({ default: "id" }) rowKey!: string;
  @Prop() rows !: [];
  @Prop() columns !: [];
  @Prop({ default: () => new QuasarPagination() }) pagination = new QuasarPagination();
  @Emit("pagination") paginate(pagination: QuasarPagination) { return pagination; }
}
</script>
