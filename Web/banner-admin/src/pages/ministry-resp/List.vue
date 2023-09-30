<template>
  <q-page class="q-pa-lg">
    <c-subtitle title="牧養職分設定" />
    <c-form-card-filled>
      <q-form @submit="queryAsync({ ...pagination, currentPage: 0 })" class="q-mb-lg">
        <c-row>
          <c-column label="牧養職分" class="col-12 col-sm-3">
            <c-form-organization v-model.number="form.ministryId" role="search" />
          </c-column>
          <c-column label="狀態" class="col-12 col-sm-7">
            <c-form-status-cd v-model="form.statusCd" hasAllOptions="true" />
          </c-column>
          <c-column class="col text-right">
            <c-btn-search type="submit" />
          </c-column>
        </c-row>
      </q-form>
    </c-form-card-filled>
    <c-btn-create :to="{ path: 'detail' }" class="q-mb-lg" />
    <c-table :loading="isLoading" :columns="columns" :rows="rows" detail :pagination="pagination" @paginate="queryAsync">
      <template v-slot:body-cell-action="props">
        <c-btn-action-text :to="{ path: 'detail/' + props.row.id, }" />
      </template>
      <template v-slot:expand="props">
        <c-entity-detail :value="props.row" />
      </template>
    </c-table>
  </q-page>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import { PagedRequest, Pagination } from "src/data/dto";
import { ListComponentBase } from "src/components/ListComponentBase";
import { SortOrder } from "src/data/constants";
import { MinistryRespView, QueryMinistryRespRequest } from "src/api/feature";
import FormOrganization from "components/business/FormOrganization.vue";
import { convertStatusCd } from "src/util";

@Options({
  meta() { return { title: "清單列表", }; },
  components: {
    "c-form-organization": FormOrganization,
  },
})
export default class MinistryRespList extends ListComponentBase {
  isLoading = true;
  columns = [
    {
      label: "功能",
      align: "center",
      name: "action",
      field: (row: MinistryRespView) => row.id,
      style: "width: 150px;",
    },
    {
      label: "牧養職分",
      align: "left",
      name: "name",
      field: (row: MinistryRespView) => row.name,
      sortable: true,
    },
    {
      label: "層級",
      align: "left",
      name: "seq",
      field: (row: MinistryRespView) => row.seq,
      sortable: true,
    },
    {
      label: "狀態",
      align: "center",
      name: "statusCd",
      field: (row: MinistryRespView) => convertStatusCd(row.statusCd),
      sortable: true,
    },
    { label: "更多", name: "expand" },
  ];
  rows: Array<MinistryRespView> = [{} as MinistryRespView];

  form = {
    ministryId: 0,
    statusCd: "",
    sortProperties: [{ propertyName: "dateCreate", sortOrder: SortOrder.Desc }],
  };

  async mounted() {
    await this.usePreviousRequestParamsAsync(async (req) => {
      return await this.queryAsync(req);
    });
  }
  async queryAsync(paged: Pagination) {
    this.isLoading = true;
    const res = await this.usePreviousRequestParamsAsync((req) => this.apis.feature.ministryResp.queryMinistryResps(req), { ...this.form, ...paged });
    this.rows = res.data.records;
    this.updatePagination(paged, res.data);
    this.isLoading = false;
  }
}
</script>