<template>
  <tempalte v-if="isList">
    <c-subtitle title="課程歷程"> </c-subtitle>
    <c-form-card class="bg-grey-2">
      <q-form @submit="queryAsync">
        <c-row>
          <c-column class="col-12 col-sm-4" label="開課堂點">
            <c-form-organization class="bg-white" v-model="form.organizationId" />
          </c-column>
          <c-column class="col-12 col-sm-4" label="課程分類">
            <c-form-course-management class="bg-white" v-model="form.courseManagementTypeId" />
          </c-column>
          <c-column class="col-12 col-sm-4" label="開課日期">
            <c-date-picker range outlined dense class="bg-white" :value="{ from: form.openDateS, to: form.openDateE }"
              @update:model-value="form.openDateS = $event.from; form.openDateE = $event.to"></c-date-picker>
          </c-column>
          <c-column class="col-12 col-sm-4" label="課程名稱">
            <q-input v-model="form.courseName" class="bg-white" outlined dense />
          </c-column>
          <c-column class="col text-right">
            <c-btn-search type="submit" />
          </c-column>
        </c-row>
      </q-form>
    </c-form-card>
    <c-form-card>
      <c-table :loading="isLoading" :columns="columns" :rows="rows" row-key="id"
        :rowsNumber="rowsNumber">
        <template v-slot:body-cell-courseName="props">
          <q-td>
            <a @click="showCourseDetail(props.row)" class="text-blue c-hyperlink-text">{{ props.row.courseName }}</a>
          </q-td>
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
    <!-- <c-pagination @change="queryAsync" :pagination="pagination" /> -->
  </tempalte>
  <div v-if="isList == false">
    <c-course-history-detail :detail="activeDetail"></c-course-history-detail>
  </div>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import { ListComponentBase } from "src/components/ListComponentBase";
import { SortOrder } from "src/data/constants";
import { PagedRequest } from "src/data/dto";
import { CourseManagementView, UserCourseView, OrganizationView, QueryUserCourseRequest } from "src/api/feature";
import FormOrganization from "components/business/FormOrganization.vue";
import FormCourseManagement from "components/business/FormCourseManagement.vue";
import CourseHistoryDetail from "pages/member/CourseHistoryDetail.vue";
import { formatDate, formatDateTime } from "src/util";

interface Course$ {
  id: number;
  organizationName: string; //開課堂點
  courseManagementTypeName: string; //課程分類
  courseName: string; //課程名稱
  year: string; //年度
  season: string; //季
  classNum: string; //梯次
  openDateS: string; //開課日起
  openDateE: string; //開課日迄
  courseClassSchedule: string; //開課班級與時段

  graduationStatus?: string;

  //detailColumns
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
    "c-form-organization": FormOrganization,
    "c-form-course-management": FormCourseManagement,
    "c-course-history-detail": CourseHistoryDetail,
  },
})
export default class CourseHistory extends ListComponentBase {
  rowsNumber = 0;

  isLoading = true;

  activeDetail = {} as Course$;

  get isList() {
    return this.$appStore.getters.isCourseList;
  }

  columns = [
    {
      label: "開課堂點",
      align: "center",
      name: "organizationName",
      field: (row: Course$) => row.organizationName,
      sortable: true,
    },
    {
      label: "課程分類",
      align: "center",
      name: "courseManagementTypeName",
      field: (row: Course$) => row.courseManagementTypeName,
      sortable: true,
    },
    {
      label: "課程名稱",
      align: "center",
      name: "courseName",
      field: (row: Course$) => row.courseName,
      sortable: true,
    },
    // {
    //   label: "年度",
    //   align: "center",
    //   name: "year",
    //   field: (row: Course$) => row.year,
    //   sortable: true,
    // },
    // {
    //   label: "季",
    //   align: "center",
    //   name: "season",
    //   field: (row: Course$) => row.season,
    //   sortable: true,
    // },
    // {
    //   label: "梯次",
    //   align: "center",
    //   name: "classNum",
    //   field: (row: Course$) => row.classNum,
    //   sortable: true,
    // },
    {
      label: "開課日期",
      align: "center",
      name: "openDate",
      field: (row: Course$) => formatDate(row.openDateS),
      sortable: true,
    },
    {
      label: "開課班級與時段",
      align: "center",
      name: "courseClassSchedule",
      field: (row: Course$) => row.courseClassSchedule,
      sortable: true,
    },
    {
      label: "結業狀態",
      align: "center",
      name: "graduationStatus",
      field: (row: Course$) => row.graduationStatus,
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
      field: (row: Course$) => formatDate(row.dateCreate),
    },
  ];
  rows: Array<UserCourseView> = [];

  form = {
    organizationId: undefined,
    courseManagementTypeId: undefined,
    courseName: undefined,
    openDateS: undefined,
    openDateE: undefined,
    year: undefined,
    season: undefined,
    classNum: undefined,
    statusCd: undefined,
    sortProperties: [{ propertyName: "dateCreate", sortOrder: SortOrder.Desc }],
  };

  organizationList = new Array<OrganizationView>();
  courseManagementList = new Array<CourseManagementView>();

  async mounted() {
    this.organizationList = (await this.apis.feature.organization.fetchOrganizations()).data;
    this.courseManagementList = (await this.apis.feature.courseManagement.fetchCourseManagements()).data;

    await this.usePreviousRequestParamsAsync(async (req) => {
      return await this.queryAsync(req);
    });
  }

  async queryAsync(pagedRequest?: PagedRequest) {
    this.isLoading = true;

    let request = {} as QueryUserCourseRequest;
    request = Object.assign(request, {
      userId: this.$appStore.getters.userProfile.id,
    });
    request = Object.assign(request, this.form);
    request = Object.assign(request, pagedRequest);

    const res = await this.usePreviousRequestParamsAsync(async (req) => {
      return await this.apis.feature.userCourse.queryUserCourses(
        req as QueryUserCourseRequest
      );
    }, request);

    this.rows = res.data.records;
    this.rowsNumber = this.rows.length;
    this.isLoading = false;
  }

  showCourseDetail(detail: Course$) {
    this.activeDetail = detail;
    this.$appStore.mutations.setIsCourseList(false);
  }
}
</script>

<style lang="scss" scoped>
.course-lab {
  margin-top: 36px;
}
</style>
