<template>
  <q-page class="q-pa-lg">
    <div class="row">
      <div class="col-12">
        <c-subtitle title="開課管理"></c-subtitle>
      </div>
    </div>

    <c-form-card-filled>
      <q-form @submit="queryAsync" class="q-mt-md q-mb-lg">
        <c-row>
          <div class="col-12 col-md-6 q-px-md">
            <c-column label="堂點">
              <c-form-organization v-model="form.organizationId" role="search" outlined clearable dense />
            </c-column>
          </div>
          <div class="col-12 col-md-6 q-px-md">
            <c-column label="課程分類">
              <c-form-course-management v-model:courseManagementId.sync="form.courseManagementId" outlined clearable
                dense />
            </c-column>
          </div>
        </c-row>

        <c-row>
          <div class="col-12 col-md-6 q-px-md">
            <c-column label="課程名稱">
              <c-input v-model="form.name" role="search" />
            </c-column>
          </div>
          <div class="col-12 col-md-6">
            <c-column label="開課日期">
              <div class="row">
                <div class="col-12 col-md-6">
                  <c-date-picker v-model="form.openDateS" role="search" dense />
                </div>
                <div class="col-12 col-md-6 q-px-md">
                  <c-date-picker v-model="form.openDateE" role="search" dense />
                </div>
              </div>

            </c-column>
          </div>
        </c-row>

        <c-row>
          <div class="col-12 col-md-6 q-px-md">
            <c-column label="狀態">
              <c-form-status-cd v-model="form.statusCd" hasAllOptions="true" outlined clearable dense />
            </c-column>
          </div>
          <div class="col-12 col-md-6">
            <c-column label="報名日期">
              <div class="row">
                <div class="col-12 col-md-6">
                  <c-date-picker v-model="form.signUpDateS" role="search" clearable dense />
                </div>
                <div class="col-12 col-md-6 q-px-md">
                  <c-date-picker v-model="form.signUpDateE" role="search" clearable dense />
                </div>
              </div>
            </c-column>
          </div>
        </c-row>

        <c-row>
          <div class="col-md-3 col-12 q-px-md">
            <c-column label="年度">
              <c-input v-model="form.year" role="search" />
            </c-column>
          </div>
          <div class="col-md-3 col-12 q-px-md">
            <c-column label="季">
              <c-input v-model="form.season" role="search" />
            </c-column>

          </div>
          <div class="col-md-3 col-12 q-px-md">
            <c-column label="梯次">
              <c-input v-model="form.stage" role="search" />
            </c-column>
          </div>
          <div class="sr col-md-3 col-12">
            <c-btn-search type="submit" />
          </div>
        </c-row>
      </q-form>
    </c-form-card-filled>

    <div class="left">
      <c-btn-create :to="{ path: 'detail' }" />
    </div>
    <c-table :loading="isLoading" :columns="columns" :rows="rows" :pagination="pagination" @paginate="queryAsync">
      <template v-slot:body-cell-action="props">
        <c-btn-action-text :to="{ path: 'detail/' + props.row.id, }" />
      </template>
    </c-table>
  </q-page>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import { PagedRequest } from "src/data/dto";
import { ListComponentBase } from "src/components/ListComponentBase";
import { SortOrder } from "src/data/constants";
import { CourseView, QueryCourseRequest } from "src/api/feature";
import FormCourseManagementType from "components/business/FormCourseManagementType.vue";
import FormOrganization from "components/business/FormOrganization.vue";
import { convertStatusCd, formatDate } from "src/util";
import FormCourseManagement from "components/business/FormCourseManagement.vue";

interface Course$ {
  id: number;
  courseManagementTypeName: string;
  courseManagementTypeId: number;
  name: string;
  year: string;
  season: string;
  signUpDateS: string;
  signUpDateE: string;
  stage: string;
  openDate: string;
  statusCd?: string;
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
    "c-form-course-management-type": FormCourseManagementType,
    "c-form-course-management": FormCourseManagement,
    "c-form-organization": FormOrganization,
  },
})
export default class CourseList extends ListComponentBase {
  isLoading = true;

  columns = [
    {
      label: "功能",
      align: "center",
      name: "action",
      field: (row: Course$) => row.id,
      style: "width: 150px;",
    },
    {
      label: "課程分類",
      align: "left",
      name: "courseManagementTypeName",
      field: (row: Course$) => row.courseManagementTypeName,
      sortable: true,
    },
    {
      label: "課程名稱",
      align: "left",
      name: "name",
      field: (row: Course$) => row.name,
      sortable: true,
    },
    {
      label: "年度",
      align: "left",
      name: "statusCd",
      field: (row: Course$) => row.year,
      sortable: true,
    },
    {
      label: "季",
      align: "left",
      name: "season",
      field: (row: Course$) => row.season,
      sortable: true,
    },
    {
      label: "梯次",
      align: "left",
      name: "stage",
      field: (row: Course$) => row.stage,
      sortable: true,
    },
    {
      label: "報名日期",
      align: "left",
      name: "signUpDateS",
      field: (row: Course$) => formatDate(row.signUpDateS),
      sortable: true,
    },
    {
      label: "開課日期",
      align: "left",
      name: "openDate",
      field: (row: Course$) => formatDate(row.openDate),
      sortable: true,
    },
    {
      label: "狀態",
      align: "left",
      name: "statusCd",
      field: (row: Course$) => convertStatusCd(row.statusCd),
      sortable: true,
    },
  ];

  detailColumns = [
    {
      label: "名稱",
      name: "name",
      field: (row: Course$) => row.name,
    },
    {
      label: "建立時間",
      name: "dateCreate",
      field: (row: Course$) => row.dateCreate,
    },
  ];
  rows: Array<CourseView> = [];
  courseList = [];
  form = {
    organizationId: undefined,
    courseManagementTypeId: undefined,
    name: "",
    year: "",
    season: "",
    stage: "",
    openDate: null,
    openDateS: null,
    openDateE: null,
    signUpDate: null,
    signUpDateS: null,
    signUpDateE: null,
    statusCd: "",
    sortProperties: [{ propertyName: "dateCreate", sortOrder: SortOrder.Desc }],
  };

  async mounted() {
    await this.usePreviousRequestParamsAsync(async (req) => {
      return await this.queryAsync(req);
    });
  }

  async queryAsync(paged = this.pagination) {
    this.isLoading = true;
    const res = await this.usePreviousRequestParamsAsync(req => this.apis.feature.course.queryCourses(req), { ...this.form, ...paged });
    this.rows = res.data.records;
    this.updatePagination(paged, res.data);
    this.isLoading = false;
  }
}
</script>

<style lang="scss" scoped>
.sr {
  display: flex;
  align-items: center;
}
</style>
