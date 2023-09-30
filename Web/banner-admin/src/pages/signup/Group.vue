<template>
  <q-layout>
    <q-page-container>
      <q-page class="column flex-center">
        <c-wizard title="註冊" subtitle="旌旗小組調查" step="4">
          <q-form @submit="gotoNext" class="q-gutter-y-md">
            <div>
              <div class="app-wizard-information-table">
                <div class="column items-center">
                  <div class="flex items-center justify-center app-wizard-information-caption"></div>
                </div>
                <div class="app-wizard-information-content">
                  <div class="q-pl-lg q-pt-lg inline-block">是否在旌旗小組</div>
                  <div class="inline-block app-required">*</div>
                  <div>
                    <c-field
                      v-model="form.isChurchGroup"
                      :rules="[(val) => !!val || '請選擇是否在旌旗小組']"
                      borderless>
                      <q-list dense>

                        <q-item>
                          <q-item-section avatar>
                            <q-radio v-model="form.isChurchGroup" val="Y" label="是" />
                          </q-item-section>
                        </q-item>

                        <q-item>
                          <q-item-section>
                            <q-input class="q-pl-lg" placeholder="輸入小組編號，若忘記可之後再填"
                                     v-model="form.churchGroupNo"></q-input>
                          </q-item-section>
                        </q-item>

                        <q-item>
                          <q-item-section avatar top>
                            <q-radio v-model="form.isChurchGroup" val="N" label="否" />
                          </q-item-section>
                        </q-item>
                      </q-list>
                    </c-field>
                  </div>
                </div>
              </div>

              <div class="app-wizard-information-table">
                <div class="column items-center">
                  <div class="flex items-center justify-center app-wizard-information-caption">入組意願調查</div>
                </div>
                <div class="app-wizard-information-content">
                  <div class="q-pl-lg q-pt-lg">請問您是否願意加入旌旗教會小組？</div>
                  <div>
                    <div>
                      <q-list dense>
                        <q-item tag="label" v-ripple>
                          <q-item-section avatar>
                            <q-radio v-model="form.isJoinChurchGroup" val="Y" label="願意" />
                          </q-item-section>
                        </q-item>

                        <q-item tag="label" v-ripple>
                          <q-item-section avatar top>
                            <q-radio v-model="form.isJoinChurchGroup" val="N" label="不願意" />
                          </q-item-section>
                        </q-item>
                      </q-list>
                    </div>
                  </div>
                </div>
              </div>

              <div class="app-wizard-information-table">
                <div class="column items-center">
                  <div class="flex items-center justify-center app-wizard-information-caption">參與形式偏好</div>
                </div>

                <div class="app-wizard-information-content">
                  <div class="q-pl-lg q-pt-lg">期待小組屬性</div>
                  <div>
                    <div class="q-pl-lg">
                      <div>
                        <q-checkbox v-model="joinType" val="0" label="實體" />
                      </div>
                      <div>
                        <div class="app-wizard-information-content-input">
                          <div class="row flex items-center">
                            <div class="col-2">志願序</div>
                            <div class="col-3">星期</div>
                            <div class="col-3">時段</div>
                            <div class="col-3">堂點</div>
                          </div>
                          <div class="row flex items-center">
                            <div class="col-2">1</div>
                            <div class="col-3">
                              <c-select v-model="form.joinInPersonDate1" emit-value map-options
                                        :options="weekList"></c-select>
                            </div>
                            <div class="col-3">
                              <c-select v-model="form.joinInPersonTime1" emit-value map-options
                                        :options="timeList"></c-select>
                            </div>
                            <div class="col-3">
                              <c-select v-model="form.joinInPersonLocation1" emit-value map-options
                                        option-value="value"
                                        option-label="name"
                                        :options="locationList"></c-select>
                            </div>
                          </div>
                          <div class="row flex items-center">
                            <div class="col-2">2</div>
                            <div class="col-3">
                              <c-select v-model="form.joinInPersonDate2" emit-value map-options
                                        :options="weekList"></c-select>
                            </div>
                            <div class="col-3">
                              <c-select v-model="form.joinInPersonTime2" emit-value map-options
                                        :options="timeList"></c-select>
                            </div>
                            <div class="col-3">
                              <c-select v-model="form.joinInPersonLocation2" emit-value map-options
                                        option-value="value"
                                        option-label="name"
                                        :options="locationList"></c-select>
                            </div>
                          </div>
                          <div class="row flex items-center">
                            <div class="col-2">3</div>
                            <div class="col-3">
                              <c-select v-model="form.joinInPersonDate3" emit-value map-options
                                        :options="weekList"></c-select>
                            </div>
                            <div class="col-3">
                              <c-select v-model="form.joinInPersonTime3" emit-value map-options
                                        :options="timeList"></c-select>
                            </div>
                            <div class="col-3">
                              <c-select v-model="form.joinInPersonLocation3" emit-value map-options
                                        option-value="value"
                                        option-label="name"
                                        :options="locationList"></c-select>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                    <div class="q-pl-lg">
                      <div class="col">
                        <q-checkbox v-model="joinType" val="1" label="線上" />
                      </div>
                      <div class="col">
                        <div class="app-wizard-information-content-input">
                          <div class="row flex items-center">
                            <div class="col-2">志願序</div>
                            <div class="col-3">星期</div>
                            <div class="col-3">時段</div>
                          </div>
                          <div class="row flex items-center">
                            <div class="col-2">1</div>
                            <div class="col-3">
                              <c-select v-model="form.joinOnlineDate1" emit-value map-options
                                        :options="weekList"></c-select>
                            </div>
                            <div class="col-3">
                              <c-select v-model="form.joinOnlineTime1" emit-value map-options
                                        :options="timeList"></c-select>
                            </div>
                          </div>
                          <div class="row flex items-center">
                            <div class="col-2">2</div>
                            <div class="col-3">
                              <c-select v-model="form.joinOnlineDate2" emit-value map-options
                                        :options="weekList"></c-select>
                            </div>
                            <div class="col-3">
                              <c-select v-model="form.joinOnlineTime2" emit-value map-options
                                        :options="timeList"></c-select>
                            </div>
                          </div>
                          <div class="row flex items-center">
                            <div class="col-2">3</div>
                            <div class="col-3">
                              <c-select v-model="form.joinOnlineDate3" emit-value map-options
                                        :options="weekList"></c-select>
                            </div>
                            <div class="col-3">
                              <c-select v-model="form.joinOnlineTime3" emit-value map-options
                                        :options="timeList"></c-select>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>

            <div class="column items-center" style="margin-bottom: 48px; margin-top: 24px">
              <div>
                <q-btn label="上一步" class="app-verification-wizard-btn" @click="gotoBack()"></q-btn>
                <q-btn type="submit" label="下一步" class="app-verification-wizard-next-btn"></q-btn>
              </div>
            </div>
          </q-form>
        </c-wizard>
      </q-page>
    </q-page-container>
  </q-layout>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Prop } from "vue-property-decorator";
