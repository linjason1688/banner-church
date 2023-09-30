<template>
  <div>
    <q-layout class="q-ma-xl">
      <q-page-container>
        <q-page>
          <div class="row justify-center">
            <div class="col-6 q-mr-xl">
              <div class="text-h6 text-bold">
                <q-avatar square>
                  <img src="/img/stroke.svg" />
                </q-avatar>
                <span class="c-primary-color-500 c-content-title">
                待辦事項
                </span>
              </div>
              <q-separator class="row1 q-mt-xl q-mb-xl" spaced inset />
              <div>
                <q-list>
                  <q-item tag="label" class="q-pa-none">
                    <q-item-section avatar>
                      <q-avatar>
                        <img src="/img/check.svg" />
                      </q-avatar>
                    </q-item-section>
                    <q-item-section>
                      <div class="c-content-subtitle">
                        問卷填寫：
                        <span class="q-link">{{ form.questionnaire }}</span>
                        件
                      </div>
                    </q-item-section>
                  </q-item>
                  <q-item tag="label" class="q-pa-none">
                    <q-item-section avatar>
                      <q-avatar>
                        <img src="/img/check.svg" />
                      </q-avatar>
                    </q-item-section>
                    <q-item-section>
                      <div class="c-content-subtitle">
                        作業繳交：
                        <span class="q-link">{{ form.homeworks }}</span>
                        件
                      </div>
                    </q-item-section>
                  </q-item>
                  <q-item tag="label" class="q-pa-none">
                    <q-item-section avatar>
                      <q-avatar>
                        <img src="/img/check.svg" />
                      </q-avatar>
                    </q-item-section>
                    <q-item-section>
                      <div class="c-content-subtitle">
                        新人跟進：
                        <span class="q-link">{{ form.newFollower }}</span>
                        件
                      </div>
                    </q-item-section>
                  </q-item>
                </q-list>
              </div>
            </div>
            <div class="col-4">
              <q-card flat bordered>
                <q-card-section class="q-ma-lg">
                  <q-avatar class="inline-block">
                    <img src="/img/avatar.svg" />
                  </q-avatar>
                  <div class="q-ma-md inline-block">
                    <div class="c-content-subtitle c-text-color-100">sss110612</div>
                    <div class="c-content-body c-text-color-60">一般會員</div>
                  </div>
                  <q-separator class="row q-mt-xl" spaced inset />
                  <div class="text-subtitle2 c-text-color-100 text-bold">{{ form.memberName }}</div>
                  <div class="c-content-body c-text-color-100">位置</div>
                  <div class="c-content-body c-text-color-100">{{ form.location }}</div>
                  <div>
                    <q-avatar>
                      <img src="/img/phone.svg" class="c-icon" />
                    </q-avatar>
                    {{ form.mobileNo }}
                  </div>
                  <div>
                    <q-avatar>
                      <img src="/img/mail.svg" class="c-icon" />
                    </q-avatar>
                    {{ form.email }}
                  </div>
                </q-card-section>
              </q-card>
            </div>
          </div>

        </q-page>
      </q-page-container>
    </q-layout>
  </div>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";

export default class Main extends ComponentBase {

  form = {
    memberType: "一般會員",
    memberName: "張天天",
    email: "abc123@gmail.com.tw",
    location: "旌旗教會 / 台中 / 台中分堂 / XX小組 / 一般會員",
    mobileNo: "0963111111",
    questionnaire: 10,
    homeworks: 10,
    newFollower: 10,
  };

  async mounted() {
    //
  }

}
</script>

<style lang="scss" scoped>
@import '../../css/quasar.variables';
@import '../../css/app';

</style>
