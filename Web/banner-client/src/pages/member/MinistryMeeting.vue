<template>
  <c-sub-title title="事工團紀錄"> </c-sub-title>
  <c-form-card class="bg-grey-3">
    <q-form @submit="queryAsync">
      <c-row>
        <c-column label="事工團分類" class="col-12 col-sm-4">
          <c-form-ministry-def class="bg-white" v-model="form.ministryDefId"></c-form-ministry-def>
        </c-column>
        <c-column label="事工團名稱" class="col-12 col-sm-4">
          <c-form-ministry class="bg-white" v-model="form.ministryId"></c-form-ministry>
        </c-column>
        <c-column label="出席狀態" class="col-12 col-sm-4">
          <q-select emit-value map-options :options="meetAttendanceTypeList" class="bg-white" outlined dense
            v-model="form.meetAttendanceType" option-label="value" option-value="name" use-input use-chips />
        </c-column>
        <c-column label="異動紀錄" class="col-12 col-sm-4">
          <q-select emit-value map-options :options="ministryRespUserStatusList" class="bg-white" outlined dense
            v-model="form.ministryRespUserStatus" option-label="value" option-value="name" use-input use-chips />
        </c-column>
        <c-column label="出席日期" class="col-12 col-sm-4">
          <c-date-picker range :value="{ from: form.meetingDayS, to: form.meetingDayE }" class="bg-white"
            @update:model-value="form.meetingDayS = $event.from; form.meetingDayE = $event.to" dense />
        </c-column>
        <c-column class="col text-right">
          <c-btn-search type="submit" />
        </c-column>
      </c-row>
    </q-form>
  </c-form-card>
  <c-form-card>
    <c-table :loading="isLoading" :columns="columns" :detailColumns="detailColumns" :rows="rows" row-key="id" ref="table"
      :action="action" :checkbox="checkbox" :rowsNumber="rowsNumber" :detail="false">
      <!-- <template v-slot:body-cell-dateCreate="props">
            <q-td> {{ props.row.dateCreate }}（{{ props.row.creator }}）</q-td>
          </template>

          <template v-slot:body-cell-dateUpdate="props">
            <q-td>
              {{ props.row.dateUpdate }}
            </q-td>
          </template>

          <template v-slot:body-cell-action="props">
            <c-btn-view
              @click="
                this.$appStore.mutations.setIsCourseList(false);
                this.$appStore.mutations.setCourseId(props.row.id);
              "
            />
          </template> -->

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
    <!-- <c-pagination @change="queryAsync" :pagination="pagination" 
                      @firstPageClicked="$refs.table.firstPage()" @prevPageClicked="$refs.table.prevPage()"
                      @nextPageClicked="$refs.table.nextPage()" @lastPageClicked="$refs.table.lastPage()">    
        </c-pagination> -->
  </c-form-card>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import SubTitle from "components/SubTitle.vue";
import FormMinistryDef from "components/business/FormMinistryDef.vue";
import FormMinistry from "components/business/FormMinistry.vue";
import { PagedRequest } from "src/data/dto";
import { MinistryMeetingUserView, QueryMinistryMeetingUserRequest, SystemConfigView } from "src/api/feature";
import { ListComponentBase } from "components/ListComponentBase";
import { formatDate, SystemConfig } from "src/util";
import { SystemConfigState } from "src/data/dto/SystemConfigState";

interface List$ {
  id: number;
  name: string;
  ministryDefId: number;
  ministryDefName: string;
  ministryName: string;
  ministryRespName: string;
  meetingDay: string;
  meetAttendanceType: string;
  ministryRespUserStatus: string;
  statusCd?: string;
  creator?: string;
  updater?: string;
  dateCreate?: string;
  dateUpdate?: string;
}

@Options({
  components: {
    "c-sub-title": SubTitle,
    "c-form-ministry-def": FormMinistryDef,
    "c-form-ministry": FormMinistry,
  },
})
export default class MinistryMeeting extends ListComponentBase {
  rowsNumber = 0;

  checkbox = false;

  action = false;

  isLoading = true;

  columns = [
    {
      label: "事工團分類",
      align: "center",
      name: "ministryDefName",
      field: (row: List$) => row.ministryDefName,
      sortable: true,
    },
    {
      label: "事工團名稱",
      align: "center",
      name: "ministryName",
      field: (row: List$) => row.ministryName,
      sortable: true,
    },
    {
      label: "事工職分",
      align: "center",
      name: "ministryRespName",
      field: (row: List$) => row.ministryRespName,
      sortable: true,
    },
    {
      label: "出席日期",
      align: "center",
      name: "meetingDay",
      field: (row: List$) => formatDate(row.meetingDay),
      sortable: true,
    },
    {
      label: "出席紀錄",
      align: "center",
      name: "meetAttendanceType",
      field: (row: List$) => this.convertDisplayText(this.meetAttendanceTypeList, row.meetAttendanceType),
      sortable: true,
    },
    {
      label: "異動紀錄",
      align: "center",
      name: "ministryRespUserStatus",
      field: (row: List$) => this.convertDisplayText(this.ministryRespUserStatusList, row.ministryRespUserStatus),
      sortable: true,
    },
    {
      label: "異動日期",
      align: "center",
      name: "dateUpdate",
      field: (row: List$) => formatDate(row.dateUpdate),
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

  form = {
    ministryDefId: undefined,
    ministryDefName: undefined,
    ministryId: undefined,
    ministryName: undefined,
    meetAttendanceType: undefined,
    ministryRespUserStatus: undefined,
    meetingDayS: undefined,
    meetingDayE: undefined,
  };

  rows: Array<MinistryMeetingUserView> = [];
  meetAttendanceTypeList = new Array<SystemConfigState>();
  ministryRespUserStatusList = new Array<SystemConfigState>();

  async mounted() {
    this.meetAttendanceTypeList = this.$appStore.getters.getSystemConfig(SystemConfig.MeetAttendanceType);
    this.ministryRespUserStatusList = this.$appStore.getters.getSystemConfig(SystemConfig.MinistryRespUserStatus);
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

  convertDisplayText(systemConfigList: Array<SystemConfigView>, index: string) {
    const found = systemConfigList.find((e) => e.name == index);
    if (found) return found.value;
    return index;
  }
}
</script>

<style lang="scss" scoped>
@import "../../css/quasar.variables.scss";

.minstry-lab {
  width: 333px;
  padding: 30px;
  margin-top: -50px;
}

.history-lab {
  width: 333px;
  padding: 30px;
  margin-top: -50px;
}

.dt {
  margin-left: 30px;
  margin-top: -40px;
}

.sr {
  margin-left: 165px;
  margin-bottom: 65px;
  margin-top: -40px;
}
</style>
