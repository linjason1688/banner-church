<template>
  <q-page class="q-pa-lg">
    <c-subtitle title="牧養組識階層管理"></c-subtitle>
    <c-form-card-filled>
      <q-form @submit="queryAsync({ ...pagination, currentPage: 0 })">
        <c-row>
          <c-column label="堂點" class="col-12 col-sm-6">
            <c-form-organization v-model="form.organizationId" />
          </c-column>
          <c-column label="牧區" class="col-12 col-sm-6">
            <c-input v-model="form.areaId" />
          </c-column>
        </c-row>
        <c-row>
          <c-column label="督區" class="col-12 col-sm-6">
            <c-input v-model="form.leadAreaId" />
          </c-column>
          <c-column label="區" class="col-12 col-sm-6">
            <c-input v-model="form.zoneId" />
          </c-column>
        </c-row>
        <c-row>
          <c-column label="小組" class="col-12 col-sm-6">
            <c-input v-model="form.churchGroupNo" />
          </c-column>
          <c-column class="col text-right">
            <c-btn-search type="submit" />
          </c-column>
        </c-row>
      </q-form>
    </c-form-card-filled>
    <c-btn-create class="q-mb-md" :to="{ path: 'detail' }" />
    <c-table :loading="isLoading" :columns="columns" :rows="rows" :pagination="pagination" @paginate="queryAsync">
      <template v-slot:body-cell-action="props">
        <c-btn-action-text :to="{ path: 'detail/' + props.row.id }" />
      </template>
      <template v-slot:expand="props">
        <c-column-detail :detailColumns="detailColumns" :props="props">
          <template v-slot:detail-cell-name="row">
            <strong>{{ row.label }} </strong>
            {{ row.value }}
          </template>
        </c-column-detail>
        <c-entity-detail :value="props.row" />
      </template>
    </c-table>
  </q-page>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import { Pagination } from "src/data/dto";
import { ListComponentBase } from "src/components/ListComponentBase";
import { SortOrder } from "src/data/constants";
import {
  OrganizationView,
  QueryOrganizationRequest,
} from "src/api/feature";
import FormOrganization from "components/business/FormOrganization.vue";

@Options({
  meta() { return { title: "清單列表", }; },
  components: {
    "c-form-organization": FormOrganization,
  },
})
export default class PastoralList extends ListComponentBase {
  isLoading = true;

  columns = [
    {
      label: "功能",
      align: "center",
      name: "action",
      field: (row: OrganizationView) => row.id,
      style: "width: 150px;",
    },
    {
      label: "名稱",
      align: "left",
      name: "name",
      field: (row: OrganizationView) => row.name,
      sortable: true,
    },
    {
      label: "牧區",
      align: "left",
      name: "name",
      field: (row: OrganizationView) => row.pastorName,
      sortable: true,
    },
    {
      label: "督區",
      align: "left",
      name: "name",
      field: (row: OrganizationView) => row.pastorName,
      sortable: true,
    },
    {
      label: "區",
      align: "left",
      name: "name",
      field: (row: OrganizationView) => row.pastorName,
      sortable: true,
    },
    {
      label: "小組",
      align: "left",
      name: "groupId",
      field: (row: OrganizationView) => row.pastorName,
      sortable: true,
    },
  ];

  detailColumns = [
    {
      label: "名稱",
      name: "name",
      field: (row: OrganizationView) => row.name,
    },
    {
      label: "建立時間",
      name: "dateCreate",
      field: (row: OrganizationView) => row.dateCreate,
    },
  ];

  rows: Array<OrganizationView> = [];

  form = {
    organizationId: undefined,
    areaId: "",
    leadAreaId: "",
    zoneId: "",
    churchGroupNo: "",
    sortProperties: [{ propertyName: "dateCreate", sortOrder: SortOrder.Desc }],
  };

  async mounted() {
    await this.usePreviousRequestParamsAsync(async (req) => {
      return await this.queryAsync(req);
    });
  }

  async queryAsync(paged: Pagination) {
    this.isLoading = true;
    const res = await this.usePreviousRequestParamsAsync((req) => this.apis.feature.organization.queryOrganizations(req), { ...this.form, ...paged });
    this.rows = res.data.records;
    this.updatePagination(paged, res.data);
    this.isLoading = false;
  }
}
</script>
