<template>
  <q-page class="q-pa-lg">
    <c-subtitle title="帳號管理"></c-subtitle>
    <q-card class="bg-grey-1 q-pa-md">
      <c-row>
        <c-column class="col-sm-6" label="堂點">
          <c-row>
            <q-select class="col-sm-6" v-model="form.organizationId" placeholder="選擇分堂" flat dense />
            <q-select class="col-sm-6" v-model="form.organizationId" placeholder="選擇分點" flat dense />
          </c-row>
        </c-column>
        <c-column class="col-sm-6" label="牧區">
          <q-select class="bg-white" v-model="form.areaId" placeholder="請選擇" flat dense />
        </c-column>
      </c-row>
      <c-row>
        <c-column class="col-sm-6" label="督區">
          <q-select class="bg-white" v-model="form.leadAreaId" placeholder="請選擇" flat dense />
        </c-column>
        <c-column class="col-sm-6" label="區">
          <q-select class="bg-white" v-model="form.zoneId" placeholder="請選擇" flat dense />
        </c-column>
      </c-row>
      <c-row>
        <c-column class="col-sm-6" label="小組">
          <q-select class="bg-white" v-model="form.churchGroupNo" placeholder="請選擇" flat dense />
        </c-column>
      </c-row>
    </q-card>
    <div class="flex q-py-md">
      <c-btn-create :to="{ name: 'CR0101' }"></c-btn-create>
      <div class="col"></div>
      <c-btn-search></c-btn-search>
    </div>
    <q-form @submit="queryAsync" class="q-mt-md q-mb-lg">
      <c-table :loading="isLoading" :columns="columns" :rows="rows" :pagination="pagination" @paginate="queryAsync">
        <template v-slot:body-cell-action="props">
          <c-btn-action-text :to="{
            name: 'CR0102',
            params: {
              id: props.row.id,
            },
          }" />
        </template>
        <!--expand-->
        <!-- <template v-slot:expand="props"></template> -->
        <template v-slot:expand="props">
          <c-column-detail :detailColumns="detailColumns" :props="props" />

          <c-entity-detail :value="props.row" />
        </template>
      </c-table>
    </q-form>
  </q-page>
</template>

<script lang="ts">
/* eslint-disable no-unused-vars, @typescript-eslint/no-unused-vars */
import { Options } from "vue-class-component";
import { Ref, Prop, Watch, Emit } from "vue-property-decorator";
import { State, Getter, Action } from "vuex-class";

import { ListComponentBase } from "src/components/ListComponentBase";
/* eslint-enable */

import { PagedRequest } from "src/data/dto";

import { RoleView } from "src/api/management";

@Options({
  meta() {
    return {
      title: "Role List",
    };
  },

  components: {},
})
export default class RoleListPage extends ListComponentBase {
  // ========== props ==========

  // ========== vuex ==========

  // ========== data ==========
  form = {
    organizationId: undefined,
    areaId: undefined,
    leadAreaId: undefined,
    zoneId: undefined,
    churchGroupNo: undefined,
  }
  columns = [
    {
      label: "Name",
      align: "center",
      name: "name",
      field: (row: RoleView) => row.name,
    },
    {
      label: "功能",
      align: "center",
      name: "action",
      field: (row: RoleView) => row.id,
      style: "width: 100px;",
    },
  ];
  detailColumns = [];
  rows: Array<RoleView> = [];

  // ========== computed ==========

  // ========== watch ==========

  // ========== refs ==========

  // ========== hook ==========
  async mounted() {
    await this.usePreviousRequestParamsAsync(async (req) => {
      return await this.queryAsync(req);
    });
  }

  // ========== methods ==========
  async queryAsync(paged = this.pagination) {
    this.isLoading = true;
    const res = await this.usePreviousRequestParamsAsync(req => this.apis.management.role.queryAsync(req), { ...this.form, ...paged });
    this.rows = res.data.records;
    this.updatePagination(paged, res.data);
    this.isLoading = false;
  }

  // ========== listening ==========

  // ========== emit ==========
}
</script>

<style lang="scss" scoped></style>
