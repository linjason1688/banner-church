<template>
  <div class="row q-pa-md">
    <div class="col-12">
      <c-sub-title title="課程資訊"></c-sub-title>
    </div>
  </div>
  <q-form @submit="queryAsync" class="q-px-md q-mb-lg">
    <c-form-card class="course-info-card q-mb-xl">
      <div class="row">
        <div class="col-12 col-md-2 q-px-md">
          <c-column stack-label label="開課堂點">
            <c-form-organization v-model="form.organizationId" role="o"></c-form-organization>
          </c-column>
        </div>
        <div class="col-12 col-md-2 q-px-md">
            <c-column>
              
            </c-column>
          </div>
        <div class="col-12 col-md-4 q-px-md">
          <c-column stack-label label="課程分類">
            <c-form-course-management v-model="form.courseManagementId" role="o"></c-form-course-management>
          </c-column>
        </div>
        <div class="col-12 col-md-4 q-px-md">
          <c-column stack-label label="課程名稱">
            <c-input v-model="form.name" role="o"></c-input>
          </c-column>
        </div>
      </div>

      <div class="row">
        <div class="col-12 col-md-4 q-px-md">
          <c-column stack-label label="報名日期">
            <div class="row justify-between">
              <div class="col-5">
                <c-date-picker v-model="form.signUpDateS" role="n"></c-date-picker>
              </div>
              <div class="col-1 relative-position">
                <p class="c-content-body absolute-center">－</p>
              </div>
              <div class="col-5">
                <c-date-picker v-model="form.signUpDateE" role="n"></c-date-picker>
              </div>
            </div>
          </c-column>
        </div>
        <div class="col-12 col-md-4 q-px-md">
          <c-column stack-label label="開課日期">
            <div class="row justify-between">
              <div class="col-5">
                <c-date-picker v-model="form.openDateS" role="n"></c-date-picker>
              </div>
              <div class="col-1 relative-position">
                <p class="c-content-body absolute-center">－</p>
              </div>
              <div class="col-5">
                <c-date-picker v-model="form.openDateE" role="n"></c-date-picker>
              </div>
            </div>
          </c-column>
        </div>
        <div class="col-12 col-md-4 q-px-md">
          <c-column stack-label label="開課狀態">
            <c-select v-model="form.openStatus" role="o"></c-select>
          </c-column>
        </div>
      </div>

      <div class="row">
        <div class="col-12 col-md-4 q-px-md">
          <c-column stack-label label="開課班級與時段">
            <c-select role="o"></c-select>
          </c-column>
        </div>
        <div class="col-12 col-md-8 text-right items-center">
          <c-btn-search type="submit" />
        </div>
      </div>
    </c-form-card>
  </q-form>

  <c-table :loading="isLoading" :columns="columns" :rows="rows" row-key="id" ref="table" :rowsNumber="rowsNumber">

    <template v-slot:body-cell-courseName="props">
      <a href="https://www.bannerch.org/join/join/foster-courses/item/104.html" target="_blank">{{ props.row.courseName }}</a>
    </template>

    <template v-slot:body-cell-link="props">
      <a :href="'https://www.bannerch.org/join/join/foster-courses/item/104.html?' + props.row.id" target="_blank">連結</a>
    </template>

    <template v-slot:body-cell-dateCreate="props">
      <q-td> {{ props.row.dateCreate }}（{{ props.row.creator }}）</q-td>
    </template>
    <template v-slot:body-cell-dateUpdate="props">
      <q-td>
        {{ props.row.dateUpdate }}
      </q-td>
    </template>
  </c-table>

</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Options } from "vue-class-component";
import SubTitle from "components/SubTitle.vue";
import FormOrganization from "components/business/FormOrganization.vue";
import FormCourseManagement from "components/business/FormCourseManagement.vue";
import { convertSystemConfig } from "src/services";
import { SystemConfigState } from "src/data/dto/SystemConfigState";
import { formatDate, SystemConfig } from "src/util";
import { PagedRequest } from "src/data/dto";
import {
  QueryUserCourseRequest,
  UserCourseView,
} from "src/api/feature";

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
  openDateS: string;
  openDateE: string;
  signUpDateS: string;
  signUpDateE: string;
  classDay: string;
  courseClassSchedule: string;
  attendanceType: string;
  courseStatus: string;
  qrCodeInfo: string;
  courseTimeScheduleId: number;
  link: string;

  name?: string;
  dateCreate?: string;
}

@Options({
  components: {
    "c-sub-title": SubTitle,
    "c-form-course-management": FormCourseManagement,
    "c-form-organization": FormOrganization,
  },
})
export default class Course extends ComponentBase {
  isLoading = true;
  rowsNumber = 0;

  columns = [
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
      name: "openDateS",
      field: (row: List$) => formatDate(row.openDateS) + " " + formatDate(row.openDateE),
      sortable: true,
    },
    {
      label: "開課班級與時段",
      align: "left",
      name: "courseClassSchedule",
      field: (row: List$) => row.courseClassSchedule,
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
    signUpDate: "",
    year: "",
    season: "",
    classNum: "",
    openDateS: "",
    openDateE: "",
    signUpDateS: "",
    signUpDateE: "",
    singUpDate: "",
    openDate: "",
    openStatus: "",
    schedule: "",
    statusCd: "",
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

}
</script>

<style lang="scss" scoped>
.course-info-card {
  background-color: #F7F7F7;
}
</style>