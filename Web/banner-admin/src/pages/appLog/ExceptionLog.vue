<template>
  <q-page class="q-pa-lg">
    <c-page-title></c-page-title>

    <q-form @submit="queryAsync" class="q-mt-md q-mb-lg">
      <div class="row q-col-gutter-md items-center">
        <div class="col-12 col-sm-4 col-md-3">
          <c-input v-model="form.handledId" prefix="HandledId：" role="search" />
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

    <c-table :loading="isLoading" :columns="columns" :rows="rows" @paginate="queryAsync">
    </c-table>
  </q-page>
</template>

<script lang="ts">
/* eslint-disable no-unused-vars, @typescript-eslint/no-unused-vars */
import { Options } from "vue-class-component";
import { ListComponentBase } from "src/components/ListComponentBase";
/* eslint-enable */

import { PagedRequest } from "src/data/dto";

import { ExceptionLogView, SortOrder } from "src/api/management";
import { WithLoading } from "src/util/TsDecorators";

@Options({
  meta() {
    return {
      title: "Exception Log",
    };
  },

  components: {},
})
export default class ExceptionLogPage extends ListComponentBase {
  // ========== props ==========

  // ========== vuex ==========

  // ========== data ==========
  columns = [
    {
      label: "HandledId",
      align: "left",
      name: "handledId",
      field: (row: ExceptionLogView) => row.handledId,
    },
    {
      label: "MachineName",
      align: "left",
      name: "machineName",
      field: (row: ExceptionLogView) => row.machineName,
    },
    {
      label: "Message",
      align: "left",
      name: "message",
      field: (row: ExceptionLogView) => row.message,
    },
    {
      label: "Source",
      align: "left",
      name: "source",
      field: (row: ExceptionLogView) => row.source,
    },
  ];

  detailColumns = [
    {
      label: "StackTrace",
      name: "stackTrace",
      field: (row: ExceptionLogView) => row.stackTrace,
    },
    {
      label: "ExtraData",
      name: "extraData",
      field: (row: ExceptionLogView) => row.extraData,
    },
  ];

  rows: Array<ExceptionLogView> = [];

  form = {
    handledId: "",
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
  @WithLoading()
  async queryAsync(paged: PagedRequest) {
    this.isLoading = true;
    const res = await this.usePreviousRequestParamsAsync(async (req) => {
      return await this.apis.management.appLog.queryExceptionLogAsync(req);
    }, {...this.form, ...paged});

    this.rows = res.data.records;

    this.updatePagination(paged, res.data);

    this.isLoading = false;
  }

  // ========== listening ==========

  // ========== emit ==========
}
</script>

<style lang="scss" scoped></style>