import { Options } from "vue-class-component";
import Wizard from "pages/signup/Wizard.vue";
import { ref } from "vue";
import { SystemConfigState } from "src/data/dto/SystemConfigState";
import { SystemConfig } from "src/util";

@Options({
  components: {
    "c-wizard": Wizard,
  },
})
export default class Group extends ComponentBase {
  @Prop({ type: String })
  title!: string;

  xform = {
    joinOnLine: false,
    joinInPerson: false,
    joinType1: null,
    joinType2: null,
    isOldMember: "Y",
  };

  form = {
    isChurchGroup: "",
    churchGroupNo: "",
    isJoinChurchGroup: "",
    joinInPersonDate1: "",
    joinInPersonTime1: "",
    joinInPersonLocation1: "",
    joinInPersonDate2: "",
    joinInPersonTime2: "",
    joinInPersonLocation2: "",
    joinInPersonDate3: "",
    joinInPersonTime3: "",
    joinInPersonLocation3: "",
    joinOnlineDate1: "",
    joinOnlineTime1: "",
    joinOnlineDate2: "",
    joinOnlineTime2: "",
    joinOnlineDate3: "",
    joinOnlineTime3: ""
  };

  joinType = ref([]);
  weekList = [
    {
      label: "星期一",
      value: "1",
    },
    {
      label: "星期二",
      value: "2",
    },
    {
      label: "星期三",
      value: "3",
    },
    {
      label: "星期四",
      value: "4",
    },
    {
      label: "星期五",
      value: "5",
    },
    {
      label: "星期六",
      value: "6",
    },
    {
      label: "星期日",
      value: "7",
    },
  ];
  timeList = [
    {
      label: "上午",
      value: "1",
    },
    {
      label: "下午",
      value: "2",
    },
  ];
  locationList!: Array<SystemConfigState>;

  mounted() {
    this.form = Object.assign(this.form, this.$appStore.getters.signUpState);
    this.locationList = this.$appStore.getters.getSystemConfig(SystemConfig.ChurchNameList);
  }

  async gotoNext() {
    this.saveState();
    if (this.$appStore.getters.userProfile.id == null) {
      await this.apis.feature.user.signUp(this.$appStore.getters.signUpState);
    } else {
      let form = Object.assign({ ...this.$appStore.getters.signUpState }, this.form);
      form.id = this.$appStore.getters.userProfile.id;

      this.$appStore.mutations.setSignUpState(form);
      await this.apis.feature.user.updateMember(this.$appStore.getters.signUpState.id, form);
    }
    void this.$router.push("/signup/done");
  }

  gotoBack() {
    this.saveState();
    void this.$router.push("/signup/information");
  }

  saveState() {
    let form = Object.assign({ ...this.$appStore.getters.signUpState }, this.form);
    this.$appStore.mutations.setSignUpState(form);
  }
}
</script>

<style lang="scss" scoped>
@import "../../css/quasar.variables.scss";
@import "../../css/app.scss";

.app-wizard-information-content-title {
  padding-left: 24px;
}

.app-wizard-information-content-input {
  margin-left: 48px;
}
</style>
