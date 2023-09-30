<template>
  <div>
    <q-dialog v-bind="$attrs" v-model="syncedtoggleShow">
      <q-card>
        <q-card-section class="row justify-between q-pa-md c-gray-white c-primary-background-500">
          <div class="col-1"></div>
          <div class="col-auto">
            <div class="text-h6">線上奉獻規範與個資使用說明</div>
          </div>
          <div class="col-1 column items-center">
            <q-btn icon="close" flat round dense @click="syncedtoggleShow = false"/>
          </div>
        </q-card-section>

        <q-card-section class="row q-px-xs">
          <q-scroll-area style="height: 400px; width: 528px; max-width: 528px;">
            <div class="q-px-md q-mb-md">
              親愛的弟兄姊妹，平安：
            </div>
            <div class="q-px-md q-mb-md">
              感謝您對教會事工的支持！為配合「個人資料保護法」規定及保障您的權益，請您務必詳細閱讀下列內容；當您使用本線上奉獻平台填寫奉獻相關資料、進行線上奉獻時，均視為已閱讀、知悉並同意台中旌旗教會/台中市基督教旌旗協會於下述範圍內，蒐集、處理及利用您的個人資料：
            </div>
            <div class="q-px-md q-mb-md">
              一、為了完成交易，所有在本站進行線上奉獻的奉獻者，都必須擔保所留存的資料與事實相符。
            </div>
            <div class="q-px-md q-mb-md">
              二、對於奉獻者所留存的資料，本站除採用安全交易模式外，並承諾負保密義務，除了為完成該筆交易或稅務申報而提供給相關配合單位以外，不會任意洩漏或提供給第三人。網站線上奉獻蒐集個人資料包括：
            </div>
            <div class="q-px-md q-mb-md">
              　　1、辨識個人者：如捐款者姓名、地址、電話、電子郵件等資訊。
              <br/>
              <br/>
              　　2、辨識財務者：如信用卡、轉帳等資訊。
              <br/>
              <br/>
              　　3、政府資料辨識者：如身分證字號或護照號碼(外國人)等資訊。
            </div>
            <div class="q-px-md q-mb-md">
              三、奉獻者對於其個人資料、付款資料及會員帳號、密碼等資料，應妥善保管以避免外洩。所有使用其帳號和密碼進入本系統後之行為，均視為該帳號及密碼持有人之行為。
            </div>
            <div class="q-px-md q-mb-md">
              四、奉獻者一旦在本站進行線上奉獻，即表示出於自由意志奉獻並願遵守教會之奉獻規則。於本站進行線上奉獻者，同意以本站所紀錄之電子交易資料為準，如發現交易資料不正確，應立即通知教會財務同工。
            </div>
            <div class="q-px-md q-mb-md">
              五、於下列情形，本站有權提供奉獻者之個人資料予有權機關、或主張其權利受侵害並提出適當證明之第三人：
            </div>
            <div class="q-px-md q-mb-md">
              五、於下列情形，本站有權提供奉獻者之個人資料予有權機關、或主張其權利受侵害並提出適當證明之第三人：
            </div>
            <div class="q-px-md q-mb-md">
              ※依法令規定或依司法機關或其他有權機關的命令；
              <br/>
              ※為執行本條款或奉獻者違反本條款；
              <br/>
              ※為維護本站系統之正常運作及安全；
              <br/>
              ※為保護本站、其他奉獻者、或其他第三人的合法權益。
              <br/>
              <br/>
              若您有其他相關問題，請電洽(04)2258-4446分機408
              <br/>
              或E-mail：fin@wwbch.org，我們將儘速處理與回覆。
              <br/>
              <br/>
              誠摯感謝您對教會的奉獻支持，並敬祝平安、喜樂 ！
              <br/>
              台中旌旗教會/ 台中市基督教旌旗協會
            </div>
          </q-scroll-area>
        </q-card-section>
      </q-card>
    </q-dialog>
  </div>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { PropSync } from "vue-property-decorator";

export default class PrivacyText extends ComponentBase {

  @PropSync("toggleShow",{ type: Boolean})
  syncedtoggleShow!: boolean;

  async mounted() {
    //
  }

}
</script>

<style lang="scss" scoped>
@import '../../css/quasar.variables.scss';

</style>
