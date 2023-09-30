<template>
  <q-form @submit="save()" class="q-gutter-y-md">
    <c-sub-title title="家庭狀況"></c-sub-title>
    <c-row>
      <div class="col-12 col-sm-5">
        <c-form-card>
          <c-column label="父親">
            <c-input v-model="form.fatherName"></c-input>
          </c-column>
          <c-column label="母親">
            <c-input v-model="form.motherName"></c-input>
          </c-column>
        </c-form-card>
        <c-form-card>
          <c-column label="配偶姓名" required>
            <c-input v-model="form.spouseName" :rules="[(val: any) => !!val || '請輸入配偶姓名']"></c-input>
          </c-column>
          <c-column label="配偶手機" required>
            <template v-slot:prepend>
              <q-select emit-value map-options size :options="countryCodeList" v-model="form.cellAreaCode1"
                option-value="name" :option-label="(opt) => (opt === '' ? '區碼' : '+' + opt.name + ' ' + opt.value)"
                :rules="[(val) => !!val || '請輸入區碼']" outlined lazy-rules />
            </template>
            <c-input v-model="form.cellPhone" :rules="[(val: any) => !!val || '請輸入配偶手機']"></c-input>
          </c-column>
        </c-form-card>
      </div>
      <div class="col-12 col-sm-7">
        <c-form-card>
          <div class="flex q-mb-md justify-end">
            <q-btn icon="person_add_alt" color="indigo" flat @click="addContact()">新增緊急聯絡人</q-btn>
          </div>
          <div v-for="item in form.contacts" :key="item.id">
            <c-form-group-emergency v-model:name.sync="item.name" v-model:relative.sync="item.relative"
              v-model:phone.sync="item.phone" />
          </div>
        </c-form-card>
        <c-form-card>
          <div class="flex q-mb-md justify-end">
            <q-btn icon="person_add_alt" color="indigo" flat @click="addChild()">新增兒童名稱</q-btn>
          </div>
          <c-row v-for="child in form.children" :key="child.id">
            <c-column label="兒童姓名" class="col-12 col-sm-5">
              <q-input v-model="child.name" dense />
            </c-column>
            <c-column label="兒童帳號" class="col-12 col-sm-4">
              <q-input v-model="child.memo" dense />
            </c-column>
            <c-column class="col text-right">
              <q-btn color="indigo" label="編輯帳號" no-wrap rounded @click="updateChild(child.memo)" />
            </c-column>
          </c-row>
        </c-form-card>
      </div>
    </c-row>
    <c-savecancel-group class="app-savecancel-group-fixed" @save="save()" @cancel="cancel()" />
  </q-form>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Prop } from "vue-property-decorator";
import { Options } from "vue-class-component";
import SubTitle from "components/SubTitle.vue";
import { CreateUserContactCommand, CreateUserFamilyCommand, SignUpCommand } from "src/api/feature";
import { number, RelativeType, SystemConfig } from "src/util";
import { SystemConfigState } from "src/data/dto/SystemConfigState";
import { is } from "dom7";
import { throwIfEmpty } from "rxjs";
import { Rule } from "webpack-chain";

interface Contact$ {
  id: string;
  name: string;
  relative: string;
  phone: string;
}

interface Child$ {
  id: string;
  name: string;
  memo: string;
}

@Options({
  components: {
    "c-sub-title": SubTitle,
  },
})
export default class Family extends ComponentBase {
  text = "";
  form = {
    contacts: new Array<Contact$>(),
    children: new Array<Child$>(),
    motherName: "",
    fatherName: "",
    spouseName: "",
    parentSpouseName: "",
    cellAreaCode1: "",
    cellPhone: "",
    isMarried: "",
    parentUserId: 0,
    genderType: ""
  };
  get countryCodeList() {
    return this.$appStore.getters.getSystemConfig(SystemConfig.CountryCode);
  }

  @Prop({ type: String })
  title!: string;

