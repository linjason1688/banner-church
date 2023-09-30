<template>
  <q-card class="c-class-card cursor-pointer" @click="onClickClassBtn">
    <q-img class="c-class-card-img" :src="classImg">
      <div class="c-class-card-action">
        <q-btn
          round
          size="sm"
          :icon="starIcon"
          class="bg-white text-amber-5 q-mr-sm"
          style="border-radius: 0 0 8px 8px;"
          @click.stop="onClickStarBtn"
        >
          <q-tooltip anchor="top middle" self="bottom middle">加入追蹤</q-tooltip>
        </q-btn>
        <q-btn
          round
          size="sm"
          icon="shopping_cart"
          class="bg-white text-amber-5 q-mr-sm"
          style="border-radius: 0 0 8px 8px;"
          @click.stop="onClickPurchaseBtn"
        >
          <q-tooltip anchor="top middle" self="bottom middle">加入購物車</q-tooltip>
        </q-btn>
      </div>
    </q-img>
    <q-card-section>
      <div class="row q-mb-sm items-center">
        <div class="col-grow column items-start">
          <div class="c-class-card-title">{{ classTitle }}</div>
        </div>
        <div class="col-auto">
          <q-chip class="text-grey-7" square dense>{{ joinType }}</q-chip>
        </div>
      </div>
      <div class="row q-mb-sm items-center q-gutter-xs">
        <div v-if="earlybird != undefined" class="c-class-card-earlybird c-primary-color-400">{{ earlybird }}</div>
        <div v-if="earlybird != undefined" class="c-class-card-originalprice">{{ originalprice }}</div>
        <div v-if="earlybird == undefined" class="c-class-card-originalprice1">{{ originalprice }}</div>
      </div>
      <div class="row q-mb-sm items-center q-gutter-xs">
        <q-icon name="calendar_today" />
        <div class="c-content-cation">{{ classDate }}</div>
      </div>
      <div class="row q-mb-sm items-center q-gutter-xs">
        <q-icon name="people" />
        <div class="c-content-cation">{{ participator }}</div>
      </div>
    </q-card-section>
  </q-card>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { Emit, Prop } from "vue-property-decorator";
import { CardBase } from "./CardBase";

@Options({})
export default class ClassCard extends CardBase {
  actionBtnClass = "c-class-card-action-btn";
  activeClass = "c-class-card-action-btn__active";

  @Prop({ default: "img/class_logo.svg" })
  classImg!: string;

  @Prop({ default: "精彩活動" })
  classTitle!: string;

  @Prop({ default: "實體營會" })
  joinType!: string;

  @Prop({ default: "早鳥價 NT$0" })
  earlybird!: string;

  @Prop({ default: "原價 NT$0" })
  originalprice!: string;

  @Prop({ default: "1970/01/01 - 2070/01/01" })
  classDate!: string;

  @Prop({ default: "一般會友(限18歲以上成人)、無小組者" })
  participator!: string;

  @Prop({ default: false })
  isTracking!: boolean;

  @Prop({ default: false })
  isInShoppingCart!: boolean;

  @Emit("onClickStarBtn")
  onClickStarBtn() {
    return true;
  }

  @Emit("onClickPurchaseBtn")
  onClickPurchaseBtn() {
    return true;
  }

  @Emit("onClickClassBtn")
  onClickClassBtn() {
    return true;
  }

  get starIcon() {
    return this.isTracking ? "star" : "star_outline";
  }

  created() {
    //
  }
}
</script>
