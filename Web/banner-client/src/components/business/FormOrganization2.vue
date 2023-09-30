<template>
  <q-select v-bind="$attrs" map-options :options="organizationList" option-value="id" option-label="name" :rounded="false"
    dense outlined clearable behavior="menu">
  </q-select>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Prop } from "vue-property-decorator";
import { FetchAllOrganizationRequest, OrganizationView } from "src/api/feature";

export default class FormOrganization2 extends ComponentBase {
  @Prop({ type: String })
  title!: string;

  organizationList: Array<OrganizationView> = [];

  async mounted() {
    const res = await this.apis.feature.organization.fetchOrganizations2({} as FetchAllOrganizationRequest);
    this.organizationList = res.data;
  }
}
</script>

<style lang="scss" scoped>
@import "../../css/quasar.variables.scss";
</style>
