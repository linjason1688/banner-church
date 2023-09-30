<template>
  <div>
    <c-subtitle title="事工團成員管理" />
    <c-form-card>
      <c-row>
        <c-column label="堂點" class="col-12 col-sm-2">
          <c-form-organization v-model="form.organizationId" role="o"></c-form-organization>
        </c-column>
        <c-column class="col-12 col-sm-2">
        </c-column>
        <c-column label="事工團分類" class="col-12 col-sm-4">
          <c-form-ministry-def v-model="form.ministryDefId" role="o"></c-form-ministry-def>
        </c-column>
        <c-column label="事工團代碼" class="col-12 col-sm-4">
          <c-input v-model="form.ministryNo" role="n"></c-input>
        </c-column>
        <c-column label="事工團名稱" class="col-12 col-sm-4">
          <c-input v-model="form.name" role="n"></c-input>
        </c-column>
        <c-column label="性質" class="col-12 col-sm-4">
          <c-select class="inline-block full-width" emit-value map-options :options="natureList" v-model="form.nature"
            option-label="value" option-value="name" clearable role="o"></c-select>
        </c-column>
        <c-column label="狀態" class="col-12 col-sm-4">
          <c-option-group :options="ministryDefStatusList" clearable v-model="form.ministryStatus" />
        </c-column>
        <c-column class="col text-right">
          <q-btn color="indigo" icon="search" rounded @click="queryAsync()">查詢</q-btn>
        </c-column>
      </c-row>
    </c-form-card>
    <c-table :loading="isLoading" :columns="columns" :rows="rows" row-key="ministryDefId" ref="table"
      :rowsNumber="rowsNumber">
      <template v-slot:body-cell-actionEditMember="props">
        <c-btn-table-std @click="editMemberSettings(props.row.id)">事工團成員設定</c-btn-table-std>
      </template>
    </c-table>
  </div>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Options } from "vue-class-component";
import FormMinistryDef from "components/business/FormMinistryDef.vue";
import FormMinistry from "components/business/FormMinistry.vue";
import FormOrganization from "components/business/FormOrganization.vue";
import { SystemConfig } from "src/util";
import {
  SystemConfigView,
  QueryMinistryRequest,
  MinistryView,
  OrganizationView,
  MinistryDefView,
  QueryMinistryDefRequest,
} from "src/api/feature";
import { PagedRequest } from "src/data/dto";

interface Member$ {
  id: number;
  organizationName: string;
  ministryDefId: number;
  no: string;
  name: string;
  nature: string;
  statusCd: string;
  ministryPeopleQty: string;
}

interface OptionGroup {
  label: string;
  value: string;
}

@Options({
  components: {
    "c-form-ministry-def": FormMinistryDef,
    "c-form-ministry": FormMinistry,
    "c-form-organization": FormOrganization,
  },
})
export default class Member extends ComponentBase {
  natureList = [
    {
      value: "全部",
      name: "0",
    },
    {
      value: "部分",
      name: "1",
    },
    {
      value: "其它",
      name: "2",
    },
  ];

  columns = [
    {
      label: "",
      align: "center",
      name: "actionEditMember",
      field: (row: Member$) => row.id,
      sortable: true,
    },
    {
      label: "所在分堂",
      align: "center",
      name: "organizationName",
      field: (row: Member$) => row.organizationName,
      sortable: true,
    },
    {
      label: "所在分點",
      align: "center",
      name: "name",
    },
    {
      label: "事工團分類",
      align: "center",
      name: "ministryDefId",
      field: (row: Member$) => this.convertMinistryDefName(row.ministryDefId),
      sortable: true,
    },
    {
      label: "事工團代碼",
      align: "center",
      name: "no",
      field: (row: Member$) => row.no,
      sortable: true,
    },
    {
      label: "事工團名稱",
      align: "center",
      name: "name",
      field: (row: Member$) => row.name,
      sortable: true,
    },
    {
      label: "性質",
      align: "center",
      name: "nature",
      field: (row: Member$) => row.nature,
      sortable: true,
    },
    {
      label: "狀態",
      align: "center",
      name: "statusCd",
      field: (row: Member$) => row.statusCd,
      sortable: true,
    },
    {
      label: "事工團人數",
      align: "center",
      name: "ministryPeopleQty",
      field: (row: Member$) => row.ministryPeopleQty,
      sortable: true,
    },
  ];

  rows: Array<MinistryView> = [];

  form = {
    organizationId: "", //堂點
    ministryDefId: undefined, // 事工團分類
    ministryNo: "", //事工團代碼
    name: "", //事工團名稱
    nature: "", //性質
    ministryStatus: "", //狀態
  };

  rowsNumber = 0;
  organizationList = new Array<OrganizationView>();
  ministryDefStatusList: Array<OptionGroup> = [];
  ministryDefList: Array<MinistryDefView> = [];
  isLoading = false;

  async mounted() {
    this.ministryDefList = (
      await this.apis.feature.ministryDef.queryMinistryDefs({} as QueryMinistryDefRequest)
    ).data.records;
    this.organizationList = (await this.apis.feature.organization.fetchOrganizations()).data;
    let response = this.$appStore.getters.getSystemConfig(SystemConfig.MinistryDefStatus);
    this.ministryDefStatusList = this.convertOptionStruct(response);
    await this.usePreviousRequestParamsAsync(async (req) => {
      return await this.queryAsync(req);
    });
  }

  async queryAsync(request?: PagedRequest) {
    this.isLoading = true;

    request = Object.assign(request || {}, this.form);
    let response = (await this.apis.feature.ministry.queryMinistry(request as QueryMinistryRequest)).data.records;
    this.rows = response;
    this.rowsNumber = this.rows.length;
    this.isLoading = false;
  }

  convertMinistryDefName(index: number) {
    const found = this.ministryDefList.find((e) => e.id == index);
    if (found) return found.name;
    return index.toString();
  }

  convertOptionStruct(systemConfig: SystemConfigView[]) {
    let target: OptionGroup[] = [];
    for (let s of systemConfig) {
      let option: OptionGroup = {
        value: s.name,
        label: s.value,
      };
      target.push(option);
    }
    return target;
  }

  editMemberSettings(id: string) {
    console.log(id);
  }
}
</script>

<style lang="scss" scoped>
@import "../../css/quasar.variables.scss";
</style>
