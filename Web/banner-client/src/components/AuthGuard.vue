<template>
  <div>
    <template v-if="isReady">
      <template v-if="isAuthorized">
        <slot></slot>
      </template>
      <template v-else>
        <Login />
      </template>
    </template>
    <template v-else>
      <c-landing />
    </template>
  </div>
</template>

<script lang="ts">
/* eslint-disable no-unused-vars, @typescript-eslint/no-unused-vars */
import { Options, Vue, setup } from "vue-class-component";
import { Prop, Watch, Emit } from "vue-property-decorator";
import { State, Getter, Action } from "vuex-class";

import { ComponentBase } from "src/components/ComponentBase";
import Login from "src/pages/Login.vue";
/* eslint-enable */

// interface CpnProps {
//   isReady: boolean;
//   isAuthorized: boolean;
// }

@Options({
  components: {
    Login,
  },
})
export default class AuthGuard extends Vue {
  @Prop({ default: false })
  private readonly isReady!: boolean;

  @Prop({ default: false })
  private readonly isAuthorized!: boolean;

  mounted() {
    //
  }
}
</script>

<style lang="scss" scoped></style>
