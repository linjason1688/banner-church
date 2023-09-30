<template>
  <div>
    <c-subtitle title="事工團基本資訊" />
    <c-form-card>
      <c-row>
        <c-column label="事工團分類" class="col-12 col-sm-4">
          <c-form-ministry-def v-model="form.ministryDefId" role="o"></c-form-ministry-def>
        </c-column>
        <c-column label="事工團名稱" class="col-12 col-sm-4">
          <c-form-ministry v-model="form.ministryId" role="o"></c-form-ministry>
        </c-column>
        <c-column label="出席日期" class="col-12 col-sm-4">
          <c-date-picker range dense :value="{ from: form.meetingDayS, to: form.meetingDayE }"
            @update:model-value="form.meetingDayS = $event.from; form.meetingDayE = $event.to" />
        </c-column>
        <c-column label="出席狀態" class="col-12 col-sm-4">
          <c-select class="inline-block full-width" emit-value map-options :options="meetAttendanceTypeList"
            v-model="form.attendanceType" option-label="value" option-value="name" clearable role="o"></c-select>
        </c-column>
        <c-column label="異動紀錄" class="col-12 col-sm-4">
          <c-select class="inline-block full-width" emit-value map-options :options="ministryRespUserStatusList"
            v-model="form.modifyRecord" option-label="value" option-value="name" role="o"></c-select>
        </c-column>
        <c-column class="col text-right">
          <q-btn icon="search" color="indigo" rounded @click="queryAsync">查詢</q-btn>
        </c-column>
      </c-row>
    </c-form-card>
    <c-table :loading="isLoading" :columns="columns" :rows="rows" row-key="ministryDefId" ref="table"
      :rowsNumber="rowsNumber">
      <template v-slot:body-cell-dateCreate="props">
        <q-td> {{ props.row.dateCreate }}（{{ props.row.creator }}）</q-td>
      </template>

      <template v-slot:body-cell-dateUpdate="props">
        <q-td>
          {{ props.row.dateUpdate }}
        </q-td>
      </template>

      <template v-slot:body-cell-qrCodeInfo="props">
        <c-btn-view @click="showQRCodeInfo(props.row.id)" />
      </template>
    </c-table>
    <c-dialog-qrcode v-model:show.sync="qrcodeDialog" :qrcodeURL="qrcodeURL"></c-dialog-qrcode>
  </div>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Options } from "vue-class-component";
import { formatDate, SystemConfig } from "src/util";
import {
  SystemConfigView,
  QueryQrCodeRequest,
  CreateQrCodeCommand,
  QueryMinistryMeetingUserRequest,
  MinistryMeetingUserView,
} from "src/api/feature";
import FormMinistry from "components/business/FormMinistry.vue";
import FormMinistryDef from "components/business/FormMinistryDef.vue";
import { SystemConfigState } from "src/data/dto/SystemConfigState";
import { PagedRequest } from "src/data/dto";

interface Info$ {
  id: number;
  ministryDefId: string;
  ministryDefName: string;
  ministryName: string;
  ministryRespName: string;
  meetingDay: string;
  meetAttendanceType: string;
  ministryRespUserStatus: string;
  dateUpdate: string;
  qrCodeInfo: string;
}

@Options({
  components: {
    "c-form-ministry-def": FormMinistryDef,
    "c-form-ministry": FormMinistry,
  },
})
export default class Info extends ComponentBase {
  form = {
    ministryDefId: undefined,
    ministryId: undefined,
    meetingDayS: undefined,
    meetingDayE: undefined,
    attendanceType: undefined,
    modifyRecord: undefined,
  };

  isLoading = false;
  rowsNumber = 0;

  qrcodeDialog = false;
  qrcodeURL = "";

  columns = [
    {
      label: "事工團分類",
      align: "center",
      name: "ministryDefName",
      field: (row: Info$) => row.ministryDefName,
      sortable: true,
    },
    {
      label: "事工團名稱",
      align: "center",
      name: "ministryName",
      field: (row: Info$) => row.ministryName,
      sortable: true,
    },
    {
      label: "事工職分",
      align: "center",
      name: "ministryRespName",
      field: (row: Info$) => row.ministryRespName,
      sortable: true,
    },
    {
      label: "出席日期",
      align: "center",
      name: "meetingDay",
      field: (row: Info$) => formatDate(row.meetingDay),
      sortable: true,
    },
    {
      label: "出席紀錄",
      align: "center",
      name: "meetAttendanceType",
      field: (row: Info$) => this.convertMeetAttendanceType(row.meetAttendanceType),
      sortable: true,
    },
    {
      label: "異動紀錄",
      align: "center",
      name: "ministryRespUserStatus",
      field: (row: Info$) => this.convertMinistryRespUserStatus(row.ministryRespUserStatus),
      sortable: true,
    },
    {
      label: "異動日期",
      align: "center",
      name: "dateUpdate",
      field: (row: Info$) => formatDate(row.dateUpdate),
      sortable: true,
    },
  ];

  rows: Array<MinistryMeetingUserView> = [];
  ministryRespUserStatusList: Array<SystemConfigView> = [];
  meetAttendanceTypeList = new Array<SystemConfigState>();

  async mounted() {
    this.ministryRespUserStatusList = this.$appStore.getters.getSystemConfig(SystemConfig.MinistryRespUserStatus);
    this.meetAttendanceTypeList = this.$appStore.getters.getSystemConfig(SystemConfig.MeetAttendanceType);
    await this.usePreviousRequestParamsAsync(async (req) => {
      return await this.queryAsync(req);
    });
  }

  async queryAsync(request?: PagedRequest) {
    this.isLoading = true;

    request = Object.assign(request || {}, this.form);

    const res = await this.usePreviousRequestParamsAsync(async () => {
      return await this.apis.feature.ministryMeetingUser.queryMinistryMeetingUsers(
        request as QueryMinistryMeetingUserRequest
      );
    }, request);

    this.rows = res.data.records;
    this.rowsNumber = this.rows.length;
    this.isLoading = false;
  }

  async showQRCodeInfo(id: number) {
    let referenceType = 5;
    let referenceId = id;
    let userId = this.$appStore.getters.userProfile.id;

    let queryQrCodeRequest: QueryQrCodeRequest = {
      referenceType: referenceType,
      referenceId: referenceId,
      userId: userId,
      sortProperties: [],
      size: 0,
      page: 0,
    };

    let createQrCodeCommand = {
      referenceType: referenceType,
      referenceId: referenceId,
      userId: userId,
    } as CreateQrCodeCommand;

    let queryResponse = await this.apis.feature.qrCode.queryQrCodes(queryQrCodeRequest);
    if (typeof queryResponse.data.totalCount !== "undefined" && queryResponse.data.totalCount < 1) {
      await this.apis.feature.qrCode.createQrCode(createQrCodeCommand);
    }

    let resp = await this.apis.feature.qrCode.showQrCode(referenceId, referenceType, userId);
    if (typeof resp.data == "undefined") {
      return;
    }

    this.qrcodeURL = resp.data.generateCode;
    this.qrcodeDialog = true;
  }
  private convertMeetAttendanceType(val: string) {
    const found = this.meetAttendanceTypeList.find((e) => e.name == val);
    if (found) return found.value;
    return val;
  }

  private convertMinistryRespUserStatus(val: string) {
    const found = this.ministryRespUserStatusList.find((e) => e.name == val);
    if (found) return found.value;
    return val;
  }
}
</script>
