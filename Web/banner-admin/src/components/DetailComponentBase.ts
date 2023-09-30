/* eslint-disable no-unused-vars, @typescript-eslint/no-unused-vars */
import { Options } from "vue-class-component";
import { Ref, Prop, Watch, Emit } from "vue-property-decorator";
import { State, Getter, Action } from "vuex-class";

import { ComponentBase } from "src/components/ComponentBase";
/* eslint-enable */

export class DetailComponentBase extends ComponentBase {
  // ========== props ==========
  /**
   * route :params props
   */
  @Prop({ type: String })
  readonly id!: string;

  // ========== data ==========

  // ========== computed ==========
  get $isUpdateMode(): boolean {
    return !!this.id;
  }

  get $isCreateMode(): boolean {
    return !this.$isUpdateMode;
  }

  get $id(): number {
    const id = Number(this.id);

    if (isNaN(id)) {
      return 0;
    } else {
      return id;
    }
  }

  // ========== watch ==========

  // ========== methods ==========
}
