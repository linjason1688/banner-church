<template>
  <q-page class="q-pa-lg">
    <c-subtitle title="訂單查詢"></c-subtitle>
    <c-form-card-filled>
      <q-form @submit="queryAsync()" class="q-mt-md q-mb-lg">
        <c-row>
          <c-column label="堂點" class="col-12 col-sm-6">
            <c-form-organization v-model="form.organizationId" role="search" bg-color="white" outlined clearable />
          </c-column>
          <c-column label="訂單編號" class="col-12 col-sm-6">
            <c-input v-model="form.id" dense clearable></c-input>
          </c-column>
        </c-row>
        <c-row>
          <c-column label="姓名" class="col-12 col-sm-6">
            <c-input v-model="form.userName" dense clearable></c-input>
          </c-column>
          <c-column label="行動電話" class="col-12 col-sm-6">
            <c-input v-model="form.phone" dense clearable></c-input>
          </c-column>
        </c-row>
        <c-row>
          <c-column label="E-mail" class="col-12 col-sm-6">
            <c-input v-model="form.eMail" dense clearable></c-input>
          </c-column>
          <c-column label="訂單日期">
            <c-date-picker range :value="{ from: form.orderDateS, to: form.orderDateE }"
              @update:model-value="form.orderDateS = $event.from; form.orderDateE = $event.to" dense />
          </c-column>
        </c-row>
        <c-row>
          <c-column label="付款方式" class="col-12 col-sm-6">
            <c-form-system-config v-model="form.paymentType" systemConfig="PaymentType" dense outlined
              clearable></c-form-system-config>
          </c-column>
          <c-column label="訂單狀態" class="col-12 col-sm-6">
            <c-form-system-config v-model="form.orderStatus" systemConfig="OrderStatus" dense outlined
              clearable></c-form-system-config>
          </c-column>
        </c-row>
        <c-column class="text-right">
          <c-btn-search type="submit" />
        </c-column>
      </q-form>
    </c-form-card-filled>

    <c-table :loading="isLoading" :columns="columns" :rows="rows" detail :pagination="pagination" @paginate="queryAsync">

      <template v-slot:body-cell-action="props">
        <c-btn-action-text :to="{ path: 'detail/' + props.row.id, }"
          v-if="props.row.orderPayStatus !== '2'">付款</c-btn-action-text>
        <c-btn-action-text v-else>檢視</c-btn-action-text>
      </template>
      <template v-slot:expand="props">
        <TableDetail :row="props.row" />
      </template>
    </c-table>
  </q-page>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import { PagedRequest } from "src/data/dto";
import { ListComponentBase } from "src/components/ListComponentBase";
import { SortOrder } from "src/data/constants";
import FormOrganization from "components/business/FormOrganization.vue";
import { QueryShoppingOrderRequest, ShoppingOrderView } from "src/api/feature";
import { SystemConfigState } from "src/data/dto/SystemConfigState";
import { SystemConfig } from "src/util";
import { convertSystemConfig } from "src/services/SystemConfig";
import TableDetail from "src/components/business/TableDetail.vue";

interface List$ extends ShoppingOrderView {
  id: number;
  name: string;
  courseName: string;
  paymentType: string;
  orderAmount: number;
  totalAmount: number;
  orderDate: string;
  pastoralId: number;
  payAmount: number;
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
    TableDetail: TableDetail,
  },
})
export default class OrderList extends ListComponentBase {
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
      label: "訂單編號",
      align: "left",
      name: "id",
      field: (row: List$) => row.id,
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
      label: "訂單日期",
      align: "left",
      name: "dateCreate",
      field: (row: List$) => String(row.dateCreate) + "（" + String(row.creator),
      sortable: true,
    },
    {
      label: "報名會友",
      align: "left",
      name: "userId",
      field: (row: List$) => "a1234.raj",
      sortable: true,
    },
    {
      label: "付款方式",
      align: "left",
      name: "paymentType",
      field: (row: List$) => convertSystemConfig(this.paymentTypeList, row.paymentType),
      sortable: true,
    },
    {
      label: "訂單狀態",
      align: "left",
      name: "orderPayStatus",
      field: (row: List$) => convertSystemConfig(this.orderPayStatusList, row.orderPayStatus),
      sortable: true,
    },
  ];

  detailColumns = [
    {
      label: "訂單金額",
      align: "left",
      name: "totalAmount",
      field: (row: List$) => row.totalAmount,
      sortable: true,
    },
    {
      label: "牧養組識",
      align: "left",
      name: "pastoralId",
      field: (row: List$) => row.pastoralId,
      sortable: true,
    },
    {
      label: "電子收據",
      align: "left",
      name: "receipt",
      field: (row: List$) => row.receipt,
      sortable: true,
    },
    {
      label: "應收金額",
      align: "left",
      name: "totalAmount",
      field: (row: List$) => row.totalAmount,
      sortable: true,
    },
    {
      label: "收款人員",
      align: "left",
      name: "receivedUserId",
      field: (row: List$) => row.receiveUserId,
      sortable: true,
    },
  ];

  rows: Array<ShoppingOrderView> = [];

  form = {
    organizationId: undefined,
    id: undefined,
    userName: "",
    phone: "",
    eMail: "",
    orderDateS: "",
    orderDateE: "",
    paymentType: "",
    name: "",
    orderStatus: "",
    sortProperties: [{ propertyName: "dateCreate", sortOrder: SortOrder.Desc }],
  };

  paymentTypeList = new Array<SystemConfigState>();
  orderStatusList = new Array<SystemConfigState>();
  orderPayStatusList = new Array<SystemConfigState>();
  created() {
    this.paymentTypeList = this.$appStore.getters.getSystemConfig(SystemConfig.PaymentType);
    this.orderStatusList = this.$appStore.getters.getSystemConfig(SystemConfig.OrderStatus);
    this.orderPayStatusList = this.$appStore.getters.getSystemConfig(SystemConfig.OrderPayStatus);
  }

  async mounted() {
    await this.usePreviousRequestParamsAsync(async (req) => {
      return await this.queryAsync(req);
    });
  }

  async queryAsync(paged = this.pagination) {
    this.isLoading = true;
    const res = await this.usePreviousRequestParamsAsync(req => this.apis.feature.shoppingOrder.queryShoppingOrders(req), { ...this.form, ...paged });
    this.rows = res.data.records;
    this.updatePagination(paged, res.data);
    this.isLoading = false;
  }
}
</script>