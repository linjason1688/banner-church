<template>
  <q-layout>
    <q-page-container>
      <q-page class="column flex-center">
        <c-wizard title="註冊" subtitle="旌旗小組調查" :step="step">
          <q-form @submit="doConfirm" class="q-gutter-y-md">
            <div>
              <div class="app-wizard-information-table">
                <div class="column items-center">
                  <div class="flex items-center justify-center app-wizard-information-caption"></div>
                </div>
                <div class="app-wizard-information-content">
                  <div class="q-pl-lg q-pt-lg inline-block">是否在旌旗小組</div>
                  <div class="inline-block app-required">*</div>
                  <div>
                    <c-field v-model="form.isChurchGroup" :rules="[(val) => !!val || '請選擇是否在旌旗小組']" borderless>
                      <q-list dense>
                        <q-item>
                          <q-item-section avatar>
                            <q-radio v-model="form.isChurchGroup" val="1" label="是" />
                          </q-item-section>
                        </q-item>

                        <q-item>
                          <q-item-section>
                            <q-input class="q-pl-sm" placeholder="　輸入小組編號，若忘記可之後再填"
                              v-model="form.churchGroupNo"></q-input>
                          </q-item-section>
                        </q-item>

                        <q-item>
                          <q-item-section avatar top>
                            <q-radio v-model="form.isChurchGroup" val="0" label="否" />
                          </q-item-section>
                        </q-item>
                      </q-list>
                    </c-field>
                  </div>
                </div>
              </div>

              <div v-if="form.isChurchGroup === '0'" class="app-wizard-information-table">
                <div class="column items-center">
                  <div class="flex items-center justify-center app-wizard-information-caption">入組意願調查</div>
                </div>
                <div class="app-wizard-information-content">
                  <div class="q-pl-lg q-pt-lg">請問您是否願意加入旌旗教會小組？</div>
                  <div>
                    <c-field :rules="[joinChurchGroupRule]">
                      <q-list dense>
                        <q-item tag="label" v-ripple>
                          <q-item-section avatar>
                            <q-radio v-model="form.isJoinChurchGroup" val="1" label="願意" />
                          </q-item-section>
                        </q-item>

                        <q-item tag="label" v-ripple>
                          <q-item-section avatar top>
                            <q-radio v-model="form.isJoinChurchGroup" val="0" label="不願意" />
                          </q-item-section>
                        </q-item>
                      </q-list>
                    </c-field>
                  </div>
                </div>
              </div>

              <div v-if="form.isChurchGroup === '0' && form.isJoinChurchGroup === '1'"
                class="app-wizard-information-table">
                <div class="column items-center">
                  <div class="flex items-center justify-center app-wizard-information-caption">參與形式偏好</div>
                </div>

                <div class="row justify-center">
                  <div class="col-12 q-pl-xl">
                    <div class="q-pl-sm">
                      <div class="q-pl-md q-pt-lg">期待小組屬性</div>
                      <div class="q-pl-sm q-pr-sm">
                        <c-field :rules="[joinTypeRule]" required>
                          <q-checkbox v-model="xform.joinInPerson" val="true" label="實體" />
                          <q-card flat bordered class="q-pa-md q-ml-xl q-mr-md c-dotted-border">
                            <c-form-group-meetup sequence="1" meetupCategory="offline"
                              v-model:day.sync="form.joinInPersonDate1" v-model:time.sync="form.joinInPersonTime1"
                              v-model:church.sync="form.joinInPersonLocation1" />
                            <c-form-group-meetup sequence="2" meetupCategory="offline"
                              v-model:day.sync="form.joinInPersonDate2" v-model:time.sync="form.joinInPersonTime2"
                              v-model:church.sync="form.joinInPersonLocation2" />
                            <c-form-group-meetup sequence="3" meetupCategory="offline"
                              v-model:day.sync="form.joinInPersonDate3" v-model:time.sync="form.joinInPersonTime3"
                              v-model:church.sync="form.joinInPersonLocation3" />
                          </q-card>
                          <q-checkbox v-model="xform.joinOnLine" val="true" label="線上" />
                          <q-card flat bordered class="q-pa-md q-ml-xl q-mr-md c-dotted-border">
                            <c-form-group-meetup sequence="1" meetupCategory="online"
                              v-model:day.sync="form.joinOnlineDate1" v-model:time.sync="form.joinOnlineTime1" />
                            <c-form-group-meetup sequence="2" meetupCategory="online"
                              v-model:day.sync="form.joinOnlineDate2" v-model:time.sync="form.joinOnlineTime2" />
                            <c-form-group-meetup sequence="3" meetupCategory="online"
                              v-model:day.sync="form.joinOnlineDate3" v-model:time.sync="form.joinOnlineTime3" />
                          </q-card>
                        </c-field>
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

          <q-dialog v-model="toggleBindLine">
            <div>
              <q-form @submit="gotoNext" class="q-gutter-y-md">
                <q-card>
                  <q-card-section class="text-center">
                    <div class="text-h5 text-bold">是否綁定Line?</div>
                  </q-card-section>
                  <q-card-section class="q-pt-none text-subtitle1 text-bold">
                    能夠更快接收到最新資訊，並享有Line相關會員福利。
                  </q-card-section>
                  <q-card-section class="q-pt-none q-pl-xl">
                    <q-radio v-model="form.bindLine" val="1" />
                    綁定
                  </q-card-section>
                  <q-card-section class="q-pt-none q-pl-xl">
                    <q-radio v-model="form.bindLine" val="0" />
                    不綁定
                  </q-card-section>

                  <q-card-actions align="center">
                    <q-btn flat label="下一步" type="submit" class="app-verification-wizard-next-btn" />
                  </q-card-actions>
                </q-card>
              </q-form>
            </div>
          </q-dialog>

        </c-wizard>
      </q-page>
    </q-page-container>
  </q-layout>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Prop } from "vue-property-decorator";
