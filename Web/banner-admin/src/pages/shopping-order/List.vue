<template>
  <Detail v-if="Object.keys(detail).length" :detail="detail" />
  <q-page class="q-pa-lg" v-else>
    <c-page-title>訂單總覽 (課程)</c-page-title>
    <c-subtitle title="訂單總覽 (課程)"></c-subtitle>
    <c-form-card class="bg-grey-2">
      <q-form @submit="queryAsync" class="q-mt-md q-mb-lg">
        <c-row>
          <c-column label="堂點" class="col-12 col-sm-6">
            <FormOrganization v-model="form.organizationId" outlined class="bg-white" placeholder="- 選擇分堂" />
          </c-column>
          <c-column label="訂單編號" class="col-12 col-sm-6">
            <q-input v-model="form.id" flat dense />
          </c-column>
        </c-row>
        <c-row>
          <c-column label="姓名" class="col-12 col-sm-6">
            <q-input v-model="form.userName" flat dense />
          </c-column>
          <c-column label="訂單日期" class="col-12 col-sm-6">
            <c-date-picker range dense :value="{ from: form.orderDateS, to: form.orderDateE }"
              @update:model-value="form.orderDateS = $event.from; form.orderDateE = $event.to"></c-date-picker>
          </c-column>
        </c-row>
        <c-row>
          <c-column label="付款方式" class="col-12 col-sm-6">
            <c-form-system-config v-model="form.paymentType" systemConfig="PaymentType" outlined />
          </c-column>
          <c-column label="訂單狀態" class="col-12 col-sm-6">
            <c-form-system-config v-model="form.orderPayStatus" systemConfig="OrderStatus" outlined />
          </c-column>
        </c-row>
        <c-row>
          <c-column class="col text-right">
            <q-btn type="submit" color="indigo" icon="search" rounded>查詢</q-btn>
          </c-column>
        </c-row>
      </q-form>
    </c-form-card>

    <c-table :loading="isLoading" :columns="columns" :rows="rows" detail="true">
      <template v-slot:body-cell-action="props">
        <q-btn class="bg-grey-2" rounded @click="detail = props.row">檢視</q-btn>
      </template>
      <template v-slot:body-cell-name="props">
        <a :href="props.row.id">{{ props.row.name }}</a>
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
import { QueryShoppingOrderRequest, ShoppingOrderView } from "src/api/feature";
import FormOrganization from "components/business/FormOrganization.vue";
import TableDetail from "src/components/business/TableDetail.vue";
import Detail from "./Detail.vue";
import { formatDate } from "src/util";

@Options({
  meta() {
    return {
      title: "清單列表",
    };
  },

  components: {
    FormOrganization: FormOrganization,
    TableDetail: TableDetail,
    Detail: Detail,
  },
})
export default class ShoppingOrderList extends ListComponentBase {
  isLoading = true;

  columns = [
    { name: "action", },
    { label: "訂單編號", name: "id", field: (row: ShoppingOrderView) => row.id, sortable: true, },
    { label: "課程名稱", name: "courseName", field: (row: ShoppingOrderView) => row.shoppingOrderDetailViews[0]?.courseViews[0]?.name || "", sortable: true, },
    { label: "訂單日期", name: "orderDate", field: (row: ShoppingOrderView) => formatDate(row.shoppingOrderDetailViews[0].dateCreate), sortable: true, },
    { label: "報名會友", name: "userId", field: (row: ShoppingOrderView) => row.userName, sortable: true, },
    { label: "付款方式", name: "paymentType", field: (row: ShoppingOrderView) => row.paymentType, sortable: true, },
    { label: "牧養組織", name: "organizationId", field: (row: ShoppingOrderView) => row.shoppingOrderDetailViews[0]?.courseViews[0]?.organizationId || "", sortable: true, },
    { label: "訂單狀態", name: "orderPayStatus", field: (row: ShoppingOrderView) => row.orderPayStatus, sortable: true, },
    { label: "更多", name: "detail", }
  ];
  rows: Array<ShoppingOrderView> = [{ id: 1 } as ShoppingOrderView];
  detail: ShoppingOrderView = {} as ShoppingOrderView;
  form: QueryShoppingOrderRequest = {
    organizationId: undefined,
    id: undefined,
    userName: "",
    paymentType: null,
    orderPayStatus: null,
    eMail: "",
    sortProperties: [{ propertyName: "dateCreate", sortOrder: SortOrder.Desc }],
    page: 0,
    size: 0,
    // orderDateS: undefined,
    // orderDateE: undefined
  };

  async mounted() {
    await this.usePreviousRequestParamsAsync(async (req) => {
      return await this.queryAsync(req);
    });
  }

  async queryAsync(paged = this.pagination) {
    this.isLoading = true;
    const res = await this.usePreviousRequestParamsAsync(req => this.apis.feature.shoppingOrder.queryShoppingOrders(req), { ...this.form, ...paged });
    this.isLoading = false;
    this.rows = res.data.records;
    this.updatePagination(paged, res.data); (res.data);
  }
}
</script>

<style scoped>
.detail-table th {
  font-weight: bold;
}

.detail-table td {
  padding: 4px 8px;
  background: #EDEDEE99;
}
</style>
