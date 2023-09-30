<template>
  <div>
    <c-sub-title title="多元表現" />
    <c-row>
      <div class="col-12 col-sm-6">
        <c-form-card>
          <div class="text-right">
            <q-btn class="q-mb-md text-h6 text-right" icon="add" flat color="indigo"
              @click="addUserExpertises">新增專長</q-btn>
          </div>
          <div v-for="field in form.userExpertises" :key="field.id">
            <p class="q-px-md q-ma-none c-content-body">專長{{ field.label }}</p>
            <c-input-gutter role="edit2" v-model="field.name">
              <template v-slot:after>
                <q-btn round dense flat color="red-9" icon="delete" @click="deleteExpertise(field.id)" />
              </template>
            </c-input-gutter>
          </div>
        </c-form-card>
      </div>
      <div class="col-12 col-sm-6">
        <c-form-card>
          <div class="text-right">
            <q-btn class="q-mb-md text-h6" icon="add" flat color="indigo" @click="addUserSociety">新增外部社團 / 工會</q-btn>
          </div>
          <div v-for="field in form.userSocieties" :key="field.id">
            <p class="q-px-md q-ma-none c-content-body">外部社團 / 工會{{ field.label }}</p>
            <c-input-gutter role="edit2" v-model="field.name">
              <template v-slot:after>
                <q-btn round dense flat color="red-9" icon="delete" @click="deleteSociety(field.id)" />
              </template>
            </c-input-gutter>
          </div>
        </c-form-card>
      </div>
    </c-row>
    <c-savecancel-group class="app-savecancel-group-fixed" @save="save()" @cancel="cancel()" />
  </div>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Options } from "vue-class-component";
import { Prop } from "vue-property-decorator";
import SubTitle from "components/SubTitle.vue";

interface FormField {
  id: number;
  label: number;
  name: string;
}

@Options({
  components: {
    "c-sub-title": SubTitle,
  },
})

export default class Other extends ComponentBase {

  @Prop({ type: String })
  title!: string;

  form = {
    userExpertises: new Array<FormField>(),
    userSocieties: new Array<FormField>(),
  }

  async mounted() {
    let userId = this.$appStore.getters.userProfile.id;
    let userResp = await this.apis.feature.user.getUser(userId);

    for (let i = 0; i < userResp.data.userExpertises.length; i++) {
      const e = userResp.data.userExpertises[i];
      this.form.userExpertises.push({
        id: e.id,
        label: i + 1,
        name: e.name,
      });
    }
    for (let i = 0; i < userResp.data.userSocieties.length; i++) {
      const e = userResp.data.userSocieties[i];
      this.form.userSocieties.push({
        id: e.id,
        label: i + 1,
        name: e.name,
      });
    }
  }

  async save() {
    let userId = this.$appStore.getters.userProfile.id;
    let userResp = await this.apis.feature.user.getUser(userId);

    let form = Object.assign({ ...this.$appStore.getters.signUpState }, userResp.data, this.form);
    await this.apis.feature.user.updateMember(this.$appStore.getters.userProfile.id, form);
    this.showSuccessNotify("保存成功");
  }

  cancel() {
    console.log("onClickCancel");
  }

  addUserExpertises() {
    this.form.userExpertises.push({
      id: this.form.userExpertises.length,
      label: this.form.userExpertises.length + 1,
      name: "",
    })
  }

  deleteExpertise(id: number) {
    this.form.userExpertises = this.form.userExpertises.filter(e => {
      return e.id !== id;
    });
  }

  addUserSociety() {
    this.form.userSocieties.push({
      id: this.form.userSocieties.length,
      label: this.form.userSocieties.length + 1,
      name: "",
    })
  }

  deleteSociety(id: number) {
    this.form.userSocieties = this.form.userSocieties.filter(e => {
      return e.id !== id;
    });
  }
}
</script>

<style lang="scss" scoped>
@import '../../css/quasar.variables.scss';
</style>
