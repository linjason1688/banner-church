<template>
  <q-page class="q-pa-md">
    <div class="row items-center">
      <div class="col">
        <c-page-title></c-page-title>
      </div>
      <div class="col-auto">
        <c-btn-create :to="{ name: 'Detail' }" />
      </div>
    </div>

    <q-form class="q-mt-md q-mb-lg">
      <div class="row q-col-gutter-md items-center">
        <div class="col-12 col-sm-5 col-md-3">
          <c-input v-model="form.keyword" prefix="關鍵字：" role="search" />
        </div>
        <div class="col-12 col-sm-4 col-md-2">
          <c-select
            v-model="form.status"
            :options="statusList"
            option-label="label"
            option-value="value"
            map-options
            prefix="狀態："
            role="search"
          />
        </div>
        <div class="col-12 col-sm-4 col-md-2">
          <c-date-picker v-model="form.from" prefix="From：" role="search" />
        </div>
        <div class="col-12 col-sm-4 col-md-2">
          <c-date-picker v-model="form.to" prefix="To：" role="search" />
        </div>
        <div class="col-12 col-sm-4 col-md-2">
          <c-time-picker v-model="form.time" prefix="Time：" role="search" />
        </div>
        <div class="col-12 col-sm-4 col-md-2">
          <OrganizationSelect v-model="organization" prefix="機構"></OrganizationSelect>
        </div>
      </div>

      <div class="text-right">
        <c-btn-search type="submit" />
      </div>
    </q-form>

    <c-table :loading="isLoading" :columns="columns" :detailColumns="detailColumns" :rows="rows" row-key="id">
      <template v-slot:body-cell-createdAt="props">
        <q-td> {{ props.row.createdAt }}（{{ props.row.creator }}） </q-td>
      </template>

      <template v-slot:body-cell-updatedAt="props">
        <q-td>
          {{ props.row.updatedAt }}
        </q-td>
      </template>

      <template v-slot:body-cell-action="props">
        <c-btn-edit
          :to="{
            name: 'Detail',
            params: {
              id: props.row.id.toString(),
            },
          }"
        />
      </template>

      <!--expand-->
      <!-- <template v-slot:expand="props"></template> -->
      <template v-slot:expand="props">
        <c-column-detail :detailColumns="detailColumns" :props="props">
          <!--customize field display individually-->
          <template v-slot:detail-cell-name="row">
            <strong>{{ row.label }}<c-colon /></strong>
            {{ row.value }}
          </template>
        </c-column-detail>

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

import { ComponentBase } from "src/components/ComponentBase";
import { WithLoading } from "src/util/TsDecorators";
/* eslint-enable */

import { PagedRequest } from "src/data/dto";
import { ListComponentBase } from "src/components/ListComponentBase";
import { SortOrder } from "src/data/constants";
import OrganizationSelect from "src/components/business/selects/OrganizationSelect.vue";
import { formatDate } from "src/util";

interface $Template$ {
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
    OrganizationSelect
  },
})
export default class $Template$ListPage extends ListComponentBase {
  // ========== props ==========

  // ========== vuex ==========

  // ========== data ==========
  isLoading = true;

  organization = {};

  statusList = [
    {
      label: "啟用",
      value: 1,
    },
    {
      label: "停用",
      value: 0,
    },
  ];

  groupList = [
    {
      label: "group1",
      val: 1,
    },
    {
      label: "group2",
      val: 2,
    },
    {
      label: "group3",
      val: 3,
    },
  ];

  columns = [
    {
      label: "姓名",
      align: "left",
      name: "name",
      field: (row: $Template$) => row.name,
      sortable: true,
    },
    {
      label: "建立時間",
      align: "right",
      name: "createdAt",
      field: (row: $Template$) => row.createdAt,
      sortable: true,
    },
    {
      label: "更新時間",
      align: "right",
      name: "updatedAt",
      field: (row: $Template$) => formatDate(row.updatedAt),
      sortable: true,
    },
    {
      label: "功能",
      align: "center",
      name: "action",
      field: (row: $Template$) => row.id,
      style: "width: 150px;",
    },
  ];

  detailColumns = [
    {
      label: "姓名",
      name: "name",
      field: (row: $Template$) => row.name,
    },
    {
      label: "建立時間",
      name: "createdAt",
      field: (row: $Template$) => row.createdAt,
    },
  ];

  rows: Array<$Template$> = [];

  form = {
    keyword: "",
    status: 1,
    group: 1,
    from: "",
    to: "",
    sortProperties: [{ propertyName: "createdAt", sortOrder: SortOrder.Desc }],
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
  // eslint-disable-next-line @typescript-eslint/no-unused-vars
  async queryAsync(request?: PagedRequest) {
    this.isLoading = true;

    await this.sleep(1000);

    this.rows = [
      {
        id: 1,
        name: "王小明",
        creator: "超級管理員",
        updater: "駭客",
        createdAt: "2020/01/01",
        updatedAt: "2020/12/31",
      },
      {
        id: 2,
        name: "陳小巴",
      },
      {
        id: 3,
        name: "林小妹",
      },
    ];

    // request = Object.assign(request || {}, this.form);

    // const res = await this.usePreviousRequestParamsAsync(async (req) => {
    //   return await this.apis.management.$Template$MgrApi.queryAsync(req);
    // }, request);

    // this.rows = res.data;

    // this.updatePagination(res.data);

    //

    this.isLoading = false;
  }

  // ========== listening ==========

  // ========== emit ==========
}
</script>

<style lang="scss" scoped></style>
