<template>
  <q-page class="q-pa-md">
    <div class="row items-center">
      <div class="col">
        <c-page-title></c-page-title>
      </div>
      <div class="col-auto">
        <q-btn
          :to="{
            name: 'CR0101',
          }"
          label="新增"
          color="primary"
          outline
          rounded
        />
      </div>
    </div>

    <q-form @submit="queryAsync" class="q-mt-md q-mb-lg">
      <div class="row q-col-gutter-md items-center">
        <div class="col-12 col-sm-6 col-md-3">
          <q-input v-model="form.name" prefix="Name：" outlined rounded />
        </div>
      </div>
      <div class="text-right">
        <q-btn type="submit" label="搜尋" icon-right="search" color="primary" rounded />
      </div>
    </q-form>

    <c-table :loading="isLoading" :columns="columns" :detailColumns="detailColumns" :rows="rows" row-key="id">
      <template v-slot:body-cell-action="props">
        <c-btn-edit
          :to="{
            name: 'CR0102',
            params: {
              id: props.row.id,
            },
          }"
        />
      </template>

      <!--expand-->
      <!-- <template v-slot:expand="props"></template> -->
      <template v-slot:expand="props">
        <c-column-detail :detailColumns="detailColumns" :props="props" />

        <c-entity-detail :value="props.row" />
      </template>
    </c-table>

    <c-pagination @change="queryAsync" :pagination="pagination" />
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

import { RoleView, SortOrder } from "src/api/management";

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

  rows: Array<RoleView> = [];

  form = {
    name: "",
    sortProperties: [{ propertyName: "dateCreate", sortOrder: SortOrder.Desc }],
  };

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
  async queryAsync(request?: PagedRequest) {
    this.isLoading = true;

    request = Object.assign(request || {}, this.form);

    const res = await this.usePreviousRequestParamsAsync(async (req) => {
      return await this.apis.management.role.queryAsync(req);
    }, request);

    this.rows = res.data.records;

    this.updatePagination(res.data);

    this.isLoading = false;
  }

  // ========== listening ==========

  // ========== emit ==========
}
</script>

<style lang="scss" scoped></style>
