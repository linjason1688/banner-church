<template>
  <q-page class="q-pa-md c-background-content">
    <div class="row items-center">
      <div class="col">
        <c-page-title></c-page-title>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <c-subtitle title="課程資訊"></c-subtitle>
      </div>
    </div>


    <c-form-card class="course-info-card q-mb-xl">
      <q-form @submit="queryAsync">
        <div class="row">
          <div class="col-12 col-md-2 q-px-md">
            <c-column label="開課堂點">
              <c-form-organization v-model="form.organizationId" role="o"></c-form-organization>
            </c-column>
          </div>
          <div class="col-12 col-md-2 q-px-md">
            <c-column>

            </c-column>
          </div>
          <div class="col-12 col-md-4 q-px-md">
            <c-column label="課程分類">
              <c-form-course-management-type v-model="form.courseManagementTypeId" multiple="false"
                role="o"></c-form-course-management-type>
            </c-column>
          </div>
          <div class="col-12 col-md-4 q-px-md">
            <c-column label="開課狀態">
              <c-select emit-value map-options :options="courseStatusList" option-label="value" option-value="name"
                v-model="form.courseStatus" role="o" use-chips></c-select>
            </c-column>
          </div>
        </div>

        <div class="row">
          <div class="col-12 col-md-4 q-px-md">
            <c-column label="報名日期">
              <div class="row justify-between">
                <div class="col-5">
                  <c-column label="">
                    <c-date-picker v-model="form.signUpDateS" role="n"></c-date-picker>
                  </c-column>
                </div>
                <div class="col-1 relative-position">
                  <p class="q-pb-md c-content-body absolute-center">－</p>
                </div>
                <div class="col-5">
                  <c-column label="">
                    <c-date-picker v-model="form.signUpDateE" role="n"></c-date-picker>
                  </c-column>
                </div>
              </div>
            </c-column>
          </div>
          <div class="col-12 col-md-4 q-px-md">
            <c-column label="開課日期">
              <div class="row justify-between">
                <div class="col-5">
                  <c-column label="">
                    <c-date-picker v-model="form.openDateS" role="n"></c-date-picker>
                  </c-column>
                </div>
                <div class="col-1 relative-position">
                  <p class="q-pb-md c-content-body absolute-center">－</p>
                </div>
                <div class="col-5">
                  <c-column label="">
                    <c-date-picker v-model="form.openDateE" role="n"></c-date-picker>
                  </c-column>
                </div>
              </div>
            </c-column>
          </div>
          <div class="class-lab col-12 col-md-4 q-px-md">
            <c-column label="課程名稱">
              <c-input v-model="form.name" role="n"></c-input>
            </c-column>
          </div>
        </div>

        <div class="row">
          <div class="col-12 col-md-12 text-right items-center">
            <c-btn-search type="submit" />
          </div>
        </div>
      </q-form>
    </c-form-card>

    <c-table :loading="isLoading" :columns="columns" :rows="rows" row-key="id" ref="table" :rowsNumber="rowsNumber">
      <template v-slot:body-cell-courseName="props">
        <a href="https://www.bannerch.org/join/join/foster-courses/item/104.html" target="_blank">{{ props.row.courseName
        }}</a>
      </template>

      <template v-slot:body-cell-dateCreate="props">
        <q-td> {{ props.row.dateCreate }}（{{ props.row.creator }}）</q-td>
      </template>

      <template v-slot:body-cell-openDate="props">
        <q-td>
          <div class="column">
            <div> {{ dateFormat(props.row.openDateS) }}</div>
            <div> {{ dateFormat(props.row.openDateE) }}</div>
          </div>
        </q-td>
      </template>

      <template v-slot:body-cell-dateUpdate="props">
        <q-td>
          {{ props.row.dateUpdate }}
        </q-td>
      </template>

      <template v-slot:body-cell-qrCodeInfo="props">
        <c-btn-view @click="showQRCodeInfo(props.row.courseTimeScheduleId)" />
      </template>
    </c-table>
    <c-dialog-qrcode v-model:show.sync="qrcodeDialog" :qrcodeURL="qrcodeURL"></c-dialog-qrcode>
  </q-page>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import { PagedRequest } from "src/data/dto";
import { ListComponentBase } from "src/components/ListComponentBase";
import { SortOrder } from "src/data/constants";
import { UserCourseView, QueryQrCodeRequest, CreateQrCodeCommand, QueryUserCourseRequest } from "src/api/feature";
import FormOrganization from "components/business/FormOrganization.vue";
import FormCourseManagementType from "components/business/FormCourseManagementType.vue";
import { SystemConfigState } from "src/data/dto/SystemConfigState";
import { formatDate, SystemConfig } from "src/util";
import { convertSystemConfig } from "src/services";