  async mounted() {
    let userId = this.$appStore.getters.userProfile.id;
    let userResp = await this.apis.feature.user.getUser(userId);
    let user = userResp.data;
    this.form = Object.assign(this.form, userResp.data);
    for (let i = 0; i < user.userFamilies.length; i++) {
      let family = user.userFamilies[i];
      if (family.relativeType === RelativeType.Father.toString()) {
        this.form.fatherName = family.name;
      }
      if (family.relativeType === RelativeType.Mother.toString()) {
        this.form.motherName = family.name;
      }
      if (family.relativeType === RelativeType.Spouse.toString()) {
        this.form.spouseName = family.name;
      }

      if (this.form.parentUserId != null) {
        await this.apis.feature.user.getUser(this.form.parentUserId)
          .then(user => {
            if (user.data.genderType.toString() == "0") {
              this.form.motherName = this.form.parentSpouseName;
            }
            else if (user.data.genderType.toString() == "1") {
              this.form.fatherName = this.form.parentSpouseName;
            }
          });
      }
    }

    user.userFamilies.forEach((e) => {
      if (e.relativeType === RelativeType.Child.toString()) {
        this.form.children.push({
          id: e.id.toString(),
          name: e.name,
          memo: e.memo,
        });
      }
    });

    user.userContacts.forEach((e) => {
      this.form.contacts.push({
        id: e.id.toString(),
        name: e.name,
        relative: e.relative,
        phone: e.phone,
      });
    });
    if (this.form.isMarried === "0") {
      this.form.spouseName = "";
      this.form.cellPhone = "";
      this.form.children = [];
    }
  }

  async saveState() {
    let userId = this.$appStore.getters.userProfile.id;
    let userResp = await this.apis.feature.user.getUser(userId);
    let user = userResp.data;

    let request = Object.assign({} as SignUpCommand, user, this.form);

    request.userFamilies = Array<CreateUserFamilyCommand>();
    if (this.form.fatherName) {
      request.userFamilies.push(
        Object.assign({
          name: this.form.fatherName,
          relativeType: RelativeType.Father,
        } as unknown as CreateUserFamilyCommand)
      );
    }

    if (this.form.motherName) {
      request.userFamilies.push(
        Object.assign({
          name: this.form.motherName,
          relativeType: RelativeType.Mother,
        } as unknown as CreateUserFamilyCommand)
      );
    }

    if (this.form.spouseName) {
      request.userFamilies.push(
        Object.assign({
          name: this.form.spouseName,
          relativeType: RelativeType.Spouse,
        } as unknown as CreateUserFamilyCommand)
      );
    }

    request.userContacts = Array<CreateUserContactCommand>();
    for (let i = 0; i < this.form.contacts.length; i++) {
      let c = this.form.contacts[i];
      if (c.relative && c.name) {
        request.userContacts.push(
          Object.assign({
            name: c.name,
            relative: c.relative,
            phone: c.phone,
          } as CreateUserContactCommand)
        );
      }
    }

    for (let i = 0; i < this.form.children.length; i++) {
      let c = this.form.children[i];
      if (c.memo) {
        request.userFamilies.push(
          Object.assign({
            name: c.name,
            memo: c.memo,
            relativeType: RelativeType.Child,
          } as unknown as CreateUserFamilyCommand)
        );
      }
    }
    await this.apis.feature.user.updateMember(userId, request);
  }

  async save() {
    if (this.form.spouseName && this.form.cellPhone && this.form.cellAreaCode1) {
      await this.saveState();
      this.showSuccessNotify("保存成功");
    } else {
      this.showErrorNotify("未填寫完整資訊");
    }
  }

  addContact() {
    this.form.contacts.push({
      id: "",
      name: "",
      relative: "",
      phone: "",
    });
  }

  addChild() {
    this.form.children.push({
      id: "",
      name: "",
      memo: "",
    });
  }

  async updateChild(account: string) {
    await this.saveState();
    void this.$router.push("/child/profile?account=" + account);
  }

  cancel() {
    console.log("onClickCancel");
  }
}
</script>

<style lang="scss" scoped>
@import "../../css/quasar.variables";

.family-lab {
  width: 290px;
}
</style>