import { Options } from "vue-class-component";
import { SystemConfig } from "src/util";
import { SystemConfigState } from "src/data/dto/SystemConfigState";
import Wizard from "pages/signup/Wizard.vue";
import FormOrganization2 from "components/business/FormOrganization2.vue"
import FormGroupMeetup from "components/formGroup/FormGroupMeetup.vue";

@Options({
  components: {
    "c-wizard": Wizard,
    "c-form-organization": FormOrganization2,
    "c-form-group-meetup": FormGroupMeetup,
  },
})
export default class Group extends ComponentBase {
  @Prop({ type: String })
  title!: string;

  step = 4;
  toggleBindLine = false;

  xform = {
    joinOnLine: false,
    joinInPerson: false,
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
    joinOnlineTime3: "",
    bindLine: "0",
  };

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
    this.toggleBindLine = false;
    this.saveState();
    void this.$router.push("/signup/information");
  }

  doConfirm() {
    this.toggleBindLine = true;
  }

  saveState() {
    let form = Object.assign({ ...this.$appStore.getters.signUpState }, this.form);
    this.$appStore.mutations.setSignUpState(form);
  }

  joinTypeRule() {
    if (this.xform.joinInPerson) {
      if (this.form.joinInPersonDate1 && this.form.joinInPersonTime1 && this.form.joinInPersonLocation1) {
        return true;
      }
    }
    if (this.xform.joinOnLine) {
      if (this.form.joinOnlineDate1 && this.form.joinOnlineTime1) {
        return true;
      }
    }
    return "至少需填寫一個志願序";
  }

  joinChurchGroupRule() {
    if (this.form.isJoinChurchGroup) {
      return true;
    }
    return "請選擇入組意願";
  }

  bindLineRule() {
    if (this.form.bindLine) {
      return true;
    }
    return "請選擇是否綁定Line?";
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
