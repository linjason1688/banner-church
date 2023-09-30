<template>
  <q-page class="q-pa-lg">
    <q-tabs v-model="form.deptId" @update:model-value="queryAsync()" active-color="teal" class="q-mb-md"
      style="border-bottom:1px solid #ccc">
      <q-tab v-for="dept in depts" :key="dept.id" :name="dept.id" :label="dept.name" />
    </q-tabs>
    <q-card flat class="bg-grey-2">
      <div class="flex q-pa-md">
        <c-column label="位置" class="col">
          <b>{{ ThisTreeName }}</b>
        </c-column>
        <q-separator vertical class="q-mx-md" />
        <c-column label="關鍵字搜尋">
          <q-input v-model="form.name" />
          <template v-slot:append>
            <q-btn color="indigo" rounded @click="queryAsync()">搜尋</q-btn>
          </template>
        </c-column>
      </div>
    </q-card>
    <q-btn class="q-my-md" icon="add" color="indigo" rounded>新增</q-btn>
    <c-table :rows="rows" :columns="columns" :pagination="pagination" @paginate="queryAsync">
      <template v-slot:body-cell-action="props">
        <c-btn-action-text :to="{ path: 'detail/' + props.row.id, }" />
      </template>
      <template v-slot:body-cell-lowerDeptId="props">
        {
        <q-btn flat color="indigo" :to="{ path: 'detail/' + props.row.id }">{{ LOWER_ID[props.row.id] }}</q-btn>
        }
      </template>
      <template v-slot:body-cell-status="props">
        <q-btn v-if="props.status == '1'" size="sm" color="green" outline>啟用</q-btn>
        <q-btn v-else size="sm" color="red" outline>停用</q-btn>
      </template>
    </c-table>
  </q-page>
</template>

<script lang="ts">
import { DeptView, OrganizationView } from "src/api/feature";
import { ListComponentBase } from "src/components/ListComponentBase";
import { SystemConfigState } from "src/data/dto/SystemConfigState";
import { SystemConfig } from "src/util";

export default class List extends ListComponentBase {
  ThisTreeName = "";
  deptName = "";
  form = { name: "", deptId: 0 } as OrganizationView;
  depts: DeptView[] = [];
  orgStatusList: SystemConfigState[] = [];
  rows = [] as OrganizationView[];
  Allrows = [] as OrganizationView[];
  columns = [
    {
      label: "功能",
      align: "center",
      name: "action",
      style: "width: 150px;",
    },
    {
      label: "編號(ID)",
      align: "center",
      name: "name",
      field: (row: OrganizationView) => row.id,
      style: "width: 150px;",
    },
    {
      label: "上層名稱",
      align: "center",
      name: "name",
      field: (row: OrganizationView) => this.UPPER_NAME[row.upperOrganizationId],
      style: "width: 150px;",
    },
    {
      label: "本層名稱",
      align: "center",
      name: "name",
      field: (row: OrganizationView) => row.name,
      style: "width: 150px;",
    },
    {
      label: "下層組職",
      align: "center",
      name: "name",
      field: (row: OrganizationView) => row.subCounter,
      style: "width: 150px;",
    },
    {
      label: "狀態",
      align: "center",
      name: "name",
      field: (row: OrganizationView) => this.ORG_STATUS[row.orgStatus],
      style: "width: 150px;",
    },
  ];
  get ID_NAME() {
    return Object.fromEntries(this.rows.map(x => [x.id, x.name]));
  }
  get UPPER_NAME() {
    return Object.fromEntries(this.Allrows.map(x => [x.id, x.name]));
  }
  get LOWER_ID() {
    return Object.fromEntries(this.rows.map(x => [x.upperOrganizationId, x.id]));
  }
  get ORG_STATUS() {
    return Object.fromEntries(this.orgStatusList.map(x => [x.name, x.value]));
  }
  async mounted() {
    this.orgStatusList = this.$appStore.getters.getSystemConfig(SystemConfig.OrgStatus);
    this.depts = (await this.apis.feature.dept.fetchDepts({}))?.data || [];
    this.Allrows = (await this.apis.feature.organization.fetchOrganizations({}))?.data || [];
    await this.usePreviousRequestParamsAsync(req => this.queryAsync(req));
  }
  async queryAsync(paged = this.pagination) {
    this.isLoading = true;
    const res = await this.usePreviousRequestParamsAsync((req) => this.apis.feature.organization.queryOrganizations(req), { ...this.form, ...paged });
    this.rows = res.data.records;
    this.updatePagination(paged, res.data);
    this.isLoading = false;
    try {
      if (this.rows[0].deptTreeName != null) {
        this.ThisTreeName = this.rows[0].deptTreeName;
      } else {
        this.ThisTreeName = "";
      }
    } catch {
      this.ThisTreeName = "";
    }
  }
}
</script>