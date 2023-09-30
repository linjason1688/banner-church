<template>
  <q-page class="q-pa-lg">
    <c-row>
      <div class="col-12">
        <c-subtitle title="建立課程資訊" />
      </div>
    </c-row>

    <c-row>
      <div class="col-12">
        <c-form-card-filled>
          <q-form @submit="queryAsync" class="q-mt-md q-mb-lg">
            <c-row>
              <div class="col-12 col-md-6 q-px-md">
                <c-column label="課程分類">
                  <c-form-course-management-type v-model="form.courseManagementTypeId" outlined clearable dense />
                </c-column>
              </div>
              <div class="col-12 col-md-6 q-px-md">
                <c-column label="課程名稱">
                  <c-input v-model="form.title" label="" role="search" />
                </c-column>
              </div>
            </c-row>
            <c-row>
              <div class="col-12 col-md-6">
                <c-column label="狀態">
                  <c-form-status-cd v-model="form.statusCd" hasAllOptions="true" outlined clearable dense />
                </c-column>
              </div>
              <div class="col-12 col-md-6">
                <div class="col-6 q-px-md q-mb-md self-end column items-end">
                  <c-btn-search unelevated type="submit" />
                </div>
              </div>
            </c-row>
          </q-form>
        </c-form-card-filled>
      </div>
    </c-row>

    <c-btn-create :to="{ path: 'detail' }" />

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
import { CourseManagementView, QueryCourseManagementRequest, QueryCourseManagementTypeRequest } from "src/api/feature";
import FormCourseManagementType from "components/business/FormCourseManagementType.vue";
import { convertStatusCd } from "src/util";

interface CourseManagement$ {
  id: number;
  name: string;
  courseManagementTypeId: number;
  courseManagementNo: string;
  title: string;
  description: string;
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
  },
})
export default class CourseManagementList extends ListComponentBase {
  isLoading = true;

  // eslint-disable-next-line
  courseManagementTypeList: { [index: string]: any } = {};

  columns = [
    {
      label: "功能",
      align: "center",
      name: "action",
      field: (row: CourseManagement$) => row.id,
      style: "width: 150px;",
    },
    {
      label: "課程分類",
      align: "left",
      name: "courseManagementTypeId",
      // eslint-disable-next-line @typescript-eslint/no-unsafe-return
      field: (row: CourseManagement$) => this.courseManagementTypeList[row.courseManagementTypeId],
      sortable: true,
    },
    {
      label: "課程代碼",
      align: "left",
      name: "courseManagementNo",
      field: (row: CourseManagement$) => row.courseManagementNo,
      sortable: true,
    },
    {
      label: "課程名稱",
      align: "left",
      name: "title",
      field: (row: CourseManagement$) => row.title,
      sortable: true,
    },
    {
      label: "狀態",
      align: "left",
      name: "statusCd",
      field: (row: CourseManagement$) => convertStatusCd(row.statusCd),
      sortable: true,
    },
  ];

  detailColumns = [
    {
      label: "名稱",
      name: "name",
      field: (row: CourseManagement$) => row.name,
    },
    {
      label: "建立時間",
      name: "dateCreate",
      field: (row: CourseManagement$) => row.dateCreate,
    },
  ];

  rows: Array<CourseManagementView> = [];

  form = {
    courseManagementTypeId: undefined,
    title: "",
    statusCd: "",
    sortProperties: [{ propertyName: "dateCreate", sortOrder: SortOrder.Desc }],
  };

  async mounted() {
    const res = await this.apis.feature.courseManagementType.queryCourseManagementTypes({} as QueryCourseManagementTypeRequest);
    // eslint-disable-next-line
    this.courseManagementTypeList = res.data.records.reduce(function(map: { [key: string]: any }, obj) {
      map[obj.id] = obj.name;
      return map;
    }, {});

    await this.usePreviousRequestParamsAsync(async (req) => {
      return await this.queryAsync(req);
    });
  }

  async queryAsync(paged = this.pagination) {
    this.isLoading = true;
    const res = await this.usePreviousRequestParamsAsync(req=>this.apis.feature.courseManagement.queryCourseManagements(req), {...this.form,...paged});
    this.rows = res.data.records;
    this.updatePagination(paged, res.data);
    this.isLoading = false;
  }
}
</script>

<style lang="scss" scoped></style>
