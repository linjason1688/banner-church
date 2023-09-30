<template>
  <q-page class="q-pa-lg">
    <c-row>
      <div class="col-12">
        <c-subtitle title="兒童會友資料管理"></c-subtitle>
      </div>
    </c-row>

    <c-form-card-filled>
      <div class="row items-center">
        <div class="col">
          <c-page-title>設定</c-page-title>
        </div>
      </div>

      <q-form @submit="queryAsync" class="q-mt-md q-mb-lg">

        <c-row>
          <div class="col-12 col-md-6">
            <c-column label="堂點">
              <c-form-organization v-model="form.organizationId" dense />
            </c-column>
          </div>
          <div class="col-12 col-md-6">
            <c-column label="性別">
              <c-form-gender v-model="form.genderType" dense hasAllOptions="true" />
            </c-column>
          </div>
        </c-row>

        <c-row>
          <div class="col-12 col-md-6">
            <c-column label="姓名">
              <c-input v-model="form.name" dense />
            </c-column>
          </div>
          <div class="col-12 col-md-6">
            <c-column label="受洗狀態">
              <c-form-baptized-type v-model="form.baptizedType" dense hasAllOptions="true" />
            </c-column>
          </div>
        </c-row>

        <c-row>
          <div class="col-12 col-md-6">
            <c-column label="中低收入戶">
              <c-form-low-income v-model="form.lowIncome" :has-all-options=true />
            </c-column>
          </div>
          <div class="text-right">
            <c-btn-export @click="onExportClick"></c-btn-export>
            <c-btn-search class="sr" type="submit" />
          </div>
        </c-row>

      </q-form>
    </c-form-card-filled>

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
import { QueryUserRequest, UserView } from "src/api/feature";
import FormOrganization from "components/business/FormOrganization.vue";
import FormBaptizedType from "components/business/FormBaptizedType.vue";
import { SortOrder } from "src/api/management";
import { SystemConfig } from "src/util";
import { SystemConfigState } from "src/data/dto/SystemConfigState";
import FormLowIncome from "components/business/FormLowIncome.vue";
import ExcelJs from "exceljs";

interface User$ {
  id: number;
  organizationId: 0,
  genderType: "",
  name: string;
  firstName: string;
  lastName: string;
  baptizedType: "",
  lowerIncome: "",
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
    "c-form-organization": FormOrganization,
    "c-form-baptized-type": FormBaptizedType,
    "c-form-low-income": FormLowIncome,
  },
})
export default class UserList extends ListComponentBase {
  isLoading = true;

  columns = [
    {
      label: "功能",
      align: "center",
      name: "action",
      field: (row: User$) => row.id,
      style: "width: 150px;",
    },
    {
      label: "堂點",
      align: "center",
      name: "organizationId",
      field: (row: User$) => row.organizationId,
      sortable: true,
    },
    {
      label: "帳號",
      align: "center",
      name: "name",
      field: (row: User$) => row.name,
      sortable: true,
    },
    {
      label: "姓名",
      align: "center",
      name: "name",
      field: (row: User$) => row.firstName + row.lastName,
      sortable: true,
    },
    {
      label: "性別",
      align: "center",
      name: "genderType",
      field: (row: User$) => this.convertGenderType(row.genderType),
      sortable: true,
    },
    {
      label: "受洗狀態",
      align: "center",
      name: "baptizedType",
      field: (row: User$) => this.convertBaptizedType(row.baptizedType),
      sortable: true,
    },
  ];

  detailColumns = [
    {
      label: "名稱",
      name: "name",
      field: (row: User$) => row.name,
    },
    {
      label: "建立時間",
      name: "dateCreate",
      field: (row: User$) => row.dateCreate,
    },
  ];

  rows: Array<UserView> = [];

  form = {
    organizationId: null,
    genderType: "",
    name: "",
    baptizedType: "",
    lowIncome: "",
    sortProperties: [{ propertyName: "dateCreate", sortOrder: SortOrder.Desc }],
    isAdult: false,
  };

  private genderTypeList: Array<SystemConfigState> = [];
  private baptizedTypeList: Array<SystemConfigState> = [];

  async mounted() {

    this.genderTypeList = this.$appStore.getters.getSystemConfig(SystemConfig.GenderType);
    this.baptizedTypeList = this.$appStore.getters.getSystemConfig(SystemConfig.BaptizedType);

    await this.usePreviousRequestParamsAsync(async (req) => {
      return await this.queryAsync(req);
    });
  }

  async queryAsync(paged = this.pagination) {
    this.isLoading = true;
    const res = await this.usePreviousRequestParamsAsync(req => this.apis.feature.user.queryUsers(req), { ...this.form, ...paged });
    this.rows = res.data.records;
    this.updatePagination(paged, res.data);
    this.isLoading = false;
  }

  private convertGenderType(val: string) {
    const found = this.genderTypeList.find(e => e.name == val);
    if (found) return found.value;
    return undefined;
  }

  private convertBaptizedType(val: string) {
    const found = this.baptizedTypeList.find(e => e.name == val);
    if (found) return found.value;
    return undefined;
  }
  onExportClick() {
    let rows = this.convertExportFormat(this.rows);
    this.exportCourseInfo("工作表", this.exportColumns, rows, "兒童會友資料.xlsx");
  }

  exportColumns = [
    { name: "堂點" },
    { name: "帳號" },
    { name: "姓名" },
    { name: "性別" },
    { name: "受洗狀態" }
  ];

  convertExportFormat(rows: UserView[]): Array<Array<unknown>> {
    let arys: Array<Array<unknown>> = [];
    rows.map((x) => {
      let ary: Array<unknown> = [
        x.churchName,
        x.name,
        x.firstName + x.lastName,
        this.convertGenderType(x.genderType),
        this.convertBaptizedType(x.baptizedType),
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

<style lang="scss" scoped>
.sr {
  margin-top: 12px;
  margin-left: 12px;
}
</style>