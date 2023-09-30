<template>
  <q-page class="q-pa-lg">
    <c-subtitle title="課程分類管理" />
    <c-form-card-filled>
      <q-form @submit="queryAsync" class="q-mt-md q-mb-lg">
        <c-row>
          <c-column label="課程分類" class="col-12 col-md-6 q-px-md">
            <c-form-course-management-type v-model="form.id" outlined clearable dense>
            </c-form-course-management-type>
          </c-column>
          <c-column label="課程分類代碼" class="col-12 col-md-6 q-px-md">
            <c-input v-model="form.courseManagementTypeNo" label="" role="search" dense clearable />
          </c-column>
        </c-row>
        <c-row>
          <c-column label="狀態" class="col-12 col-md-6">
            <c-form-status-cd v-model="form.statusCd" hasAllOptions="true" outlined clearable dense />
          </c-column>
          <c-column class="col text-right">
            <c-btn-search unelevated type="submit" />
          </c-column>
        </c-row>
      </q-form>
    </c-form-card-filled>
    <c-btn-create :to="{ path: 'detail' }" class="q-mb-lg" />

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
import { CourseManagementTypeView, QueryCourseManagementTypeRequest } from "src/api/feature";
import FormCourseManagementType from "components/business/FormCourseManagementType.vue";
import { convertStatusCd } from "src/util";

interface List$ {
  id: number;
  courseManagementTypeNo: string;
  name: string;
  comment: string;
  statusCd?: string;
  remark?: string;
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
export default class CourseManagementTypeList extends ListComponentBase {
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
      label: "課程分類代碼",
      align: "center",
      name: "id",
      field: (row: List$) => row.courseManagementTypeNo,
      sortable: true,
    },
    {
      label: "課程分類名稱",
      align: "center",
      name: "name",
      field: (row: List$) => row.name,
      sortable: true,
    },
    {
      label: "狀態",
      align: "center",
      name: "statusCd",
      field: (row: List$) => convertStatusCd(row.statusCd),
      sortable: true,
    },
    {
      label: "備註",
      align: "center",
      name: "remark",
      field: (row: List$) => row.remark,
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

  rows: Array<CourseManagementTypeView> = [];

  form = {
    id: undefined,
    courseManagementTypeNo: "",
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
    const res = await this.usePreviousRequestParamsAsync((req) => this.apis.feature.courseManagementType.queryCourseManagementTypes(req), { ...this.form, ...paged });
    this.rows = res.data.records;
    this.updatePagination(paged, res.data);
    this.isLoading = false;
  }

  save() {
    this.$router.go(-1);
    this.showSuccessNotify("已儲存");
  }

  async removeAsync() {
    let name = "test";
    // const confirm = await this.showConfirmDialogAsync(`確定刪除 ${this.tipName}？`, "請再次確認");
    const confirm = await this.showConfirmDialogAsync(`確定刪除 ${name}？`, "請再次確認");

    if (!confirm) {
      return;
    }

    // const request = { id: key };
    // await this.apis.feature.ministryDef.deleteMinistryDef(request as unknown as DeleteMinistryDefCommand);
    this.$router.go(-1);
    this.showSuccessNotify(`已刪除 ${name}`);
  }

  cancel() {
    this.$router.go(-1);
  }
}
</script>

<style lang="scss" scoped></style>
