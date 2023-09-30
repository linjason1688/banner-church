<template>
  <q-list>
    <q-item class="q-px-sm">
      <q-item-section>
        <q-item-label caption>HandledId</q-item-label>
        <q-item-label>
          {{ detail.handledId }}
        </q-item-label>
      </q-item-section>
    </q-item>
    <q-item class="q-px-sm">
      <q-item-section>
        <q-item-label caption>CreatedAt</q-item-label>
        <q-item-label>
          {{ $fmt.formatDateTime(detail.createdAt) }}
        </q-item-label>
      </q-item-section>
    </q-item>
    <q-item class="q-px-sm">
      <q-item-section>
        <q-item-label caption>Creator</q-item-label>
        <q-item-label>
          {{ detail.creator }}
        </q-item-label>
      </q-item-section>
    </q-item>
    <q-item class="q-px-sm">
      <q-item-section>
        <q-item-label caption>ModifiedAt</q-item-label>
        <q-item-label>
          {{ $fmt.formatDateTime(detail.modifiedAt) }}
        </q-item-label>
      </q-item-section>
    </q-item>
    <q-item class="q-px-sm">
      <q-item-section>
        <q-item-label caption>Modifier</q-item-label>
        <q-item-label>
          {{ detail.modifier }}
        </q-item-label>
      </q-item-section>
    </q-item>
  </q-list>
</template>

<script lang="ts">
/* eslint-disable no-unused-vars, @typescript-eslint/no-unused-vars */
import { Options } from "vue-class-component";
import { Ref, Prop, Watch, Emit } from "vue-property-decorator";
import { State, Getter, Action } from "vuex-class";

import { ComponentBase } from "src/components/ComponentBase";
/* eslint-enable */

@Options({})
export default class Detail extends ComponentBase {
  // ========== props ==========
  @Prop({ require: true })
  readonly detail!: unknown;

  // ========== vuex ==========

  // ========== data ==========

  // ========== computed ==========

  // ========== watch ==========

  // ========== refs ==========

  // ========== hook ==========
  mounted() {
    //
  }

  // ========== methods ==========

  // ========== listening ==========

  // ========== emit ==========
}
</script>
