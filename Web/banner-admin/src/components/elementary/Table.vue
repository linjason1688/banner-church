<template>
  <q-table :loading="loading" :rows="rows" :columns="columns" loading-label="載入中，請稍候..." no-data-label="查無資料" flat
    :pagination="{
      sortBy: pagination.sortProperties?.[0]?.propertyName,
      descending: pagination.sortProperties?.[0]?.sortOrder == 'Desc',
      page: pagination.page,
      rowsNumber: pagination.totalCount,
      rowsPerPage: pagination.size
    }"
    @update:pagination="paginate({ sortProperties: $event.sortBy ? [{ propertyName: $event.sortBy, sortOrder: $event.descending ? 'Desc' : 'Asc' }] : [], })">
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
        <template v-for="col in props.cols" :key="col.name">
          <q-td v-if="col.name == 'detail'" class="text-center">
            <q-btn flat dense @click="props.expand = !props.expand"
              :icon="props.expand ? 'arrow_drop_down' : 'arrow_drop_up'" />
          </q-td>
          <q-td v-else :class="`text-${col.align || 'center'}`">
            <slot :name="`body-cell-${col.name}`" v-bind="props"> {{ col.value }} </slot>
          </q-td>
        </template>
      </q-tr>
      <q-tr v-if="props.expand" :props="props">
        <q-td colspan="100">
          <slot name="expand" v-bind="props"></slot>
        </q-td>
      </q-tr>
    </template>
    <template v-slot:bottom>
      <q-space></q-space>
      <c-simple-pagination :page="pagination.page" :size="pagination.size || 5" :totalCount="pagination.totalCount"
        @change="paginate({ page: $event })" />
      <div class="q-mx-sm">每頁筆數</div>
      <q-select outlined dense :model-value="pagination.size" @update:model-value="paginate({ page: 1, size: $event })"
        :options="[5, 10, 15, 20]"></q-select>
    </template>
  </q-table>
</template>

<script lang="ts">
// Component
import { Pagination } from "src/data/dto";
import { Options, Vue } from "vue-class-component";
import { Emit, Prop } from "vue-property-decorator";

@Options({})
export default class Table extends Vue {
  @Prop({ default: false }) detail!: boolean;
  @Prop({ default: false }) loading!: boolean;
  @Prop({ default: "id" }) rowKey!: string;
  @Prop() rows !: [];
  @Prop() columns !: [];
  @Prop({ default: () => new Pagination() }) pagination !: Pagination;
  @Emit("paginate") paginate(config = {} as Pagination): Pagination { return { ...this.pagination, ...config }; }
}
</script>

<style>
.q-table th {
  background: #EDEDEE;
  text-align: center;
}
</style>