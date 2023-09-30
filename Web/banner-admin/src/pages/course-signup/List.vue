<template>
  <q-page class="q-pa-lg">
    <c-subtitle title="課程報名管理" />
    <c-form-card-filled>
      <q-form @submit="queryAsync" class="q-mt-md q-mb-lg">
        <c-row>
          <c-column label="堂點" class="col-12 col-sm-6">
            <c-form-organization v-model="form.organizationId" dense />
          </c-column>
        </c-row>
        <c-row>
          <c-column label="課程分類" class="col-12 col-sm-6">
            <c-form-course-management-type v-model="form.courseManagementTypeId" dense />
          </c-column>
          <c-column label="課程分類" class="col-12 col-sm-6">
            <c-form-course-management v-model="form.courseManagementId" dense />
          </c-column>
        </c-row>
        <c-row>
          <c-column label="年度" class="col-12 col-sm-6">
            <c-input v-model="form.year" dense />
          </c-column>
          <c-column label="季" class="col-12 col-sm-6">
            <c-input v-model="form.season" dense />
          </c-column>
        </c-row>
        <c-row>
          <c-column label="梯次" class="col-12 col-sm-6">
            <c-input v-model="form.classNum" dense />
          </c-column>
          <c-column label="開課班級與時段" class="col-12 col-sm-6">
            <c-input v-model="form.signUpDate" dense />
          </c-column>
          <c-column class="col text-right">
            <c-btn-search type="submit" class="text-right" />
          </c-column>
        </c-row>
      </q-form>
    </c-form-card-filled>
    <c-btn-export type="submit" class="q-mb-lg" @click="exportExcel" />
    <c-table :loading="isLoading" :columns="columns" :rows="rows" detail :pagination="pagination" @paginate="queryAsync">
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
  </q-page>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import { PagedRequest } from "src/data/dto";
import { ListComponentBase } from "src/components/ListComponentBase";
import { SortOrder } from "src/data/constants";
import { CourseView, QueryCourseRequest } from "src/api/feature";
import FormOrganization from "components/business/FormOrganization.vue";
import FormCourseManagementType from "components/business/FormCourseManagementType.vue";
import FormCourseManagement from "components/business/FormCourseManagement.vue";
import { utils, writeFileXLSX } from "xlsx";

@Options({
  meta() {
    return {
      title: "清單列表",
    };
  },

  components: {
    "c-form-organization": FormOrganization,
    "c-form-course-management-type": FormCourseManagementType,
    "c-form-course-management": FormCourseManagement,
  },
})
export default class CourseList extends ListComponentBase {
  isLoading = true;

  columns = [
    { label: "課程分類", field: (row: CourseView) => row.courseManagementTypeName, sortable: true, },
    { label: "課程名稱", field: (row: CourseView) => row.courseManagementId, sortable: true, },
    { label: "年度", field: (row: CourseView) => row.year, sortable: true, },
    { label: "季", field: (row: CourseView) => row.season, sortable: true, },
    { label: "梯次", field: (row: CourseView) => row.classNum, sortable: true, },
    { label: "開課班級與時段", field: (row: CourseView) => row.courseTimeSchedules.reduce((a, x) => a + `${x.place}  ${x.classDay}:${x.classTimeS}~${x.classTimeE}`, ""), sortable: true, },
    { label: "班級人數", field: (row: CourseView) => row.studentCount, sortable: true, },
    { label: "更多", name: "detail" },
  ];
  detailColumns = [
    { label: "名稱", name: "name", field: (row: CourseView) => row.name, },
    { label: "建立時間", name: "dateCreate", field: (row: CourseView) => row.dateCreate, },
  ];
  rows: Array<CourseView> = [];
  form: QueryCourseRequest = {
    courseManagementId: undefined,
    organizationId: undefined,
    classNum: "",
    name: "",
    statusCd: "",
    sortProperties: [{ propertyName: "dateCreate", sortOrder: SortOrder.Desc }],
    page: 0,
    size: 0,
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
  exportExcel() {
    /* eslint-disable */
    const json = this.rows.map(row => Object.fromEntries(this.columns.filter(col => col.field).map(col => [col.label, col.field ? col.field(row) : ""])));
    const workbook = utils.book_new();
    const worksheet = utils.json_to_sheet(json);
    utils.book_append_sheet(workbook, worksheet, "課程報名管理");
    writeFileXLSX(workbook, "課程報名管理.xlsx");
  }
}
</script>