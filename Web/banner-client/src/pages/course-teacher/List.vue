<template>
  <q-page class="q-pa-md c-background-content" v-if="page == 'list'">
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

    <c-form-card class="course-info-card q-mb-lg">
      <q-form @submit="queryAsync()">
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
              <c-form-course-management
                v-model="form.courseManagementId"
                :multiple="false"
                role="o"
              ></c-form-course-management>
            </c-column>
          </div>
          <div class="col-12 col-md-4 q-px-md">
            <c-column label="課程名稱">
              <c-input v-model="form.name" role="n"></c-input>
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
          <div class="start-date col-12 col-md-4 q-px-md">
            <c-column label="開課日期">
              <c-date-picker v-model="form.openDate" role="n"></c-date-picker>
            </c-column>
          </div>
          <div class="sr col-12 col-md-4 text-right items-center">
            <c-btn-search type="submit" />
          </div>
        </div>
      </q-form>
    </c-form-card>

    <div class="q-mb-lg">
      <c-btn-print @click="onExportClick"></c-btn-print>
    </div>

    <c-table :loading="isLoading" :columns="columns" :rows="rows" row-key="id" ref="table" :rowsNumber="rowsNumber">
      <template v-slot:body-cell-courseName="props">
        <a href="https://www.bannerch.org/join/join/foster-courses/item/104.html" target="_blank">{{ props.row.courseName }}</a>
      </template>

      <template v-slot:body-cell-actions="item">
        <c-btn-table-std @click="onClickDetail(item.row.courseTimeScheduleId)">檢視</c-btn-table-std>
      </template>

      <template v-slot:body-cell-dateCreate="props">
        <q-td> {{ props.row.dateCreate }}（{{ props.row.creator }}）</q-td>
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
  <q-page v-if="page == 'detail'">
    <c-course-teacher-detail v-model:syncedPage.sync="page" :courseTimeScheduleId="courseTimeScheduleId"></c-course-teacher-detail>
  </q-page>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import { PagedRequest } from "src/data/dto";
import { ListComponentBase } from "src/components/ListComponentBase";
import { SortOrder } from "src/data/constants";
import { UserCourseView, QueryQrCodeRequest, CreateQrCodeCommand, QueryUserCourseRequest } from "src/api/feature";
import FormOrganization from "components/business/FormOrganization.vue";
import FormCourseManagement from "components/business/FormCourseManagement.vue";
import { SystemConfigState } from "src/data/dto/SystemConfigState";
import { formatDate, SystemConfig } from "src/util";
import { convertSystemConfig } from "src/services";
import ExcelJs from "exceljs";
import TeacherDetail from "pages/course-teacher/Detail.vue";

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
  classDay: string;
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
    "c-form-course-management": FormCourseManagement,
    "c-form-organization": FormOrganization,
    "c-course-teacher-detail": TeacherDetail,
  },
})
export default class List extends ListComponentBase {
  page = "list";
  isLoading = true;
  rowsNumber = 0;

  qrcodeDialog = false;
  qrcodeURL = "";

  columns = [
    {
      label: "",
      align: "center",
      name: "actions",
    },
    {
      label: "開課堂點",
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
      name: "classDay",
      field: (row: List$) => formatDate(row.classDay),
      sortable: true,
    }
  ];

  convertAttendanceType(val: string) {
    return convertSystemConfig(this.attendanceTypeList, val);
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
    courseManagementId: undefined,
    name: "",
    signUpDateS: "",
    signUpDateE: "",
    openStatus: "",
    openDate: "",
    year: "",
    season: "",
    classNum: "",
    courseClassSchedule: "",
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

  onExportClick() {
    let rows = this.convertExportFormat(this.rows);
    this.exportCourseInfo("工作表", this.exportColumns, rows, "課程資訊.xlsx");
  }

  exportColumns = [
    { name: "開課堂點" },
    { name: "課程分類" },
    { name: "課程名稱" },
    { name: "年度" },
    { name: "季" },
    { name: "梯次" },
    { name: "報名日期" },
    { name: "開課日期" },
    { name: "開課班級與時段" },
    { name: "開課狀態" },
    { name: "講師" },
    { name: "學員姓名" },
    { name: "性別" },
  ];

  convertExportFormat(rows: UserCourseView[]): Array<Array<unknown>> {
    let arys: Array<Array<unknown>> = [];
    rows.map((x) => {
      let ary: Array<unknown> = [
        x.organizationName,
        x.courseManagementTypeName,
        x.courseName,
        x.year,
        x.season,
        x.classNum,
        x.signUpDateS,
        x.classDay,
        x.courseClassSchedule,
        x.courseStatus ? "開啟" : "關閉",
      ];
      arys.push(ary);
    });
    return arys;
  }

  courseTimeScheduleId = 0;
  onClickDetail(courseTimeScheduleId: number) {
    this.courseTimeScheduleId = courseTimeScheduleId;
    this.page = "detail";
  }

  exportCourseInfo(
    worksheet: string,
    columns: ExcelJs.TableColumnProperties[],
    rows: Array<Array<unknown>>,
    filename: string
  ) {
    const workbook = new ExcelJs.Workbook();
    const sheet = workbook.addWorksheet(worksheet);
    sheet.addTable({
      name: "courseInfo",
      ref: "A1",
      columns: columns,
      rows: rows,
    });
    void workbook.xlsx.writeBuffer().then((content) => {
      const link = document.createElement("a");
      const blobData = new Blob([content], {
        type: "application/vnd.ms-excel;charset=utf-8;",
      });
      link.download = filename;
      link.href = URL.createObjectURL(blobData);
      link.click();
    });
  }
}
</script>

<style lang="scss" scoped>
.course-info-card {
  background-color: #F7F7F7;
}

.start-date {
  margin-top: 21px;
}

.sr {
  margin-top: 30px;
}
</style>
