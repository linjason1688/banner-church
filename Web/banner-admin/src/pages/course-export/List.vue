<template>
  <q-page class="q-pa-lg">
    <c-row>
      <div class="col-12">
        <c-subtitle title="課程清單"></c-subtitle>
      </div>
    </c-row>

    <c-form-card-filled>
      <q-form @submit="queryAsync()" class="q-mt-md q-mb-lg">
        <c-row>
          <div class="col-12 col-md-6 q-px-md">
            <c-column label="課程分類">
              <c-form-course-management-type v-model="form.courseManagementTypeId" outlined clearable dense />
            </c-column>
          </div>
          <div class="col-12 col-md-6 q-px-md">
            <c-column label="課程代碼">
              <c-form-course-management v-model="form.courseManagementId" outlined clearable dense />
            </c-column>
          </div>
        </c-row>

        <c-row>
          <div class="col-12 col-md-6 q-px-md">
            <c-column label="課程名稱">
              <c-input v-model="form.courseManagementTitle" dense></c-input>
            </c-column>
          </div>
          <div class="col-12 col-md-6 q-px-md">
            <c-column label="課程說明">
              <c-input v-model="form.courseManagementDescription" dense></c-input>
            </c-column>
          </div>
        </c-row>

        <c-row>
          <div class="col-12 col-md-6 q-px-md">
            <c-column label="課程狀態">
              <c-form-status-cd v-model="form.statusCd" :hasAllOptions="true" outlined clearable dense />
            </c-column>
          </div>
          <div class="col-12 col-md-6 q-px-md">
            <c-column label="課程類型">
              <q-radio v-model="form.courseType" val="" label="全部" />
              <q-radio v-model="form.courseType" val="0" label="實體" />
              <q-radio v-model="form.courseType" val="1" label="線上" />
            </c-column>
          </div>
        </c-row>

        <c-row>
          <div class="col-12 col-md-6 q-px-md">
            <c-column label="是否有擋修條件">
              <q-radio v-model="form.courseIsFilter" val="" label="全部" />
              <q-radio v-model="form.courseIsFilter" val="0" label="是" />
              <q-radio v-model="form.courseIsFilter" val="1" label="否" />
            </c-column>
          </div>
          <div class="col-12 col-md-6 column items-end q-px-md">
            <c-btn type="submit" icon="search">查詢</c-btn>
          </div>
        </c-row>

        <div class="text-right"></div>
      </q-form>
    </c-form-card-filled>

    <div class="q-gutter-md q-pb-md">
      <c-btn :outlined="true" @click="selectAll(true)">全選</c-btn>
      <c-btn :outlined="true" @click="selectAll(false)">全不選</c-btn>
      <c-btn @click="exportCourseExcel()" icon="save_alt">匯出</c-btn>
    </div>
    <c-table :loading="isLoading" :columns="columns" :rows="rows" :pagination="pagination" @paginate="queryAsync">
      <template v-slot:body-cell-selection="props">
        <q-checkbox v-model="selectedClass" :val="props.row"></q-checkbox>
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
import { convertStatusCd } from "src/util";
import FormCourseManagement from "components/business/FormCourseManagement.vue";
import FormCourseManagementType from "components/business/FormCourseManagementType.vue";
import { exportExcel } from "src/util/Exporter";

interface List$ {
  id: number;
  name: string;

  courseManagementTitle: string;
  courseManagementDescription: string;
  courseManagementTypeId: number;
  courseManagementNo: string;
  courseManagementId: number;
  courseMemo: number;
  courseType: number;
  courseIsFilter: number;

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
    "c-form-course-management": FormCourseManagement,
    "c-form-course-management-type": FormCourseManagementType,
  },
})
export default class CourseList extends ListComponentBase {
  isLoading = true;

  columns = [
    {
      label: "",
      align: "center",
      name: "selection",
      field: (row: List$) => row.id,
    },
    {
      label: "課程分類",
      align: "left",
      name: "courseManagementTitle",
      field: (row: List$) => row.courseManagementTitle,
      sortable: true,
    },
    {
      label: "課程代碼",
      align: "left",
      name: "courseManagementNo",
      field: (row: List$) => row.courseManagementNo,
      sortable: true,
    },
    {
      label: "課程名稱",
      align: "left",
      name: "name",
      field: (row: List$) => row.name,
      sortable: true,
    },
    {
      label: "課程說明",
      align: "left",
      name: "courseMemo",
      field: (row: List$) => row.courseMemo,
      sortable: true,
    },
    {
      label: "課程類型",
      align: "left",
      name: "courseType",
      field: (row: List$) => row.courseType,
      sortable: true,
    },
    {
      label: "課程狀態",
      align: "left",
      name: "statusCd",
      field: (row: List$) => convertStatusCd(row.statusCd),
      sortable: true,
    },
    {
      label: "擋修條件",
      align: "left",
      name: "filters",
      field: (row: List$) => row.courseIsFilter,
      sortable: true,
    },
  ];

  detailColumns = [
    {
      label: "名稱",
      name: "name",
      field: (row: List$) => row.name,
    },
    {
      label: "建立時間",
      name: "dateCreate",
      field: (row: List$) => row.dateCreate,
    },
  ];

  rows: Array<CourseView> = [];

  form = {
    organizationId: undefined,
    name: "",
    courseType: "",
    courseIsFilter: "",
    courseManagementTitle: "",
    courseManagementDescription: "",
    statusCd: "",
    sortProperties: [{ propertyName: "dateCreate", sortOrder: SortOrder.Desc }],
  };

  async mounted() {
    await this.usePreviousRequestParamsAsync(async (req) => {
      return await this.queryAsync(req);
    });
  }

  async queryAsync(paged: PagedRequest) {
    this.isLoading = true;
    const res = await this.usePreviousRequestParamsAsync(req => this.apis.feature.course.queryCourses(req), { ...this.form, ...paged });
    this.rows = res.data.records;
    this.updatePagination(paged, res.data);
    this.isLoading = false;
  }

  exportCourseExcel() {
    if (this.selectedClass.length <= 0) {
      this.showWarnNotify("請勾選課程");
      return;
    }
    let json = this.JSONtoExcelJSON(this.selectedClass as unknown as Array<List$>);
    exportExcel("課程清單", "工作表", json);
  }

  JSONtoExcelJSON(arr: Array<List$>) {
    return arr.map((x) => ({
      課程分類: x.courseManagementTitle,
      課程代碼: x.courseManagementNo,
      課程名稱: x.courseManagementTitle,
      課程說明: x.courseManagementDescription,
      課程類型: x.courseType,
      課程狀態: convertStatusCd(x.statusCd),
      擋修條件: x.courseIsFilter,
    }));
  }

  selectedClass: Array<CourseView> = [];
  checkAll = false;
  selectAll(val: boolean) {
    this.checkAll = !!val;
    if (val) {
      this.rows.forEach((item) => {
        this.selectedClass.push(item);
      });
    } else {
      this.selectedClass = [];
    }
  }
}
</script>

<style lang="scss" scoped></style>
