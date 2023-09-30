<template>
  <q-page class="q-pa-lg">
    <div class="row">
      <div class="col-12">
        <c-subtitle title="設定課程擋修與上課對象"></c-subtitle>
      </div>
    </div>
    <c-form-card-filled>
      <q-form @submit="queryAsync()" class="q-mt-md q-mb-lg">
        <c-row>
          <div class="col-12 col-md-6 q-px-md">
            <c-column label="課程分類">
              <c-form-course-management-type v-model="form.courseManagementTypeId" outlined clearable dense />
            </c-column>
          </div>
          <div class="col-12 col-md-6 q-px-md">
            <c-column label="課程名稱">
              <c-form-course-management v-model:courseManagementId.sync="form.courseManagementId"
                v-model:courseManagementTypeId.sync="form.courseManagementTypeId" outlined clearable dense />
            </c-column>
          </div>
        </c-row>
        <c-row>
          <div class="col-12 col-md-6 q-px-md">
            <c-column label="狀態">
              <c-form-status-cd v-model="form.statusCd" :hasAllOptions="true" outlined clearable dense />
            </c-column>
          </div>
          <div class="col-12 col-md-6">
            <c-btn-search type="submit" />
          </div>
        </c-row>
      </q-form>
    </c-form-card-filled>

    <div class="q-mb-md">
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
import { CourseManagementFilterView, QueryCourseManagementFilterRequest, CourseManagementView, CourseManagementTypeView } from "src/api/feature";
import { convertStatusCd } from "src/util";
import FormCourseManagement from "components/business/FormCourseManagement.vue";
import FormCourseManagementType from "components/business/FormCourseManagementType.vue";

interface List$ {
  id: number;
  courseManagementId: number;
  courseManagementTypeId: number;
  courseName: string;
  courseSex: string;
  ageUp: string;
  ageDown: string;
  filters: string;
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
export default class CourseManagementFilterList extends ListComponentBase {
  isLoading = true;

  columns = [
    {
      label: "",
      align: "center",
      name: "action",
      field: (row: List$) => row.id,
      style: "width: 150px;",
    },
    {
      label: "課程分類",
      align: "left",
      name: "courseManagementTypeId",
      field: (row: List$) => this.convertCourseManagementTypeName(row.courseManagementId),
      sortable: true,
    },
    {
      label: "課程代碼",
      align: "left",
      name: "courseManagementId",
      field: (row: List$) => row.courseManagementId,
      sortable: true,
    },
    {
      label: "課程名稱",
      align: "left",
      name: "courseManagementName",
      field: (row: List$) => this.convertCourseManagementAttrs(row.courseManagementId, "title"),
      sortable: true,
    },
    {
      label: "狀態",
      align: "left",
      name: "statusCd",
      field: (row: List$) => convertStatusCd(this.convertCourseManagementAttrs(row.courseManagementId, "courseManagementStatus")),
      sortable: true,
    },
    {
      label: "擋修條件",
      align: "left",
      name: "filters",
      field: (row: List$) => this.convertCourseFilters(row),
      sortable: true,
    },
  ];

  detailColumns = [
    {
      label: "名稱",
      name: "name",
      field: (row: List$) => row.courseName,
    },
    {
      label: "建立時間",
      name: "dateCreate",
      field: (row: List$) => row.dateCreate,
    },
  ];

  rows: Array<CourseManagementFilterView> = [];

  form = {
    courseManagementId: undefined,
    courseManagementTypeId: undefined,
    name: "",
    statusCd: "",
    sortProperties: [{ propertyName: "dateCreate", sortOrder: SortOrder.Desc }],
  };

  courseManagementMap = new Map<number, CourseManagementView>();
  courseManagementTypeMap = new Map<number, CourseManagementTypeView>();

  async mounted() {
    await this.getCourseManagement();
    await this.getCourseManagementType();
    await this.usePreviousRequestParamsAsync(async (req) => {
      return await this.queryAsync(req);
    });
  }

  convertCourseManagementAttrs(courseManagementId: number, attrName: string) {
    let courseManagement = this.courseManagementMap.get(courseManagementId);
    if (courseManagement == undefined) {
      return "";
    }
    // eslint-disable-next-line
    return (courseManagement as any)[attrName] as string;
  }

  convertCourseManagementTypeAttrs(courseManagementTypeId: number, attrName: string) {
    let courseManagementType = this.courseManagementTypeMap.get(courseManagementTypeId);
    if (courseManagementType == undefined) {
      return "";
    }
    // eslint-disable-next-line
    return (courseManagementType as any)[attrName] as string;
  }

  convertCourseManagementTypeName(courseManagementId: number) {
    let courseManagementTypeIdStr = this.convertCourseManagementAttrs(courseManagementId, "courseManagementTypeId");
    let courseManagementTypeId: number = +courseManagementTypeIdStr;
    return this.convertCourseManagementTypeAttrs(courseManagementTypeId, "name");
  }

  convertCourseFilters(row: List$) {
    let courseSexStr = row.courseSex == "1" ? "男性" : "女性";
    let courseAgeStr = "";
    if (row.ageDown && row.ageDown) {
      courseAgeStr = `${row.ageUp}歲至${row.ageDown}歲`;
    }
    return `${courseAgeStr}${courseSexStr}可選修`
  }

  async getCourseManagement() {
    await this.apis.feature.courseManagement.fetchCourseManagements()
      .then((response) => {
        if (response.data) {
          response.data.map((x) => {
            this.courseManagementMap.set(x.id, x);
          })
        }
      })
  }

  async getCourseManagementType() {
    await this.apis.feature.courseManagementType.fetchCourseManagementTypes()
      .then((response) => {
        if (response.data) {
          response.data.map((x) => {
            this.courseManagementTypeMap.set(x.id, x);
          })
        }
      })
  }

  async queryAsync(paged = this.pagination) {
    this.isLoading = true;
    const res = await this.usePreviousRequestParamsAsync(req => this.apis.feature.courseManagementFilter.queryCourseManagementFilters(req), { ...this.form, ...paged });
    this.rows = res.data.records;
    this.updatePagination(paged, res.data);
    this.isLoading = false;
  }
}
</script>

<style lang="scss" scoped></style>
