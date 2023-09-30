<template>
  <div>
    <c-sub-title title="小組聚會歷程"></c-sub-title>
    <c-form-card class="bg-grey-2">
      <c-row class="q-mb-lg">
        <div class="inline q-px-md">
          <b class="text-indigo">聚會日：</b>
          <b class="text-blue-5">{{ meetingDayOfWeek }}</b>
        </div>
        <div class="inline q-px-md">
          <b class="text-indigo">聚會時間：</b>
          <b class="text-blue-5">{{ meetingTime }}</b>
        </div>
        <div class="inline q-px-md">
          <b class="text-indigo">聚會地點：</b>
          <b class="text-blue-5">{{ meetingAddress }}</b>
        </div>
      </c-row>
      <c-row>
        <c-column label="聚會日期" class="col-12 col-sm-4">
          <c-date-picker range dense :value="{ from: form.meetingDayS, to: form.meetingDayE }"
            @update:model-value="form.meetingDayS = $event.from; form.meetingDayE = $event.to" />
        </c-column>
        <c-column label="出席紀錄" class="col-12 col-sm-4">
          <c-select behavior="menu" emit-value map-options :options="meetAttendanceTypeList" option-label="value"
            option-value="name" outlined v-model="form.meetAttendanceType" role="o" clearable>
          </c-select>
        </c-column>
        <c-column class="col text-right">
          <q-btn color="indigo" rounded icon="search" @click="queryAsync">查詢</q-btn>
        </c-column>
      </c-row>
    </c-form-card>
    <c-form-card>
      <c-table :loading="isLoading" :rows="rows" :columns="columns" :rowsNumber="rowsNumber">
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
import { formatDate, SystemConfig } from "src/util";
import { MinistryMeetingUserView, QueryMinistryMeetingUserRequest, SystemConfigView } from "src/api/feature";
import SubTitle from "components/SubTitle.vue";
import { PagedRequest } from "src/data/dto";
import { ListComponentBase } from "components/ListComponentBase";
import { convertSystemConfig } from "src/services";

interface List$ {
  id: number;
  organizationId: number;
  pastoralId: number;
  meetingDay: string;
  meetAttendanceType: string;
  dateCreate?: string;
}

@Options({
  components: {
    "c-sub-title": SubTitle,
  },
})
export default class Group extends ListComponentBase {
  isLoading = true;
  rowsNumber = 0;

  meetAttendanceTypeList: Array<SystemConfigView> = [];

  meetingDayOfWeek = "星期三";
  meetingTime = "17:00-19:00";
  meetingAddress = "台中旌旗教會";
  meetAttendanceType = "";

  columns = [
    {
      label: "區",
      align: "center",
      name: "pastoralId",
      field: (row: List$) => row.pastoralId,
      sortable: true,
    },
    {
      label: "小組",
      align: "center",
      name: "courseManagementTypeName",
      field: (row: List$) => row.pastoralId,
      sortable: true,
    },
    {
      label: "聚會日期",
      align: "center",
      name: "meetingDay",
      field: (row: List$) => formatDate(row.meetingDay),
      sortable: true,
    },
    {
      label: "出席紀錄",
      align: "center",
      name: "meetAttendanceType",
      field: (row: List$) => convertSystemConfig(this.meetAttendanceTypeList, row.meetAttendanceType),
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

  rows: Array<MinistryMeetingUserView> = [];

  form = {
    meetAttendanceType: undefined,
    meetingDayS: undefined,
    meetingDayE: undefined,
  };

  async mounted() {
    this.meetAttendanceTypeList = this.$appStore.getters.getSystemConfig(SystemConfig.MeetAttendanceType);
    await this.usePreviousRequestParamsAsync(async (req) => {
      return await this.queryAsync(req);
    });
  }

  async queryAsync(pagedRequest?: PagedRequest) {
    this.isLoading = true;

    let request = {} as QueryMinistryMeetingUserRequest;
    request = Object.assign(request, {
      userId: this.$appStore.getters.userProfile.id,
    });
    request = Object.assign(request, this.form);
    request = Object.assign(request, pagedRequest);

    const res = await this.usePreviousRequestParamsAsync(async (req) => {
      return await this.apis.feature.ministryMeetingUser.queryMinistryMeetingUsers(
        req as QueryMinistryMeetingUserRequest
      );
    }, request);

    this.rows = res.data.records;
    this.rowsNumber = this.rows.length;
    this.isLoading = false;
  }
}
</script>

<style lang="scss" scoped>
@import "../../css/quasar.variables.scss";

.dt {
  margin-left: 15px;
  margin-top: 20px;
}

.attend-lab {
  width: 333px;
  margin-left: 30px;
  margin-top: 40px;
}

.sr {
  margin-top: 40px;
}
</style>
