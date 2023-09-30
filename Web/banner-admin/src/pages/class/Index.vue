<template>
  <div>
    <div class="row">
      <div class="col">
        <q-carousel
          v-model="slide"
          animated
          arrows
          navigation
          infinite
          height="287px">
          <template v-slot:navigation-icon="{ active, btnProps, onClick }">
            <q-btn v-if="active" size="lg" icon="home" color="yellow" flat round dense @click="onClick" />
            <q-btn v-else size="sm" :icon="btnProps.icon" color="white" flat round dense @click="onClick" />
          </template>

          <q-carousel-slide name="style" img-src="img/class_logo.svg" />
          <q-carousel-slide name="tv" img-src="img/class_logo.svg" />
          <q-carousel-slide name="layers" img-src="img/class_logo.svg" />
          <q-carousel-slide name="map" img-src="img/class_logo.svg" />

        </q-carousel>
      </div>
    </div>

    <div class="row">
      <div class="col-4 c-content-subtitle c-gray-800">
        個人所在堂點：台中旌旗教會分堂
      </div>
      <div class="col-8">
        <span class="c-primary-color-500">追蹤清單</span>
        <span>購物車</span>
        <span>訂單管理</span>
      </div>
    </div>

    <div class="row">
      <div class="col-6 c-heading-h1 c-primary-color-400">生活樂趣百百種 <br>
        樂活體驗課程隨你選
      </div>
      <div class="col-6">
        <div class="row">
          <c-input place-holder="我想學習"></c-input>
          <c-btn-search></c-btn-search>
        </div>
        <div class="row">
          <span>生命更新營</span>
          <span>門徒建造營</span>
          <span>基督精兵營</span>
          <c-btn-search></c-btn-search>
        </div>
      </div>
    </div>

    <!--經典課程-->
    <div class="row">
      <div class="col">
        <div class="row window-width">
          <div class="col-8 c-heading-h2 c-primary-color-400">經典課程</div>
          <div class="col-4 c-content-body">更多經典課程 ——</div>
        </div>
        <q-carousel
          v-model="slide"
          animated
          arrows
          navigation
          infinite
          height="287px">
          <template v-slot:navigation-icon="{ active, btnProps, onClick }">
            <q-btn v-if="active" size="lg" icon="home" color="yellow" flat round dense @click="onClick" />
            <q-btn v-else size="sm" :icon="btnProps.icon" color="white" flat round dense @click="onClick" />
          </template>

          <q-carousel-slide name="style" img-src="img/class_logo.svg" />
          <q-carousel-slide name="tv" img-src="img/class_logo.svg" />
          <q-carousel-slide name="layers" img-src="img/class_logo.svg" />
          <q-carousel-slide name="map" img-src="img/class_logo.svg" />

        </q-carousel>
      </div>
    </div>

    <div class="row">
      <div class="col">
        <div class="row">
          <div class="col c-heading-h2 c-primary-color-400">最新課程</div>
          <div class="col c-content-body">更多最新課程</div>
        </div>
        <q-carousel
          v-model="slide"
          animated
          arrows
          navigation
          infinite
          height="287px">
          <template v-slot:navigation-icon="{ active, btnProps, onClick }">
            <q-btn v-if="active" size="lg" icon="home" color="yellow" flat round dense @click="onClick" />
            <q-btn v-else size="sm" :icon="btnProps.icon" color="white" flat round dense @click="onClick" />
          </template>

          <q-carousel-slide name="style" img-src="img/class_logo.svg" />
          <q-carousel-slide name="tv" img-src="img/class_logo.svg" />
          <q-carousel-slide name="layers" img-src="img/class_logo.svg" />
          <q-carousel-slide name="map" img-src="img/class_logo.svg" />

        </q-carousel>
      </div>
    </div>

    <div class="row">
      <div class="col">
        <div class="row">
          <div class="col c-heading-h2 c-primary-color-400">即將結束報名課程</div>
          <div class="col c-content-body">更多即將結束報名課程 ——</div>
        </div>

        <q-carousel
          v-model="slide"
          animated
          arrows
          navigation
          infinite
          height="287px">
          <template v-slot:navigation-icon="{ active, btnProps, onClick }">
            <q-btn v-if="active" size="lg" icon="home" color="yellow" flat round dense @click="onClick" />
            <q-btn v-else size="sm" :icon="btnProps.icon" color="white" flat round dense @click="onClick" />
          </template>

          <q-carousel-slide name="style" img-src="img/class_logo.svg" />
          <q-carousel-slide name="tv" img-src="img/class_logo.svg" />
          <q-carousel-slide name="layers" img-src="img/class_logo.svg" />
          <q-carousel-slide name="map" img-src="img/class_logo.svg" />

        </q-carousel>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { ref } from "vue";

export default class Index extends ComponentBase {

  slide = ref("style");

  async mounted() {
    //
  }

}
</script>

<style lang="scss" scoped>
@import '../../css/quasar.variables.scss';

</style>
