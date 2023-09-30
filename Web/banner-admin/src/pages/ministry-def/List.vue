<template>
  <q-page class="q-pa-lg">
    <c-form-card bordered="false">
      <c-row>
        <div class="col-12">
          <c-subtitle title="事工團分類設定管理" />
        </div>
      </c-row>

      <c-form-card class="ministry-card q-mb-xl">
        <q-form @submit="queryAsync" class="q-mt-md q-mb-lg">
          <c-row>
            <div class="col-12 col-md-6">
              <c-field label="事工團分類">
                <c-form-ministry-def v-model="form.id"></c-form-ministry-def>
              </c-field>
            </div>
            <div class="col-12 col-md-6">
              <c-field label="事工團分類代碼">
                <c-input v-model="form.name" role="search" />
              </c-field>
            </div>
          </c-row>

          <c-row>
            <div class="col-12 col-md-6">
              <c-field label="狀態">
                <q-radio v-model="form.statusCd" val="" label="全部" role="search" />
                <q-radio v-model="form.statusCd" val="0" label="停用" role="search" />
                <q-radio v-model="form.statusCd" val="1" label="啟用" role="search" />
              </c-field>
            </div>
            <div class="sr">
              <c-btn-search type="submit" />
            </div>
          </c-row>
        </q-form>
      </c-form-card>

      <c-btn-create :to="{ path: 'detail' }" />

      <c-table :loading="isLoading" :columns="columns" :detailColumns="detailColumns" :rows="rows"
        :pagination="pagination" @paginate="queryAsync">
        <template v-slot:body-cell-action="props">
          <c-btn-action-text :to="{ path: 'detail/' + props.row.id, }" />
        </template>
      </c-table>
    </c-form-card>
  </q-page>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import { PagedRequest } from "src/data/dto";
import { ListComponentBase } from "src/components/ListComponentBase";
import { SortOrder } from "src/data/constants";
import { MinistryDefView, QueryMinistryDefRequest } from "src/api/feature";
import FormMinistryDef from "components/business/FormMinistryDef.vue";

interface MinistryDef$ {
  id: number;
  name: string;
  creator?: string;
  updater?: string;
  createdAt?: string;
  updatedAt?: string;
}

@Options({
  meta() {
    return {
      title: "清單列表",
    };
  },

  components: {
    "c-form-ministry-def": FormMinistryDef,
  },
})
export default class MinistryDefList extends ListComponentBase {
  isLoading = true;
  columns = [
    {
      label: "事工團分類代碼",
      align: "left",
      name: "name",
      field: (row: MinistryDef$) => row.name,
      sortable: true,
    },
    {
      label: "事工團分類",
      align: "left",
      name: "name",
      field: (row: MinistryDef$) => row.name,
      sortable: true,
    },
    {
      label: "狀態",
      align: "left",
      name: "name",
      field: (row: MinistryDef$) => row.name,
      sortable: true,
    },
    {
      label: "功能",
      align: "center",
      name: "action",
      field: (row: MinistryDef$) => row.id,
      style: "width: 150px;",
    },
  ];

  detailColumns = [
    {
      label: "姓名",
      name: "name",
      field: (row: MinistryDef$) => row.name,
    },
    {
      label: "建立時間",
      name: "createdAt",
      field: (row: MinistryDef$) => row.createdAt,
    },
  ];

  rows: Array<MinistryDefView> = [];
  ministryDefList = [];

  form = {
    id: undefined,
    ministryDefNo: "",
    name: "",
    statusCd: "",
    sortProperties: [{ propertyName: "createdAt", sortOrder: SortOrder.Desc }],
  };

  async mounted() {
    await this.usePreviousRequestParamsAsync(async (req) => {
      return await this.queryAsync(req);
    });
  }

  async queryAsync(paged = this.pagination) {
    this.isLoading = true;
    const res = await this.usePreviousRequestParamsAsync(req => this.apis.feature.ministryDef.queryMinistryDefs(req), { ...this.form, ...paged });
    this.rows = res.data.records;
    this.updatePagination(paged, res.data);
  }
}
</script>

<style lang="scss" scoped>
.ministry-card {
  background-color: #F7F7F7;
}
</style>
