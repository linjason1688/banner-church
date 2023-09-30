<template>
  <q-page class="q-pa-md">
    <c-page-title></c-page-title>

    <q-form @submit="queryAsync" class="q-mt-md q-mb-lg">
      <div class="row q-col-gutter-md items-center">
        <div class="col-12 col-sm-4 col-md-3">
          <c-input v-model="form.handledId" prefix="HandledId：" role="search" />
        </div>
        <div class="col-12 col-sm-4 col-md-3">
          <c-input v-model="form.account" prefix="Account：" role="search" />
        </div>
        <div class="col-12 col-sm-4 col-md-3">
          <c-input v-model="form.sourceIp" prefix="SourceIp：" role="search" />
        </div>
        <div class="col-12 col-sm-4 col-md-3">
          <c-input v-model="form.requestPath" prefix="RequestPath：" role="search" />
        </div>
        <div class="col-12 col-sm-4 col-md-3">
          <c-input v-model="form.responseStatusCode" prefix="ResponseStatusCode：" role="search" />
        </div>

        <div class="col-12 col-sm-4 col-md-3">
          <c-date-picker v-model="form.createAtStart" prefix="CreateAtStart：" role="search" />
        </div>
        <div class="col-12 col-sm-4 col-md-3">
          <c-date-picker v-model="form.createAtEnd" prefix="CreateAtEnd：" role="search" />
        </div>
      </div>

      <div class="text-right">
        <c-btn-search type="submit" />
      </div>
    </q-form>

    <c-table :loading="isLoading" :columns="columns" :detailColumns="detailColumns" :rows="rows" row-key="id">
      <!--expand-->
      <!-- <template v-slot:expand="props"></template> -->
      <template v-slot:expand="props">
        <c-column-detail :detailColumns="detailColumns" :props="props" />

        <c-entity-detail :value="props.row" />
      </template>
    </c-table>

    <c-pagination @change="queryAsync" :pagination="pagination" />
  </q-page>
</template>

<script lang="ts">
/* eslint-disable no-unused-vars, @typescript-eslint/no-unused-vars */
import { Options } from "vue-class-component";
import { Ref, Prop, Watch, Emit } from "vue-property-decorator";
import { State, Getter, Action } from "vuex-class";

import { ListComponentBase } from "src/components/ListComponentBase";
/* eslint-enable */

import { PagedRequest } from "src/data/dto";

import { ApiAuditLogView } from "src/api/management";
import { SortOrder } from "src/api/management";
import { formatDateTime } from "src/util";

@Options({
  meta() {
    return {
      title: "Api Log",
    };
  },

  components: {},
})
export default class ApiLogPage extends ListComponentBase {
  // ========== props ==========

  // ========== vuex ==========

  // ========== data ==========
  columns = [
    {
      label: "HandledId",
      align: "left",
      name: "handledId",
      field: (row: ApiAuditLogView) => row.handledId,
      style: "width:100px",
    },
    {
      label: "StatusCode",
      align: "center",
      name: "responseStatusCode",
      field: (row: ApiAuditLogView) => row.responseStatusCode,
      style: "width:50px",
    },
    {
      label: "HttpMethod",
      name: "httpMethod",
      field: (row: ApiAuditLogView) => row.httpMethod,
      style: "width:50px",
    },
    {
      label: "Account",
      align: "left",
      name: "account",
      field: (row: ApiAuditLogView) => row.account,
      style: "width:50px",
    },
    {
      label: "Name",
      align: "left",
      name: "name",
      field: (row: ApiAuditLogView) => row.name,
      style: "width:50px",
    },

    {
      label: "SourceIp",
      align: "left",
      name: "sourceIp",
      field: (row: ApiAuditLogView) => row.sourceIp,
      style: "width:50px",
    },
    {
      label: "RequestPath",
      align: "left",
      name: "requestPath",
      field: (row: ApiAuditLogView) => row.requestPath,
    },
    {
      label: "建立時間",
      align: "left",
      name: "createdAt",
      field: (row: ApiAuditLogView) => formatDateTime(row.dateCreate),
      style: "width:50px",
    },
  ];

  detailColumns = [
    {
      label: "RequestBody",
      name: "requestBody",
      field: (row: ApiAuditLogView) => row.requestBody,
    },
    {
      label: "ResponseBody",
      name: "responseBody",
      field: (row: ApiAuditLogView) => row.responseBody,
    },
    {
      label: "RequestQueryString",
      name: "requestQueryString",
      field: (row: ApiAuditLogView) => row.requestQueryString,
    },
    {
      label: "RequestHeaders",
      name: "requestHeaders",
      field: (row: ApiAuditLogView) => row.requestHeaders,
    },
    {
      label: "TimeElapsed(ms)",
      name: "timeElapsed",
      field: (row: ApiAuditLogView) => row.timeElapsed,
    },
  ];

  rows: Array<ApiAuditLogView> = [];

  form = {
    handledId: "",
    account: "",
    sourceIp: "",
    requestPath: "",
    responseStatusCode: "",
    createAtStart: "",
    createAtEnd: "",
    sortProperties: [{ propertyName: "createdAt", sortOrder: SortOrder.Desc }],
  };

  // ========== computed ==========

  // ========== watch ==========

  // ========== refs ==========

  // ========== hook ==========
  async mounted() {
    await this.usePreviousRequestParamsAsync(async (req) => {
      return await this.queryAsync(req);
    });
  }

  // ========== methods ==========
  async queryAsync(request?: PagedRequest) {
    this.isLoading = true;

    request = Object.assign(request || {}, this.form);

    const res = await this.usePreviousRequestParamsAsync(async (req) => {
      return await this.apis.management.appLog.queryApiLogAsync(req);
    }, request);

    this.rows = res.data.records;

    this.updatePagination(res.data);

    this.isLoading = false;
  }

  // ========== listening ==========

  // ========== emit ==========
}
</script>

<style lang="scss" scoped></style>
