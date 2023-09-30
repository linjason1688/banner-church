<template>
  <q-page>
    <ExampleComponent />
  </q-page>
</template>

<script lang="ts">
/**
 * NOTE:
 * https://github.com/vuejs/vue-class-component/issues/406
 * https://davidjamesherzog.github.io/2020/12/30/vue-typescript-decorators/
 */

/* eslint-disable no-unused-vars, @typescript-eslint/no-unused-vars */
import { Options } from "vue-class-component";
import { Ref, Prop, Watch, Emit } from "vue-property-decorator";
import { State, Getter, Action } from "vuex-class";

import { ComponentBase } from "src/components/ComponentBase";
/* eslint-enable */

import ExampleComponent from "src/components/_Example.vue";

// TODO: https://quasar.dev/quasar-plugins/meta
@Options({
  meta() {
    return {
      title: "範例頁",
    };
  },

  components: {
    ExampleComponent,
  },
})
export default class ExamplePage extends ComponentBase {
  // ========== props ==========
  @Prop({ type: Array, default: [], required: true })
  private readonly numberArray!: Array<number>;

  // ========== vuex ==========
  @State("state.prop", { namespace: "module" })
  readonly state!: number;

  @Getter("module/getter")
  readonly getter!: string;

  @Action("module/action")
  private doAction!: unknown;

  // ========== data ==========
  list: Array<string> = [];

  // ========== computed ==========
  get $computeSth(): string {
    return "result";
  }

  // ========== watch ==========
  @Watch("list", { immediate: true, deep: true })
  detectListChange(val: Array<string>, oldVal: Array<string>) {
    console.log(val, oldVal);
  }

  // ========== refs ==========
  @Ref()
  readonly button!: HTMLButtonElement;

  // ========== hook ==========
  mounted() {
    //
  }

  // ========== methods ==========
  /**
   * 動詞＋名詞
   */
  doSth() {
    console.log("doSth");
  }

  // ========== listening ==========

  // ========== emit ==========
  /**
   * on名詞＋過去式動詞
   */
  @Emit("onSthDone")
  onSthDone(): string {
    return "data";
  }
}
</script>

<style lang="scss" scoped></style>
