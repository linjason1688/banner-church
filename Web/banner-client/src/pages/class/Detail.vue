<template>
  <div class="c-background-content">
    <div class="row justify-center c-background-content">
      <div class="col-12 col-sm-10 q-pa-md">
        <c-nav-shopping-cart title="課程內容" />
      </div>
    </div>
    <div class="row justify-center c-background-primary">
      <div class="col-12 col-sm-10 q-pa-md">
        <div class="row">
          <div class="col-12 q-px-md">
            <q-img class="q-mb-md" :src="courseInfo.imgPath" alt="" style="max-width: 100%; height: 300px" fit="fill" />
          </div>
        </div>
        <div class="q-mx-md q-mb-md" style="border-bottom: 1px solid #d2d3d4"></div>

        <!--    內容-->
        <div class="row">
          <div class="col-12 col-md-8 q-pa-md">
            <div class="q-mb-lg c-heading-h3">{{ courseInfo.courseManagementTitle }}</div>
            <c-section-title title="課程簡介" icon="summarize"></c-section-title>
            <c-shadow-card>
              <c-display-field label="課程內容">
                {{ courseInfo.courseContext }}
              </c-display-field>
              <c-display-field label="課程講師">
                {{ courseInfo.teacher }}
              </c-display-field>
              <c-display-field label="開課堂點">
                {{ courseInfo.organizationName }}
              </c-display-field>
              <c-display-field label="課程日期與地點">
                <div class="c-content-body">
                  <div v-for="item in courseInfo.courseTimeSchedules" :key="item.id" class="q-mb-sm">
                    日期：{{ convertWeekday(item.classDay) }} {{ item.classTimeS }} ~ {{ item.classTimeE }}
                    <br />
                    地點：{{ item.place }}
                  </div>
                </div>
              </c-display-field>
            </c-shadow-card>

            <c-section-title title="報名資訊" icon="sticky_note_2"></c-section-title>
            <c-shadow-card>
              <c-display-field label="報名日期">
                <div v-if="courseInfo.counterSignUpDateS || courseInfo.counterSignUpDateE">
                  臨櫃：{{ convertDateTime(courseInfo.counterSignUpDateS) }} ~
                  {{ convertDateTime(courseInfo.counterSignUpDateE) }}
                </div>
                <div v-if="courseInfo.signUpDateS || courseInfo.signUpDateE">
                  線上：{{ convertDateTime(courseInfo.signUpDateS) }} ~ {{ convertDateTime(courseInfo.signUpDateE) }}
                </div>
              </c-display-field>
              <c-display-field label="報名名額">
                {{ courseInfo.quota }}
              </c-display-field>
              <c-display-field label="報名資格">
                {{ courseInfo.description }}
              </c-display-field>
              <c-display-field label="報名費用">
                <div v-for="(item, index) in courseInfo.coursePrices" :key="index">
                  {{ item.priceName }} - NT${{ item.price }}
                </div>
              </c-display-field>
            </c-shadow-card>

            <c-section-title title="其他應注意事項" icon="find_in_page"></c-section-title>
            <div class="q-mb-md" style="border-bottom: 1px solid #d2d3d4"></div>
            <q-card flat bordered class="q-pa-xl q-py-lg q-mb-lg c-background-form">
              <c-display-field label="結業標準">
                {{ courseInfo.graduationQualification }}
              </c-display-field>
              <c-display-field label="退費原則">
                {{ courseInfo.refund }}
              </c-display-field>
              <c-display-field label="注意事項">
                {{ courseInfo.specialRequirement }}
              </c-display-field>
            </q-card>
            <c-section-title title="表單下載" icon="download"></c-section-title>
            <div class="q-mb-md" style="border-bottom: 1px solid #d2d3d4"></div>
            <div class="q-px-xl">
              <div class="row">
                <div class="col-auto" v-for="(map, index) in courseInfo.documentLink" :key="index">
                  <a
                    class="c-heading-h5 c-primary-color-500 c-hyperlink-text q-mx-md q-mb-md"
                    :href="map.value"
                    target="_blank"
                    >{{ map.key }}</a
                  >
                </div>
              </div>
            </div>
          </div>
          <div class="col-12 col-md-4">
            <div class="row justify-around justify-md-end q-py-md column-md items-end">
              <div class="col-12 col-sm-auto q-px-md q-px-md">
                <c-titled-card title="對此課程">
                  <c-btn
                    label="立即報名"
                    rounded
                    unelevated
                    class="c-btn-bold c-primary-background-500 c-gray-white q-ma-sm"
                    icon="pan_tool_alt"
                    @click="checkSingleCourse()"
                  ></c-btn>
                </c-titled-card>
              </div>
              <div class="col-12 col-sm-auto q-px-md q-px-md">
                <c-titled-card title="或是選擇">
                  <c-btn
                    label="加入追踨"
                    :disabled="isInTracking"
                    rounded
                    flat
                    class="c-btn-bold c-primary-color-500 c-bgcolor-gray-white q-ma-sm"
                    icon="star_outline"
                    @click="addTrackingItem"
                  ></c-btn>
                  <c-btn
                    label="放入購物車"
                    :disabled="isInShoppingCart"
                    rounded
                    flat
                    class="c-btn-bold c-primary-color-500 c-bgcolor-gray-white q-ma-sm"
                    icon="shopping_cart"
                    @click="addShoppingCartItem()"
                  ></c-btn>
                </c-titled-card>
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
import SectionTitle from "pages/class/_SectionTitle.vue";
import DisplayField from "pages/shopping-cart/_DisplayField.vue";
import { addShoppingCart, isInShoppingCart } from "src/util";
import { addShoppingTrack, isInShoppingTrack } from "src/services/ShoppingTrack";
import NavShoppingCart from "components/navs/NavShoppingCart.vue";
import {CourseTimeScheduleView, CourseView, QueryCourseManagementFilterUserRequest} from "src/api/feature";
import { FileRootUrl } from "src/data/constants/ApiEnums";
import {convertWeekDay} from "src/services";

