<template>
  <q-page class="q-pa-lg">
    <c-subtitle title="成人會友資料管理"></c-subtitle>
    <c-form-card-filled>
      <q-form @submit="queryAsync" class="q-mt-md q-mb-lg">
        <c-row>
          <c-column label="堂點" class="col-12 col-sm-6">
            <q-select v-model="form.organizationId" dense flat class="bg-white" />
          </c-column>
          <c-column label="牧區" class="col-12 col-sm-6">
            <q-select v-model="form.areaId" dense flat class="bg-white" />
          </c-column>
        </c-row>

        <c-row>
          <c-column label="督區" class="col-sm-6">
            <q-select v-model="form.leadAreaId" dense flat class="bg-white" />
          </c-column>
          <c-column label="區" class="col-12 col-sm-6">
            <q-select v-model="form.zoneId" dense flat class="bg-white" />
          </c-column>
        </c-row>

        <c-row>
          <c-column label="小組" class="col-12 col-sm-6">
            <q-select v-model="form.churchGroupNo" dense flat class="bg-white" />
          </c-column>
          <c-column label="姓名" class="col-12 col-sm-6">
            <q-input v-model="form.name" dense />
          </c-column>
        </c-row>
        <c-row>
          <c-column label="帳號" class="col-12 col-sm-6">
            <q-input v-model="form.account" dense />
          </c-column>
          <c-column label="行動電話" class="col-12 col-sm-6">
            <q-input v-model="form.cellPhone" dense />
          </c-column>
        </c-row>
        <c-row>
          <c-column label="性別">
            <c-form-gender v-model="form.genderType" hasAllOptions></c-form-gender>
          </c-column>
          <c-column class="col text-right">
            <q-btn type="submit" color="indigo" icon="search" rounded>查詢</q-btn>
          </c-column>
        </c-row>
      </q-form>
    </c-form-card-filled>
    <c-table :loading="isLoading" :columns="columns" :rows="rows" :pagination="pagination" @paginate="queryAsync">
      <template v-slot:body-cell-action="props">
        <c-btn-action-text :to="{ path: 'detail/' + props.row.id, }" />
      </template>
    </c-table>
  </q-page>
</template>

<script lang="ts">
import FormBaptizedType from "components/business/FormBaptizedType.vue";
import FormLowIncome from "components/business/FormLowIncome.vue";
import FormOrganization from "components/business/FormOrganization.vue";
import { UserView } from "src/api/feature";
import { ListComponentBase, PagedResponse } from "src/components/ListComponentBase";
import { PagedRequest } from "src/data/dto";
import { SystemConfig } from "src/util";
import { Options } from "vue-class-component";

interface User$ {
  id: number;
  organizationId: 0,
  genderType: "",
  name: string;
  firstName: string;
  lastName: string;
  baptizedType: "",
  lowerIncome: "",
  statusCd?: string;
  creator?: string;
  updater?: string;
  dateCreate?: string;
  dateUpdate?: string;
}

@Options({
  meta() { return { title: "清單列表", }; },
  components: {
    "c-form-organization": FormOrganization,
    "c-form-baptized-type": FormBaptizedType,
    "c-form-low-income": FormLowIncome,
  },
})
export default class UserList extends ListComponentBase {
  isLoading = true;

  columns = [
    { label: "", align: "center", name: "action", field: (row: User$) => row.id, style: "width: 150px;", },
    { label: "堂點", align: "center", name: "organizationId", field: (row: User$) => row.organizationId, sortable: true, },
    { label: "帳號", align: "center", name: "name", field: (row: User$) => row.name, sortable: true, },
    { label: "姓名", align: "center", name: "name", field: (row: User$) => row.firstName + row.lastName, sortable: true, },
    { label: "性別", align: "center", name: "genderType", field: (row: User$) => this.genderTypeMap[row.genderType], sortable: true, },
    { label: "受洗狀態", align: "center", name: "baptizedType", field: (row: User$) => this.baptizedTypeMap[row.baptizedType], sortable: true, },
  ];

  rows: Array<UserView> = [{} as UserView];

  form = {
    organizationId: undefined,
    areaId: undefined,
    leadAreaId: undefined,
    zoneId: undefined,
    churchGroupNo: undefined,
    genderType: "",
    name: "",
    account: "",
    cellPhone: "",
  };
  genderTypeMap = {} as { [key: string]: string };
  baptizedTypeMap = {} as { [key: string]: string };
  async mounted() {
    this.genderTypeMap = Object.fromEntries(this.$appStore.state.systemConfigState.filter(x => x.type == SystemConfig.GenderType).map(x => [x.name, x.value]));
    this.baptizedTypeMap = Object.fromEntries(this.$appStore.state.systemConfigState.filter(x => x.type == SystemConfig.BaptizedType).map(x => [x.name, x.value]));
    await this.usePreviousRequestParamsAsync(async (req) => {
      return await this.queryAsync(req);
    });
  }
  async queryAsync(paged = this.pagination) {
    // await new Promise(() => {
    //   this.rows = Array(paged.size).fill({} as UserView);
    //   this.updatePagination(paged, { totalCount: 42 } as PagedResponse);
    // });
    this.isLoading = true;
    const res = await this.usePreviousRequestParamsAsync(req => this.apis.feature.user.queryUsers(req), { ...this.form, ...paged });
    this.isLoading = false;
    this.rows = res.data.records;
    this.updatePagination(paged, res.data);
  }
}
</script>