interface List$ {
  id: number;
  organizationId: number;
  organizationName: string;
  courseManagementTypeId: number;
  courseManagementTypeName: string;
  courseName: string;
  year: string;
  season: string;
  classNum: string;
  signUpDateS: string;
  signUpDateE: string;
  openDateS: string;
  openDateE: string;
  courseClassSchedule: string;
  attendanceType: string;
  courseStatus: string;
  qrCodeInfo: string;
  courseTimeScheduleId: number;

  name?: string;
  dateCreate?: string;
}

@Options({
  meta() {
    return {
      title: "清單列表",
    };
  },

  components: {
    "c-form-course-management-type": FormCourseManagementType,
    "c-form-organization": FormOrganization,
  },
})
export default class List extends ListComponentBase {
  isLoading = true;
  rowsNumber = 0;

  qrcodeDialog = false;
  qrcodeURL = "";

  courseStatusList = [
    {
      value: "未開課",
      name: "0",
    },
    {
      value: "上課中",
      name: "1",
    },
    {
      value: "已結束",
      name: "2",
    },
  ];

  columns = [
    {
      label: "開課分堂",
      align: "left",
      name: "organizationName",
      field: (row: List$) => row.organizationName,
      sortable: true,
    },
    {
      label: "開課分點",
      align: "left",
      name: "name",
    },
    {
      label: "課程分類",
      align: "left",
      name: "courseManagementTypeName",
      field: (row: List$) => row.courseManagementTypeName,
      sortable: true,
    },
    {
      label: "課程名稱",
      align: "left",
      name: "courseName",
      field: (row: List$) => row.courseName,
      sortable: true,
    },
    {
      label: "報名日期",
      align: "left",
      name: "signUpDateS",
      field: (row: List$) => formatDate(row.signUpDateS),
      sortable: true,
    },
    {
      label: "開課日期",
      align: "left",
      name: "openDate",
      sortable: true,
    },
    {
      label: "開課班級與時段",
      align: "left",
      name: "courseClassSchedule",
      field: (row: List$) => row.courseClassSchedule,
      sortable: true,
    },
    {
      label: "開課狀態",
      align: "left",
      name: "courseStatus",
      field: (row: List$) => this.convertCourseStatusType(row.courseStatus),
      sortable: true,
    },
    {
      label: "報到資訊",
      align: "left",
      name: "qrCodeInfo",
      field: (row: List$) => row.qrCodeInfo,
      sortable: true,
    },
  ];

  convertAttendanceType(val: string) {
    return convertSystemConfig(this.attendanceTypeList, val);
  }

  convertCourseStatusType(val: string) {
    return convertSystemConfig(this.courseStatusList, val);
  }

  detailColumns = [
    {
      label: "名稱",
      name: "name",
      field: (row: List$) => row.name,
    },
    {
      label: "建立時間",
      name: "dateCreate",
      field: (row: List$) => formatDate(row.dateCreate),
    },
  ];

  rows: Array<UserCourseView> = [];

  form = {
    organizationId: undefined,
    courseManagementTypeId: undefined,
    name: "",
    signUpDateS: "",
    signUpDateE: "",
    courseStatus: undefined,
    openDateS: "",
    openDateE: "",
    year: "",
    season: "",
    classNum: "",
    sortProperties: [{ propertyName: "dateCreate", sortOrder: SortOrder.Desc }],
  };

  attendanceTypeList = new Array<SystemConfigState>();

  async mounted() {
    this.attendanceTypeList = this.$appStore.getters.getSystemConfig(SystemConfig.AttendanceType);
    await this.usePreviousRequestParamsAsync(async (req) => {
      return await this.queryAsync(req);
    });
  }

  async queryAsync(request?: PagedRequest) {
    this.isLoading = true;
    this.rows = [];

    request = Object.assign(request || {}, this.form);

    const res = await this.usePreviousRequestParamsAsync(async () => {
      return await this.apis.feature.userCourse.queryUserCourses(request as QueryUserCourseRequest);
    }, request);

    this.rows = res.data.records;
    this.rowsNumber = this.rows.length;
    this.isLoading = false;
  }

  async showQRCodeInfo(id: number) {
    let referenceType = 4;
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

  dateFormat(date: string) {
    if (date == "0001-01-01T00:00:00") {
      return ""
    }
    let d = new Date(date);
    return `${d.getFullYear()}/${d.getMonth() + 1}/${d.getDate()}`;
  }
}
</script>

<style lang="scss" scoped>
.course-info-card {
  background-color: #F7F7F7;
}

.class-lab {
  margin-top: 36px;
}
</style>