class Map {
  key: string = "";
  value: string = "";
}

interface CourseInfo extends CourseView {
  imgPath?: string; //課程圖片
  teacher?: string; //課程教師
  organizationName?: string; //開課堂點名稱
  documentLink?: Array<Map>; //表單下載連結
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
    "c-section-title": SectionTitle,
  },
})
export default class Detail extends DetailComponentBase {
  isInShoppingCart = false;
  isInTracking = false;

  get isUpdateMode() {
    return !!this.id;
  }

  get tipName() {
    return this.courseInfo.name;
  }

  get deleteKey() {
    return this.id as unknown as number;
  }

  async mounted() {
    this.isInShoppingCart = await isInShoppingCart(this.$appStore.getters.userProfile.id, this.deleteKey);
    this.isInTracking = await isInShoppingTrack(this.$appStore.getters.userProfile.id, this.deleteKey);
    await this.queryAsync();
    this.fakeLink();
  }

  fakeLink() {
    this.courseInfo.documentLink = [
      {
        key: "行前通知1",
        value: "someURLPath",
      },
      {
        key: "行前通知2",
        value: "someURLPath",
      },
      {
        key: "重大事故退費申請表",
        value: "someURLPath",
      },
    ] as Array<Map>;
  }

  gotoIndex() {
    this.$router.back();
  }

  async checkSingleCourse() {
    await addShoppingCart(this.$appStore.getters.userProfile.id, this.deleteKey)
      .then(() => {
        this.isInShoppingCart = true;
        void this.$router.push({
          path: "/m/shopping-cart/check",
          query: {
            organizationId: this.courseInfo.organizationId,
            courseId: this.deleteKey,
          },
        });
      })
      .catch((e) => {
        this.showErrorNotify((e as Error).toString());
      });
  }

  async addShoppingCartItem() {
    this.isInShoppingCart = true;
    try {
      await addShoppingCart(this.$appStore.getters.userProfile.id, this.deleteKey);
    } catch (e) {
      this.isInShoppingCart = false;
      this.showErrorNotify((e as Error).toString());
    }
  }

  async addTrackingItem() {
    this.isInTracking = true;
    try {
      await addShoppingTrack(this.$appStore.getters.userProfile.id, this.deleteKey);
    } catch (e) {
      this.isInTracking = false;
      this.showErrorNotify((e as Error).toString());
    }
  }

  courseInfo = {} as CourseInfo;

  async queryAsync() {
    // var idNum: number = 1;
    // var idNum: number = 10;
    const idNum: number = +this.id;

    this.courseInfo = (await this.apis.feature.course.getCourse(idNum)).data;
    if (this.courseInfo.courseAppendices.length > 0) {
      for (let appendices of this.courseInfo.courseAppendices) {
        if (appendices.appendixType == "2") {
          this.courseInfo.imgPath = FileRootUrl + "/" + appendices.path;
        }
      }
    }

    //get teacher info and concatenate as string
    this.courseInfo.teacher = await this.queryTeacherAsync();

    //get organization info
    if (this.courseInfo.organizationId > 0) {
      const organizationInfo = (await this.apis.feature.organization.getOrganization(this.courseInfo.organizationId))
        .data;

      this.courseInfo.organizationName = organizationInfo.name;
    }
  }

  async queryTeacherAsync() {
    if (this.courseInfo.courseManagementFilterId === 0) {
      return "";
    }

    let teachers = Array<string>();
    await this.apis.feature.courseManagementFilterUser.queryCourseManagementFilterUsers({
      courseManagementFilterId: this.courseInfo.courseManagementFilterId,
      size: 1000} as QueryCourseManagementFilterUserRequest)
      .then(async e => {
        for (let filter of e.data.records) {
          await this.apis.feature.user.getUser(filter.userId)
            .then(u => { teachers.push(u.data.name) })
        }
      })
    return teachers.join(",");
  }

  convertDateTime(dateTime: string) {
    let dt = new Date(dateTime);
    return (
      new Intl.DateTimeFormat("zh-TW").format(dt) +
      " (" +
      new Intl.DateTimeFormat("zh-TW", { weekday: "narrow" }).format(dt) +
      ") " +
      new Intl.DateTimeFormat("zh-TW", { hour: "numeric", minute: "numeric" }).format(dt)
    );
  }

  convertWeekday(id: string) {
    return convertWeekDay(id);
  }
}
</script>

<style lang="scss" scoped></style>
