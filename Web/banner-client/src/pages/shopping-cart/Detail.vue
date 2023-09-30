<template>
  <div class="c-background-content">
    <div class="row justify-center c-background-content">
      <div class="col-12 col-sm-10 q-pa-lg">
        <c-nav-shopping-cart title="課程內容" />

        <div class="row">
          <div class="col-12 col-md-3">
            <img src="/img/class-banner.svg" alt="">
          </div>
        </div>

        <!--    內容-->
        <div class="row">
          <div class="col-md-9">
            <div class="q-mt-lg q-mb-lg">
              <div class="c-heading-h3">{{ form.classTitle }}</div>
            </div>
            <div class="q-mt-lg q-mb-lg c-content-title c-primary-color-500">課程簡介</div>

            <div class="q-ma-lg">
              <c-display-field label="課程內容">
                {{ form.content }}
              </c-display-field>
              <c-display-field label="課程講師">
                {{ form.teacher }}
              </c-display-field>
              <c-display-field label="開課堂點">
                {{ form.organizationName }}
              </c-display-field>
              <c-display-field label="課程日期與地點">
                <div class="c-content-body">
                  <div v-for="item in form.timeSchedules" :key="item.id">
                    日期：{{ item.classTimeS }} ~ {{ item.classTimeE }}
                    地點：{{ item.place }}
                  </div>
                </div>
              </c-display-field>
            </div>

            <div class="c-content-title c-primary-color-500">報名資訊</div>
            <div class="q-ma-lg">
              <c-display-field label="報名日期">
                臨櫃：{{ form.signUpDateS }} ~ {{ form.signUpDateS }}
                線上：{{ form.signUpDateOnlineS }} ~ {{ form.signUpDateOnlineE }}
              </c-display-field>
              <c-display-field label="報名名額">
                {{ form.quota }}
              </c-display-field>
              <c-display-field label="報名資格">
                {{ form.description }}
              </c-display-field>
              <c-display-field label="報名費用">
                {{ form.price }}
              </c-display-field>
            </div>

            <div class="c-content-title c-primary-color-500">其他應注意事項</div>
            <div class="q-ma-lg">
              <c-display-field label="結業標準">
                {{ form.graduationQualification }}
              </c-display-field>
              <c-display-field label="退費原則">
                {{ form.refund }}
              </c-display-field>
              <c-display-field label="注意事項">
                {{ form.specialRequirement }}
              </c-display-field>
            </div>
          </div>
          <div class="col-md-3">
            <div class="row1">
              <div class="row q-mt-lg q-mb-lg">
                <div class="col-12 c-content-subtitle c-gray-900">對此課程</div>
              </div>
              <div class="row q-mt-lg q-mb-lg">
                <div class="col-12">
                  <c-btn label="立即報名" class="c-button-core"></c-btn>
                </div>
              </div>
              <div class="row q-mt-xl q-mb-lg">
                <div class="col-12 c-content-subtitle c-gray-900">
                  或是選擇
                </div>
              </div>
              <div class="row q-mt-lg q-mb-lg">
                <c-btn label="加入追踨" class="c-button-core c-bgcolor-gray-white"></c-btn>
              </div>
              <div class="row q-mt-lg q-mb-lg">
                <c-btn label="放入購物車" class="c-button-core c-bgcolor-gray-white"></c-btn>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import { DetailComponentBase } from "src/components/DetailComponentBase";
import FormOrganization from "components/business/FormOrganization.vue";
import DisplayField from "pages/shopping-cart/_DisplayField.vue";
import NavShoppingCart from "src/components/navs/NavShoppingCart.vue";

interface CourseTimeSchedule$ {
  classDay: string;
  place: string;
  classTimeS: string;
  classTimeE: string;
  signUpDateS: string;
  signUpDateE: string;
  signUpDateOnlineS: string;
  signUpDateOnlineE: string;
}

@Options({
  meta() {
    return {
      title: "課程內容",
    };
  },

  components: {
    "c-nav-shopping-cart": NavShoppingCart,
    "c-form-organization": FormOrganization,
    "c-display-field": DisplayField,
  },
})
export default class Detail extends DetailComponentBase {

  form = {
    name: "",
    classTitle: "2022年度第1梯次【線上-E1生命更新營】實現 幸福夢想",
    content: "認識教會、自我探索、生命清理、領受聖靈、預言服事、孤兒的靈、天父的心",
    teacher: "OOO，XXX",
    organizationName: "台中旌旗教會",
    classTimeS: "2022/02/20 (日) 9:00-15:00",
    classTimeE: "2022/02/20 (日) 9:00-15:00",
    timeSchedules: new Array<CourseTimeSchedule$>(),
    place: "地點：線上ZOOM",
    signUpDateS: "2022/02/01 (二) 9:00",
    signUpDateE: "2022/02/13 (六) 18:00",
    signUpDateOnlineS: "2022/02/01 (二) 9:00",
    signUpDateOnlineE: "2022/02/13 (六) 23:00",
    graduationQualification: "需全程打開鏡頭，並專注參與課程！\n" +
      "僅限缺課一堂，不予補課。\n" +
      "缺課一堂以上者，將不予頒發結業證書，下次營會需重新報名繳費。\n" +
      "遲到超過20分鐘也視同缺席一堂。",
    price: "900",
    refund: "2/13 (日) 前申請退費，酌收行政作業手續費 (報名費10%)，若線上報名者以刷退方式退費，若臨櫃或匯款報名則以匯款退費。\n" +
      "2/14 (一) 起將無法再退費亦無法保留至下屆，若遇重大事故 (需請事前告知)，請於營會後一週內完成申請，並全額退費。\n" +
      "＊重大事故為：重大傷病、交通事故等，請提供相關證明，可酌情給予全額退費 (個人活動衝突因素不在重大事故範圍)。",
    specialRequirement: "1.營會當週會以簡訊通知營會資訊，請務必注意並保留簡訊。\n" +
      "＊部分手機門號會阻擋廣告簡訊，如未收到簡訊請看本頁公告之E1行前通知、E1學員分組名單公告為主。\n" +
      "＊如您有報名，但不在分組名單中，請來電教會或留言課程客服查詢。\n" +
      "     歡迎加入旌旗客服LINE@ ID：@973uajtr\n" +
      "2.課程不能錄音 (除個人預言服事)、錄影、攝影照相。\n" +
      "3.僅限缺課一堂，不予補課 (缺課一堂以上即無法結業，不予頒發結業證書)，未結業者，下次報名須重新繳費，遲到超過20分鐘也視同缺席一堂。\n" +
      "4.線上營會課程期間請全程開啟鏡頭，如無法打開視訊鏡頭，請事先告知學員小編，如不開啟鏡頭而無法辨識您是否出席課程，將算缺席。",
  };


  get isUpdateMode() {
    return !!this.id;
  }

  get tipName() {
    return this.form.name;
  }

  get deleteKey() {
    return this.id as unknown as number;
  }

  async mounted() {
    //
  }

  gotoIndex() {
    void this.$router.push("/m/class/index");
  }
}
</script>

<style lang="scss" scoped></style>
