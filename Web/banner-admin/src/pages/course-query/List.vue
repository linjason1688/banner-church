<template>
  <q-page class="q-pa-lg">
    <div class="row">
      <div class="col-12">
        <c-subtitle title="課程資訊-檢視"></c-subtitle>
      </div>
    </div>

    <c-form-card-filled>
      <q-form @submit="queryAsync" class="q-mt-md q-mb-lg">

        <div class="row">
          <div class="col-12 col-md-3">
            <c-column label="堂點">
              <c-form-organization v-model="form.organizationId" role="search" dense />
            </c-column>
          </div>
          <div class="col-12 col-md-3">
            <c-column>
              <c-form-organization v-model="form.organizationId" role="search" dense />
            </c-column>
          </div>
          <div class="col-12 col-md-6">
            <c-column label="課程分類">
              <c-form-course-management-type v-model="form.courseManagementTypeId" role="search" />
            </c-column>
          </div>
        </div>

        <div class="row">
          <div class="col-12 col-md-6">
            <c-column label="報名日期">
              <div class="row">
                <div class="col-12 col-md-6">
                  <c-date-picker v-model="form.signUpDateS" role="search" dense />
                </div>
                <div class="col-12 col-md-6">
                  <c-date-picker v-model="form.signUpDateE" role="search" dense />
                </div>
              </div>
            </c-column>
          </div>
          <div class="col-12 col-md-6">
            <c-column label="開課日期">
              <div class="row">
                <div class="col-12 col-md-6">
                  <c-date-picker v-model="form.openDateS" role="search" dense />
                </div>
                <div class="col-12 col-md-6">
                  <c-date-picker v-model="form.openDateE" role="search" dense />
                </div>
              </div>
            </c-column>
          </div>
        </div>

        <div class="row">
          <div class="col-12 col-md-6">
            <c-column label="課程名稱">
              <c-input v-model="form.name" role="search" />
            </c-column>
          </div>

          <div class="col-12 col-md-6 text-right">
            <c-btn-search type="submit" />
          </div>
        </div>

      </q-form>
    </c-form-card-filled>

    <c-btn-export @click="onExportClick"></c-btn-export>
    <c-table :loading="isLoading" :columns="columns" :rows="rows" :pagination="pagination" @paginate="queryAsync">
      <template v-slot:body-cell-action="props">
        <c-btn-action-text :to="{ path: 'detail/' + props.row.id, }" />
      </template>
      <template v-slot:body-cell-name="props">
        <a :href="props.row.id">{{ props.row.name }}</a>
      </template>
    </c-table>
  </q-page>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import { PagedRequest } from "src/data/dto";
import { ListComponentBase } from "src/components/ListComponentBase";
import { SortOrder } from "src/data/constants";
import { CourseView, QueryCourseRequest, CourseManagementType } from "src/api/feature";
import FormOrganization from "components/business/FormOrganization.vue";
import FormCourseManagementType from "components/business/FormCourseManagementType.vue";
import { formatDate } from "src/util";
import ExcelJs from "exceljs";

interface List$ {
  id: number;
  name: string;
  homeworkCount: number;
  organizationId: number;
  courseManagementTypeId: number;
  courseName: string;
  year: string;
  season: string;
  classNum: string;
  openDateS: string;
  statusCd?: string;
  creator?: string;
  updater?: string;
  dateCreate?: string;
  dateUpdate?: string;
  signUpDateS: string;
}

@Options({
  meta() {
    return {
      title: "清單列表",
    };
  },

  components: {
    "c-form-organization": FormOrganization,
    "c-form-course-management-type": FormCourseManagementType,
  },
})
export default class CourseList extends ListComponentBase {
  isLoading = true;

  columns = [
    {
      label: "功能",
      align: "center",
      name: "action",
      field: (row: List$) => row.id,
      style: "width: 150px;",
    },
    {
      label: "作業",
      align: "left",
      name: "homeworkCount",
      field: (row: List$) => row.homeworkCount,
      sortable: true,
    },
    {
      label: "開課分堂",
      align: "left",
      name: "organizationId",
      field: (row: CourseView) => row.courseOrganizations.map(p => p.organization.name).join(","),
      sortable: true,
    },
    {
      label: "課程分類",
      align: "left",
      name: "courseManagementTypeId",
      field: (row: CourseManagementType) => row.name,
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
      label: "報名日期",
      align: "left",
      name: "signUpDate",
      field: (row: List$) => formatDate(row.signUpDateS),
      sortable: true,
    },
    {
      label: "開課日期",
      align: "left",
      name: "openDate",
      field: (row: List$) => formatDate(row.openDateS),
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

  onExportClick() {
    let rows = this.convertExportFormat(this.rows);
    this.exportCourseInfo("工作表", this.exportColumns, rows, "課程資訊.xlsx");
  }

  exportColumns = [
    { name: "開課分堂" },
    { name: "課程分類" },
    { name: "課程名稱" },
    { name: "報名日期" },
    { name: "開課日期" }
  ];

  convertExportFormat(rows: CourseView[]): Array<Array<unknown>> {
    let arys: Array<Array<unknown>> = [];
    rows.map((x) => {
      let ary: Array<unknown> = [
        x.courseOrganizations.map(p => p.organization.name).join(","),
        x.name,
        x.name,
        formatDate(x.signUpDateS),
        formatDate(x.openDateS)
      ];
      arys.push(ary);
    });
    return arys;
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

<style lang="scss" scoped></style>
