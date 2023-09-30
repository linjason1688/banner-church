<template>
  <q-page class="q-pa-md">
    <q-form @submit="submitAsync" class="q-gutter-y-md">
      <div class="row">
        <div class="col">
          <c-page-title></c-page-title>
        </div>
        <div class="col-auto">
          <c-btn-history-back class="q-mr-md" />
          <c-btn-remove v-if="isUpdateMode" @click="removeAsync" class="q-mr-md" />
          <c-btn-save type="submit" />
        </div>
      </div>

      <div class="row flex justify-center">
        <div class="col-12 col-sm-10 col-md-8 col-lg-6">
          <c-input v-model="form.name" prefix="姓名：" class="q-my-md" />

          <c-select
            v-model="form.status"
            :options="statusList"
            option-label="label"
            option-value="value"
            map-options
            prefix="狀態："
            class="q-my-md"
          />

          <c-date-picker v-model="form.date" prefix="到職：" class="q-my-md" />

          <c-time-picker prefix="打卡：" class="q-my-md" />

          <div class="q-my-md">
            <q-radio
              v-for="group in groupList"
              :key="group.val"
              v-model="form.group"
              :val="group.val"
              :label="group.label"
            />
          </div>

          <div class="q-my-md">
            <c-btn-upload category="example" @uploaded="handleFileUploaded" :acceptTypes="['pdf', 'zip']" />
          </div>

          <q-list>
            <q-item tag="label" class="q-pa-none">
              <q-item-section avatar>
                <q-radio v-model="form.color" val="secondary" color="secondary" />
              </q-item-section>
              <q-item-section>
                <q-item-label>secondary</q-item-label>
              </q-item-section>
            </q-item>

            <q-item tag="label" class="q-pa-none">
              <q-item-section avatar>
                <q-radio v-model="form.color" val="info" color="info" />
              </q-item-section>
              <q-item-section>
                <q-item-label>info</q-item-label>
                <q-item-label caption>With description </q-item-label>
              </q-item-section>
            </q-item>

            <q-item tag="label" class="q-pa-none">
              <q-item-section avatar top>
                <q-radio v-model="form.color" val="accent" color="accent" />
              </q-item-section>
              <q-item-section>
                <q-item-label>accent</q-item-label>
                <q-item-label caption> Lots of text here </q-item-label>
              </q-item-section>
            </q-item>
          </q-list>

          <div class="q-my-md">
            <p class="text-center">datetime: {{ form.datetime }}</p>
            <div class="flex justify-around">
              <q-date v-model="form.datetime" mask="YYYY-MM-DD hh:mm" />
              <q-time v-model="form.datetime" mask="YYYY-MM-DD hh:mm" />
            </div>
          </div>
        </div>
      </div>

      <div class="row flex justify-center">
        <div class="col-12 col-sm-10 col-md-8 col-lg-6">
          <c-btn-save v-if="isUpdateMode" class="full-width" />
          <c-btn-create-save v-else class="full-width" />
        </div>
      </div>
    </q-form>
  </q-page>
</template>

<script lang="ts">
/* eslint-disable no-unused-vars, @typescript-eslint/no-unused-vars */
import { Options } from "vue-class-component";
import { Ref, Prop, Watch, Emit } from "vue-property-decorator";
import { State, Getter, Action } from "vuex-class";

import { ComponentBase } from "src/components/ComponentBase";
import { BusinessError } from "src/data/errors";
import { DetailComponentBase } from "src/components/DetailComponentBase";
import { WithLoading } from "src/util/TsDecorators";
import { FileUploadedEvent } from "src/data/dto";
/* eslint-enable */

@Options({
  meta() {
    return {
      title: "詳細資料",
    };
  },

  components: {},
})
export default class $Template$DetailPage extends DetailComponentBase {
  // ========== props ==========

  // ========== vuex ==========

  // ========== data ==========
  statusList = [
    {
      label: "啟用",
      value: 1,
    },
    {
      label: "停用",
      value: 0,
    },
  ];

  groupList = [
    {
      label: "group1",
      val: 1,
    },
    {
      label: "group2",
      val: 2,
    },
    {
      label: "group3",
      val: 3,
    },
  ];

  form = {
    name: "yozian",
    status: 1,
    group: 1,
    date: "",
    time: "",
    datetime: "",
    color: "",
  };

  // ========== computed ==========
  get isUpdateMode() {
    return !!this.id;
  }

  get tipName() {
    // TODO: change if needed
    return this.form.name;
  }

  get deletekey() {
    // TODO: change if needed
    return this.id;
  }

  // ========== watch ==========

  // ========== refs ==========

  // ========== hook ==========

  async mounted() {
    //
    //   if (this.isUpdateMode) {
    //      const res = await this.apis.management.mgrApi.findOneAsync({ id: this.id });
    //      Object.assign(this.form, res.data);
    //   }
  }

  // ========== methods ==========

  @WithLoading()
  async submitAsync() {
    if (this.isUpdateMode) {
      await this.updateAsync();
    } else {
      await this.createAsync();
    }
  }

  async createAsync() {
    await this.executeAsync(async () => {
      //
      // const request = Object.assign({}, this.form);
      // await this.apis.management.$Template$MgrApi.createAsync(request);
      //
      // this.$router.go(-1);
    });
  }

  async updateAsync() {
    await this.executeAsync(async () => {
      // remove the next line
      await this.sleep(0);

      // const request = Object.assign({}, this.form);

      // await this.apis.management.$Template$MgrApi.updateAsync(request);
    });
  }

  async removeAsync() {
    const confirm = await this.showConfirmDialogAsync(`是否要刪除 ${this.tipName}？`, "請再次確認");

    if (!confirm) {
      return;
    }

    /*
    const request = { id: this.deletekey };

    await this.apis.management.$Template$MgrApi.deleteAsync(request);

    this.$router.go(-1);
    */

    this.showSuccessNotify(`已刪除 ${this.tipName}`);
  }

  handleFileUploaded(e: FileUploadedEvent) {
    alert(e.fileKey);
  }

  // ========== listening ==========

  // ========== emit ==========
}
</script>

<style lang="scss" scoped></style>
