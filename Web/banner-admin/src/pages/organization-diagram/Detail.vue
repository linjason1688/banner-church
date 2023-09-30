<template>
  <q-page class="q-pa-lg">
    <c-subtitle title="牧養組織列表 / 新增" />
    <c-form-card class="q-pa-xl">
      <c-row>
        <c-column v-for="upperOrg, i in upperOrgs" :key="i" class="col-6" :label="i == 0 ? '上層組織' : ''">
          <q-select outlined v-model="upperOrg.id" :options="orgs" option-label="name" option-value="id" map-options />
        </c-column>
      </c-row>
    </c-form-card>
    <c-form-card class="q-pa-xl">
      <c-row>
        <c-column class="col-12" label="組織名稱">
          <q-input v-model="form.name" />
        </c-column>
        <c-column class="col-12" label="狀態">
          <q-radio v-model="form.orgStatus" val="1" label="啟用" />
          <q-radio v-model="form.orgStatus" val="0" label="停用" />
        </c-column>
        <c-column class="col-12" label="職分主管">
          <q-select v-model="form.pastorName" :options="pastrals" option-label="name" option-value="id" map-options />
        </c-column>
      </c-row>
    </c-form-card>
    <div class="text-center q-gutter-lg">
      <c-btn-save type="submit" />
      <c-btn-history-back />
    </div>
  </q-page>
</template>

<script lang="ts">
import { OrganizationView, PastoralView } from "src/api/feature";
import { Vue } from "vue-class-component";

export default class Detail extends Vue {
  pastrals: PastoralView[] = [];
  orgs: OrganizationView[] = [];
  upperOrgs: OrganizationView[] = [];
  form = {
    upperOrganizationId: 0,
    id: 0,
    name: "",
    orgStatus: "",
  } as OrganizationView;
  async mounted() {
    this.pastrals = (await this.apis.feature.pastoral.queryPastorals())?.data.records || []
    this.orgs = (await this.apis.feature.organization.queryOrganizations())?.data.records || [];
    const upperMap = Object.fromEntries(this.orgs.map(x => [x.id, String(x.upperOrganizationId)]));
    const orgMap = Object.fromEntries(this.orgs.map(x => [x.id, x]));
    let id = String(this.$route.params.id), maxIter = 99;
    while (id in upperMap && maxIter--) {
      id = upperMap[id];
      this.upperOrgs.unshift(orgMap[id]);
    }
  }
}
</script>