<template>
  <q-layout>
    <q-page-container>
      <q-page class="column flex-center">
        <c-wizard title="註冊" subtitle="帳號驗證" step="2">
          <q-form @submit="gotoNext" class="q-gutter-y-md">
            <div class="col column items-center">
              <div class="col app-verification-wizard-caption">請輸入您的Email或電話號碼</div>
            </div>

            <q-field label="聯繫方式"
                     v-model="form.verificationType"
                     :rules="[(val) => !!val || '請選擇聯繫方式']"
                     borderless
            >
              <template v-slot:control>
                <div class="row q-pa-lg">
                  <div class="col-9">
                    <c-option-group :options="verificationList" class="inline-block" color="primary" v-model="form.verificationType"
                                    :rules="[(val) => !!val || '請選擇聯繫方式']"/>
                  </div>
                  <div class="col-3">
                    <c-btn v-if="!sendingCode" class="app-verification-send-btn inline-block" label="傳送驗證碼" @click="sendCode()" />
                    <div v-if="sendingCode" class="inline-block app-verification-counter-text">
                      {{ this.counter }} 秒後重新發送
                    </div>
                  </div>
                </div>
              </template>
           </q-field>
            <c-field label="輸入驗證碼">
              <c-input placeholder="驗證碼" v-model="form.verification"
                       :rules="[(val) => !!val || '請輸入驗證碼']" />
            </c-field>

            <div class="col1 column items-center" style="margin-bottom: 48px; margin-top: 24px">
              <div>
                <c-btn label="上一步" class="app-verification-wizard-btn" :to="{ path: '/signup/profile' }"></c-btn>
                <c-btn type="submit" label="下一步" class="app-verification-wizard-btn"></c-btn>
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

@Options({
  components: {
    "c-wizard": Wizard,
  },
})
export default class Verification extends ComponentBase {
  @Prop({ type: String })
  title!: string;

  @Prop({ type: String })
  subtitle!: string;

  waitingSeconds = 60;
  sendingCode = false;
  counter = 1;

  verificationList = [
    {
      label: "手機",
      value: "0",
    },
    {
      label: "Email",
      value: "1",
    },
  ];

  form = {
    verificationType: "",
    verification: "",
  };

  async mounted() {
    //
  }

  sendCode() {
    this.sendingCode = true;
    this.counter = this.waitingSeconds;
    let timer = setInterval(() => {
      this.counter -= 1;
      if (this.counter <= 0) {
        this.sendingCode = false
        this.counter = this.waitingSeconds;
        clearInterval(timer);
      }
    }, 1000);
  }

  gotoNext() {
    void this.$router.push("/signup/information");
  }
}
</script>

<style lang="scss" scoped>
@import "../../css/quasar.variables.scss";

.app-verification-send-btn {
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;
  padding: 10px 24px;
  gap: 8px;

  width: 128px;
  height: 32px;
  /* Primary/500 */

  background: #0C3176;
  border-radius: 20px;

  /* Inside auto layout */
  flex: none;
  order: 0;
  flex-grow: 0;

  /* Button/Button-sm */

  font-family: $primary-font-family;
  font-style: normal;
  font-weight: 700;
  font-size: 14px;
  line-height: 20px;
  font-feature-settings: 'tnum' on, 'lnum' on;

  /* TextColor/White */

  color: #FFFFFF;
}

//.app-verification-wizard-btn {
//  box-sizing: border-box;
//
//  margin-left: 56px;
//  padding: 10px 24px;
//  gap: 8px;
//
//  width: 96px;
//  height: 43px;
//
//  /* Gray/White */
//
//  background: #ffffff;
//  /* Primary/500 */
//
//  border: 2px solid #0c3176;
//  border-radius: 20px;
//
//  /* Inside auto layout */
//  flex: none;
//  order: 0;
//  flex-grow: 0;
//
//  /* Button/Button-lg */
//
//  font-family: $primary-font-family;
//  font-style: normal;
//  font-weight: 700;
//  line-height: 23px;
//  font-feature-settings: "tnum" on, "lnum" on;
//  color: #0c3176;
//}

.app-verification-wizard-caption {
  width: 231px;
  height: 25px;
  left: calc(50% - 231px / 2 + 0.5px);
  max-resolution: 32px;

  /* Content/Title */

  font-family: $primary-font-family;
  font-style: normal;
  font-weight: 700;
  font-size: 18px;
  line-height: 140%;
  /* or 25px */

  font-feature-settings: "tnum" on, "lnum" on;
  /* TextColor/100% */
  color: #282828;
}

.app-verification-counter-text {
  font-family: $primary-font-family;
  font-style: normal;
  font-weight: 700;
  font-size: 14px;
  line-height: 20px;
  font-feature-settings: 'tnum' on, 'lnum' on;

  /* TextColor/38% */

  color: rgba(40, 40, 40, 0.38);


  /* Inside auto layout */

  flex: none;
  order: 1;
  flex-grow: 0;
}

</style>
