<template>
  <div>
    <c-subtitle title="資源下載區" />
    <c-form-card>
      <c-row>
        <c-column label="發布日期">
          <c-date-picker />
        </c-column>
        <c-column label="標題">
          <c-input />
        </c-column>
        <div class="col"></div>
        <div class="col-auto q-pt-lg">
          <c-btn-search />
        </div>
      </c-row>
    </c-form-card>
    <c-form-card>
      <c-table :loading="isLoading" :columns="columns" :rows="rows">
      </c-table>
    </c-form-card>
  </div>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";

export default class Resources extends ComponentBase {
  rows = [];
  columns = [
    {
      label: "發布日期",
      align: "center",
      name: "",
      // field: (row) => row,
      sortable: true,
    },
    {
      label: "標題",
      align: "center",
      name: "",
      // field: (row) => row,
      sortable: true,
    },
  ];
  isLoading = false;
}
</script>