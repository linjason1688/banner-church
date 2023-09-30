<template>
  <q-select v-bind="$attrs"
            emit-value map-options
            :options="organizationList"
            option-value="id"
            option-label="name"
            use-input
            dense
  />
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { FetchAllOrganizationRequest, OrganizationView } from "src/api/feature";

export default class FormOrganization extends ComponentBase {
  organizationList: Array<OrganizationView> = [];

  async mounted() {
    const res = await this.apis.feature.organization.fetchOrganizations({} as FetchAllOrganizationRequest);
    this.organizationList = res.data;
  }
}
</script>
