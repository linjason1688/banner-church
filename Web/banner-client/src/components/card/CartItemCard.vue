<template>
  <div class="row c-shopping-cart-title c-bgcolor-gray-white items-center q-px-md q-py-sm q-mb-md">
    <div class="col-12 col-md-6">
      <div class="row no-wrap items-center">
        <q-img class="c-shopping-cart-card-img q-ma-sm" :src="image"> </q-img>
        <div class="c-content-body c-text-color-100">{{ name }}</div>
      </div>
    </div>
    <div class="col-12 col-md-grow">
      <div class="row items-center">
        <div class="col-12 col-lg-auto column items-center q-my-sm">
          <div class="c-content-body c-text-color-100">{{ price }}</div>
        </div>
        <div class="col-12 col-lg-grow column items-center q-my-sm">
          <div class="c-content-body c-text-color-100" v-for="(date, index) in dateAry" :key="index">{{ date }}</div>
        </div>
      </div>
    </div>
    <div class="col-12 col-md-auto column">
      <q-btn
        outline
        rounded
        class="c-primary-color-500 q-mb-sm c-btn-bold"
        label="加入追蹤"
        icon="star_border"
        :disable="isInTracking"
        @click="addTrackingItem()"
      ></q-btn>
      <q-btn
        outline
        rounded
        class="c-primary-color-500 q-mb-sm c-btn-bold"
        label="移除項目"
        icon="remove_circle"
        @click="removeFromCart()"
      ></q-btn>
    </div>
  </div>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Emit, Prop } from "vue-property-decorator";
import { Options } from "vue-class-component";
import { addShoppingTrack, isInShoppingTrack } from "src/services/ShoppingTrack";

@Options({})
export default class CartItemCard extends ComponentBase {
  @Prop({ default: "img/class-cover.svg" })
  image!: string;

  @Prop({ default: 0 })
  courseId!: number;

  @Prop({ default: "旌旗課程" })
  name!: string;

  @Prop({ default: "NT$0" })
  price!: string;

  @Prop({ default: ["1970/01/01 (四) 00:00-24:00", "1970/01/01 (四) 00:00-24:00"] })
  dateAry!: string[];

  isInTracking = false;

  async mounted() {
    this.isInTracking = await isInShoppingTrack(this.$appStore.getters.userProfile.id, this.courseId);
  }

  async addTrackingItem() {
    this.isInTracking = true;
    try {
      await addShoppingTrack(this.$appStore.getters.userProfile.id, this.courseId);
    } catch (e) {
      this.isInTracking = false;
      this.showErrorNotify((e as Error).toString());
    }
    this.isInTracking = await isInShoppingTrack(this.$appStore.getters.userProfile.id, this.courseId);
  }

  @Emit("removeFromCart")
  removeFromCart() {
    //
  }
}
</script>
