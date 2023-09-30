<template>
  <q-page class="q-pa-lg">
    <c-form-card bordered="false">
      <c-row>
        <div class="col-12">
          <c-subtitle title="事工團基本資料管理" />
        </div>
      </c-row>

      <c-form-card class="ministry-card q-mb-xl">
        <q-form @submit="queryAsync()" class="q-mt-md q-mb-lg">
          <c-row>
            <div class="col-12 col-md-6">
              <c-field label="堂點">
                <c-form-organization v-model="form.organizationId" :options="ministryList" option-label="label"
                  option-value="value" map-options role="search" />
              </c-field>
            </div>
            <div class="col-12 col-md-6">
              <c-field label="事工團分類">
                <c-form-ministry-def v-model="form.ministryDefId" role="search" />
              </c-field>
            </div>
          </c-row>

          <c-row>
            <div class="col-12 col-md-6">
              <c-field label="事工團代碼">
                <c-input v-model="form.ministryNo" label="" role="search" />
              </c-field>
            </div>
            <div class="col-12 col-md-6">
              <c-field label="事工團名稱">
                <c-input v-model="form.name" role="search" />
              </c-field>
            </div>
          </c-row>

          <c-row>
            <div class="col-12 col-md-6">
              <c-field label="周期">
                <c-input v-model="form.cycle" label="" role="search" />
              </c-field>
            </div>
            <div class="col-12 col-md-6">
              <c-field label="狀態" class="inline-block">
                <q-radio v-model="form.statusCd" val="" label="全部" role="search" />
                <q-radio v-model="form.statusCd" val="0" label="停用" role="search" />
                <q-radio v-model="form.statusCd" val="1" label="啟用" role="search" />
              </c-field>
              <c-btn-search type="submit" class="sr inline-block" />
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
import FormMinistryDef from "components/business/FormMinistryDef.vue";
import FormOrganization from "components/business/FormOrganization.vue";
import { MinistryDefView, MinistryView } from "src/api/feature";
import { ListComponentBase } from "src/components/ListComponentBase";
import { SystemConfig } from "src/util";
import { Options } from "vue-class-component";

interface Ministry$ {
  id: number;
  organizationId: string,
  ministryNo: string,
  ministryDefId: number,
  ministryStatus: string,
  name: string;
  no: string;
  ministryName: string;
  statusCd: string;
  creator?: string;
  updater?: string;
  dateCreate?: string;
  dateUpdate?: string;
}

@Options({
  meta() {
    return {
      title: "清單列表",
    };
  },

  components: {
    "c-form-organization": FormOrganization,
    "c-form-ministry-def": FormMinistryDef,
  },
})
export default class ministryList extends ListComponentBase {
  isLoading = true;

  columns = [
    {
      label: "堂點",
      align: "center",
      name: "organizationId",
      field: (row: Ministry$) => row.organizationId,
      sortable: true,
    },
    {
      label: "事工團分類名稱",
      align: "center",
      name: "minstrydefname",
      field: (row: Ministry$) => this.ministryDefList[row.ministryDefId - 1].name,
      sortable: true,
    },
    {
      label: "事工團代碼",
      align: "center",
      name: "ministryNo",
      field: (row: Ministry$) => row.ministryNo,
      sortable: true,
    },
    {
      label: "事工團名稱",
      align: "center",
      name: "ministryName",
      field: (row: Ministry$) => row.name,
      sortable: true,
    },
    {
      label: "狀態",
      align: "center",
      name: "statusCd",
      // eslint-disable-next-line @typescript-eslint/no-unsafe-return
      field: (row: Ministry$) => this.ministryStatusList[row.ministryStatus],
      sortable: true,
    },
    {
      label: "功能",
      align: "center",
      name: "action",
      field: (row: Ministry$) => row.id,
      style: "width: 150px;",
    },
  ];

  detailColumns = [
    {
      label: "名稱",
      name: "name",
      field: (row: Ministry$) => row.name,
    },
    {
      label: "建立時間",
      name: "dateCreate",
      field: (row: Ministry$) => row.dateCreate,
    },
  ];
  rows: Array<MinistryView> = [];
  ministryList = [];
  // eslint-disable-next-line
  ministryStatusList: { [index: string]: any } = {};
  ministryDefList = new Array<MinistryDefView>();
  form = {
    organizationId: undefined,
    ministryDefId: undefined,
    ministryId: undefined,
    ministryNo: "",
    name: "",
    no: "",
    statusCd: "",
    cycle: "",
    // sortProperties: [{ propertyName: "dateCreate", sortOrder: SortOrder.Desc }],
  };

  async mounted() {
    const ministryStatusList = this.$appStore.getters.getSystemConfig(SystemConfig.MinistryStatus);
    this.ministryDefList = (await this.apis.feature.ministryDef.fetchMinistryDefs()).data;//取得所有事工團分類名稱的列表
    // eslint-disable-next-line
    this.ministryStatusList = Object.fromEntries(ministryStatusList.map(x => [x.name, x.value]));
    await this.queryAsync();
  }

  async queryAsync(paged = this.pagination) {
    this.isLoading = true;
    const res = await this.usePreviousRequestParamsAsync(req => this.apis.feature.ministry.queryMinistry(req), { ...this.form, ...paged });
    this.rows = res.data.records;
    this.updatePagination(paged, res.data);
    this.isLoading = false;
  }
}
</script>

<style lang="scss" scoped>
.ministry-card {
  background-color: #F7F7F7;
}

.sr {
  margin-left: 60px;
}
</style>
