<template>
  <q-page class="q-pa-lg">
    <c-subtitle title="帳號管理"></c-subtitle>
    <q-card class="bg-grey-1 q-pa-md">
      <c-row>
        <c-column class="col-sm-6" label="堂點">
          <c-row>
            <c-form-organization v-model="form.organizationId1" class="place-lab col-sm-6" placeholder="選擇分堂" role="o"
              dense clearable>
            </c-form-organization>
            <c-form-organization v-model="form.organizationId2" class="place-lab col-sm-6" placeholder="選擇分點" role="o"
              dense clearable>
            </c-form-organization>
          </c-row>
        </c-column>
        <c-column class="col-sm-6" label="牧區">
          <c-form-pastoral v-model="form.areaId" placeholder="請選擇" dense clearable></c-form-pastoral>
        </c-column>
      </c-row>
      <c-row>
        <c-column class="col-sm-6" label="督區">
          <c-form-pastoral v-model="form.leadAreaId" placeholder="請選擇" dense clearable></c-form-pastoral>
        </c-column>
        <c-column class="col-sm-6" label="區">
          <c-form-pastoral v-model="form.zoneId" placeholder="請選擇" dense clearable></c-form-pastoral>
        </c-column>
      </c-row>
      <c-row>
        <c-column class="col-sm-6" label="小組">
          <c-form-pastoral v-model="form.churchGroupNo" placeholder="請選擇" dense clearable></c-form-pastoral>
        </c-column>
        <c-column class="col-sm-6" label="姓名">
          <c-input v-model="form.name" dense></c-input>
        </c-column>
      </c-row>
      <c-row>
        <c-column class="col-sm-6" label="帳號">
          <c-input class="account-lab" v-model="form.userNO" dense></c-input>
        </c-column>
        <c-column class="col-sm-6" label="行動電話">
          <c-input class="account-lab" v-model="form.cellPhone1" dense></c-input>
        </c-column>
      </c-row>
      <c-row>
        <c-column class="col-sm-6" label="性別">
          <c-option-group label="性別" :options="genderList" v-model="form.genderType" dense />
        </c-column>
      </c-row>
    </q-card>
    <div class="flex q-py-md">
      <c-btn-search @click="queryAsync"></c-btn-search>
    </div>
    <q-form class="q-mt-md q-mb-lg">
      <c-table :loading="isLoading" :columns="columns" :rows="rows" :pagination="pagination" @paginate="queryAsync">
        <template v-slot:body-cell-action="props">
          <c-btn-action-text :to="{ path: 'detail/' + props.row.id }" />
        </template>
        <template v-slot:expand="props">
          <c-column-detail :detailColumns="detailColumns" :props="props" />
          <c-entity-detail :value="props.row" />
        </template>
      </c-table>
    </q-form>
  </q-page>
</template>

<script lang="ts">
import { PastoralView, QueryUserRequest, UserView } from "src/api/feature";
import { Options } from "vue-class-component";
import { ListComponentBase } from "components/ListComponentBase";
import { PagedRequest } from "src/data/dto";
import FormOrganization from "components/business/FormOrganization.vue";
import FormPastoral from "components/business/FormPastoral.vue";

@Options({
  meta() {
    return {
      title: "User List",
    };
  },

  components: {
    "c-form-organization": FormOrganization,
    "c-form-pastoral": FormPastoral,
  },
})
export default class UserManagementXXXList extends ListComponentBase {
  form = {
    organizationId1: undefined,
    organizationId2: undefined,
    areaId: undefined,
    leadAreaId: undefined,
    zoneId: undefined,
    churchGroupNo: undefined,
    genderType: "",
    name: undefined,
    userNO: "",
    cellPhone1: "",
  }
  columns = [
    {
      label: "",
      align: "center",
      name: "action",
      field: (row: UserView) => row.id,
      style: "width: 100px;",
    },
    {
      label: "牧區",
      align: "center",
      name: "name",
      field: (row: PastoralView) => row.name,
    },
    {
      label: "督區",
      align: "center",
      name: "name",
      field: (row: PastoralView) => row.name,
    },
    {
      label: "區",
      align: "center",
      name: "name",
      field: (row: PastoralView) => row.name,
    },
    {
      label: "小組",
      align: "center",
      name: "name",
      field: (row: PastoralView) => row.name,
    },
    {
      label: "姓名",
      align: "center",
      name: "name",
      field: (row: UserView) => row.firstName + row.lastName,
    },
    {
      label: "性別",
      align: "center",
      name: "name",
      field: (row: UserView) => row.genderType == "0" ? "女性" : "男性",
    },
    {
      label: "帳號",
      align: "center",
      name: "name",
      field: (row: UserView) => row.userNo,
    },
    {
      label: "行動電話",
      align: "center",
      name: "name",
      field: (row: UserView) => row.cellPhone1,
    },
    {
      label: "Name",
      align: "center",
      name: "name",
      field: (row: UserView) => row.name,
    }
  ];

  genderList = [
    {
      label: "全部",
      value: "",
    },
    {
      label: "男性",
      value: "1",
    },
    {
      label: "女性",
      value: "0",
    },
  ];

  detailColumns = [];
  rows: Array<UserView> = [];

  async mounted() {
    await this.usePreviousRequestParamsAsync(async (req) => {
      return await this.queryAsync(req);
    });
  }

  // ========== methods ==========
  async queryAsync(paged = this.pagination) {
    this.isLoading = true;
    const res = await this.usePreviousRequestParamsAsync(req => this.apis.feature.user.queryUsers(req), {
      ...this.form, ...paged,
      organizationId: this.form.organizationId2 || this.form.organizationId1,
      pastoralId: this.form.churchGroupNo || this.form.zoneId || this.form.leadAreaId || this.form.areaId,
    });
    this.rows = res.data.records;
    this.updatePagination(paged, res.data);
    this.isLoading = false;
  }
}
</script>

<style lang="scss" scoped></style>
