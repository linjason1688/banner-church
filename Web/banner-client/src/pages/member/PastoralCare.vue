<template>
  <div>
    <c-sub-title title="牧養歷程"> </c-sub-title>
    <c-form-card class="bg-grey-2">
      <c-row>
        <c-column label="異動類型" class="col-12 col-sm-4">
          <c-form-system-config v-model="form.careType" class="bg-white" system-config="CareType" outlined dense
            behavior="menu" />
        </c-column>
        <c-column label="異動日期" class="col-12 col-sm-4">
          <c-date-picker range :value="{ from: form.startDate, to: form.endDate }" class="bg-white" dense
            @update:model-value="form.startDate = $event.from; form.endDate = $event.to"></c-date-picker>
        </c-column>
        <c-column class="col text-right">
          <c-btn-search @click="queryAsync()" />
        </c-column>
      </c-row>
    </c-form-card>
    <c-form-card>
      <c-table :loading="isLoading" :columns="columns" :detailColumns="detailColumns" :rows="rows" row-key="id"
        :rowsNumber="rowsNumber" :detail="false" class="q-mb-md">
        <template v-slot:body-cell-dateCreate="props">
          <q-td> {{ props.row.dateCreate }}（{{ props.row.creator }}）</q-td>
        </template>
        <template v-slot:body-cell-dateUpdate="props">
          <q-td>
            {{ props.row.dateUpdate }}
          </q-td>
        </template>

        <template v-slot:body-cell-action="props">
          <c-btn-edit :to="{
            path: 'detail/' + props.row.id,
          }" />
        </template>
        <template v-slot:expand="props">
          <c-column-detail :detailColumns="detailColumns" :props="props">
            <template v-slot:detail-cell-name="row">
              <strong>{{ row.label }}
                <c-colon />
              </strong>
              {{ row.value }}
            </template>
          </c-column-detail>
          <c-entity-detail :value="props.row" />
        </template>
      </c-table>
    </c-form-card>
  </div>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import { QueryUserPastoralCareRequest, UserPastoralCareView, SystemConfigView } from "src/api/feature";
import SubTitle from "components/SubTitle.vue";
import { SortOrder } from "src/data/constants";
import { ListComponentBase } from "components/ListComponentBase";
import { PagedRequest } from "src/data/dto";
import { formatDate, SystemConfig } from "src/util";
import { SystemConfigState } from "src/data/dto/SystemConfigState";

interface List$ {
  id: number;
  careType: string;
  pastoralTitle: string;
  newArea: string;
  oldArea: string;
  careDate: string;
  comment: string;
  statusCd?: string;
  creator?: string;
  userUpdate?: string;
  dateCreate?: string;
  dateUpdate?: string;
}

@Options({
  components: {
    "c-sub-title": SubTitle,
  },
})
export default class PastoralCare extends ListComponentBase {
  rowsNumber = 0;

  isLoading = true;

  columns = [
    {
      label: "類型",
      align: "center",
      name: "careType",
      field: (row: List$) => this.convertDisplayText(this.careTypeList, row.careType),
      sortable: true,
    },
    {
      label: "身分",
      align: "center",
      name: "pastoralTitle",
      field: (row: List$) => row.pastoralTitle,
      sortable: true,
    },
    {
      label: "新",
      align: "center",
      name: "newArea",
      field: (row: List$) => row.newArea,
      sortable: true,
    },
    {
      label: "舊",
      align: "center",
      name: "oldArea",
      field: (row: List$) => row.oldArea,
      sortable: true,
    },
    {
      label: "日期",
      align: "center",
      name: "careDate",
      field: (row: List$) => formatDate(row.careDate),
      sortable: true,
    },
    {
      label: "異動人員",
      align: "left",
      name: "userUpdate",
      field: (row: List$) => row.userUpdate,
      sortable: true,
    },
  ];

  detailColumns = [
    {
      label: "建立時間",
      name: "dateCreate",
      field: (row: List$) => formatDate(row.dateCreate),
    },
  ];

  rows: Array<UserPastoralCareView> = [];

  form = {
    careType: null,
    startDate: null,
    endDate: null,
    sortProperties: [{ propertyName: "dateCreate", sortOrder: SortOrder.Desc }],
  };

  careTypeList = new Array<SystemConfigState>();

  async mounted() {
    this.careTypeList = this.$appStore.getters.getSystemConfig(SystemConfig.CareType);
    await this.usePreviousRequestParamsAsync(async (req) => {
      return await this.queryAsync(req);
    });
  }

  async queryAsync(pagedRequest?: PagedRequest) {
    this.isLoading = true;

    let request = {} as QueryUserPastoralCareRequest;
    request = Object.assign(request, {
      userId: this.$appStore.getters.userProfile.id,
    });
    request = Object.assign(request, this.form);
    request = Object.assign(request, pagedRequest);

    const res = await this.usePreviousRequestParamsAsync(async (req) => {
      return await this.apis.feature.userPastoralCare.queryUserPastoralCares(req as QueryUserPastoralCareRequest);
    }, request);

    this.rows = res.data.records;
    this.rowsNumber = this.rows.length;
    this.isLoading = false;
  }

  convertDisplayText(systemConfigList: Array<SystemConfigView>, index: string) {
    const found = systemConfigList.find((e) => e.name == index);
    if (found) return found.value;
    return index;
  }
}
</script>
