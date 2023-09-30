import { Vue } from "vue-class-component";

export class FormBase extends Vue {
  protected attr = {
    behavior: "",
    dense: "",
    outlined: "",
    rounded: "",
  };

  switchByRole(componentName: string, role: string) {
    switch (role) {
      case "search":
        this.attr.behavior = "";
        this.attr.dense = "dense";
        this.attr.outlined = "";
        this.attr.rounded = "rounded";
        break;
      case "search2":
        this.attr.behavior = "menu";
        this.attr.dense = "dense";
        this.attr.outlined = "outlined";
        this.attr.rounded = "";
        break;
      case "search3":
        this.attr.behavior = "";
        this.attr.dense = "dense";
        this.attr.outlined = "";
        this.attr.rounded = "";
        break;
      case "edit":
        break;

      default:
        break;
    }

    switch (componentName) {
      case "FormInput":
        break;
      case "FormSelect":
        break;

      default:
        break;
    }
  }
}
