<template>
  <q-page class="q-pa-lg">
    <div class="row">
      <div class="col-12 col-md-12">
        <c-subtitle title="事工團基本資料管理" />
      </div>
    </div>
    <c-form-card class="ministry_page q-mx-auto q-mt-xl" bordered="false">
      <q-form @submit="submitAsync" class="q-gutter-y-md">
        <div class="row justify-center">
          <div class="col-12 col-md-10">
            <c-field label="事工團分類">
              <c-select outlined v-model="form.ministryDefId" emit-value map-options :options="ministryDefList"
                option-value="id" option-label="name" />
            </c-field>
          </div>
          <div class="col-12 col-md-10">
            <c-field label="事工團代碼">
              <c-input v-model="form.ministryNo"></c-input>
            </c-field>
          </div>
          <div class="col-12 col-md-10">
            <c-field label="事工團名稱">
              <c-input v-model="form.name" />
            </c-field>
          </div>
        </div>
      </q-form>
    </c-form-card>
    <c-form-card class="ministry_page q-mx-auto" bordered="false">
      <q-form @submit="submitAsync" class="q-gutter-y-md">
        <div v-for="(item, index) in form.ministryResps" :key="index" class="row justify-center">
          <div class="col-12 col-md-8">
            <c-field :label="'事工團職分' + (index + 1)">
              <c-input v-model="item.name" />
            </c-field>
          </div>
          <div class="col-12 col-md-2 q-pt-lg">
            <c-field>
              <q-checkbox v-model="item.manageType" true-value="1" false-value="0">管理職</q-checkbox>
            </c-field>
          </div>
        </div>
      </q-form>
      <div class="row justify-start q-ml-xl">
        <c-btn-icon-after class="col-12 col-md-3" btnName="add" @click="addResp">新增事工團職分</c-btn-icon-after>
      </div>
    </c-form-card>
    <c-form-card class="ministry_page q-mx-auto" bordered="false">
      <q-form @submit="submitAsync" class="q-gutter-y-md">
        <div class="row justify-center">
          <div class="col-12 col-md-10">
            <c-field label="兒童事工團">
              <q-checkbox v-model="form.childMinistry" true-value="1" false-value="0" />
            </c-field>
            <div class="col-12 col-md-10">
              <c-field label="狀態" required-mark="1">
                <q-radio v-model="form.ministryStatus" val="1" label="啟用" />
                <q-radio v-model="form.ministryStatus" val="0" label="停用" />
              </c-field>
            </div>
          </div>
        </div>
        <div class="row">

        </div>
      </q-form>
    </c-form-card>
    <div class="row justify-center">
      <div class="col-12 col-md-8">
        <c-btn-history-back class="q-mr-md" />
        <c-btn-remove v-if="isUpdateMode" @click="removeAsync" class="q-mr-md" />
        <c-btn-save type="submit" @click="submitAsync" />
      </div>
    </div>
  </q-page>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import { DetailComponentBase } from "src/components/DetailComponentBase";
import { WithLoading } from "src/util/TsDecorators";
import {
  AddMinistryCommand, CreateMinistryRespCommand,
  DeleteMinistryDefCommand, MinistryDefView, MinistryRespView, QueryMinistryRespRequest,

} from "src/api/feature";
import MinistryRespList from "../ministry-resp/List.vue";
import { request } from "http";

interface MinistryResp$ {
  seq: number;
  name: string;
  manageType: string;
}

@Options({
  meta() {
    return {
      title: "詳細資料",
    };
  },

  components: {},
})
export default class Detail extends DetailComponentBase {
  form = {
    ministryDefId: "",
    ministryId: "",
    ministryNo: "",
    name: "",
    childMinistry: "0",
    ministryStatus: "1",
    ministryResps: new Array<MinistryResp$>(),
  };

  ministryDefList = new Array<MinistryDefView>();
  ministryRespList = new Array<MinistryRespView>();

  get isUpdateMode() {
    return !!this.id;
  }

  get tipName() {
    return this.form.name;
  }

  get deleteKey() {
    return this.id;
  }

  async mounted() {
    if (this.form.ministryResps.length < 6) {
      let current = this.form.ministryResps.length;
      for (let i = 0; i < 6 - current; i++) {
        this.addResp(i + 1);
      }
    }
    this.ministryDefList = (await this.apis.feature.ministryDef.fetchMinistryDefs()).data;
    this.ministryRespList = (await this.apis.feature.ministryResp.fetchMinistryResps({
      ministryId: this.id,
      size: 1000,
    } as unknown as QueryMinistryRespRequest)).data;

    //Object.assign(this.form.ministryResps || {}, this.ministryRespList);

    if (this.isUpdateMode) {
      const res = await this.apis.feature.ministry.getMinistry(this.id as unknown as number);
      Object.assign(this.form.ministryResps, this.ministryRespList.sort((a, b) => a.seq - b.seq));
      Object.assign(this.form, res.data);

    }
  }
  @WithLoading()
  async submitAsync() {
    if (this.isUpdateMode) {
      await this.updateAsync();
      console.log("xxxx", "更新囉",)
    } else {
      await this.createAsync();

      console.log("xxxx", "新增囉")
    }

    this.showSuccessNotify("已儲存");
  }

  async createAsync() {
    await this.executeAsync(async () => {
      const request = Object.assign({}, this.form) as unknown as AddMinistryCommand;
      request.ministryResps = this.form.ministryResps.filter(e => e.name !== "") as Array<CreateMinistryRespCommand>;
      await this.apis.feature.ministry.createMinistry(request);
      this.$router.go(-1);
    });
  }

  async updateAsync() {
    await this.executeAsync(async () => {
      const request = Object.assign({}, this.form) as unknown as AddMinistryCommand;
      // eslint-disable-next-line
      request.ministryResps = request.ministryResps.map(({ id, ...rest }) => rest) as Array<CreateMinistryRespCommand>;
      await this.apis.feature.ministry.putMinistry(request as unknown as AddMinistryCommand);
      console.log(request);
    });
  }

  async removeAsync() {
    const confirm = await this.showConfirmDialogAsync(`確定刪除 ${this.tipName}？`, "請再次確認");
    if (!confirm) {
      return;
    }

    const request = { id: this.deleteKey };
    await this.apis.feature.ministry.deleteMinistry(request as unknown as DeleteMinistryDefCommand);
    this.$router.go(-1);
    this.showSuccessNotify(`已刪除 ${this.tipName}`);
  }

  addResp(seq: number) {
    this.form.ministryResps.push(
      new class implements MinistryResp$ {
        manageType = "0";
        name = "";
        seq = seq;
      },
    );
  }
}
</script>

<style lang="scss" scoped>
.ministry_page {
  max-width: 1000px;
}
</style>
