<template>
  <q-icon
    name="arrow_circle_up"
    class="goto-top-icon"
    :style="{ visibility: show ? 'visible' : 'hidden' }"
    color="secondary"
    @click="gotoTop"
  />
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";

import { fromEvent } from "rxjs";
import { sampleTime } from "rxjs/operators";
import { ComponentBase } from "src/components";

@Options({
  components: {},
})
export default class GotoTop extends ComponentBase {
  show = false;

  mounted() {
    fromEvent(window, "scroll")
      .pipe(sampleTime(300))
      .subscribe(() => {
        this.show = window.scrollY > 100;
      });
  }

  gotoTop() {
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
  }
}
</script>

<style lang="scss" scoped>
.goto-top-icon {
  position: fixed;
  right: 5px;
  z-index: 99;
  bottom: 14px;
  right: 15px;
  font-size: 40px;
  cursor: pointer;
}
</style>
