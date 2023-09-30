import { Vue } from "vue-class-component";

export class FormBase extends Vue {
  protected attr = {
    dense: "",
    rounded: "",
    outlined: "",
  };

  switchByRole(componentName: string, role: string) {
    switch (role) {
      case "search":
        this.attr.dense = "dense";
        this.attr.rounded = "rounded";
        break;
      case "search2":
        this.attr.dense = "dense";
        this.attr.outlined = "outlined";
        break;
      case "edit":
        break;
      case "edit2":
        this.attr.dense = "dense";
        break;
      case "signup":
        this.attr.outlined = "outlined";
        break;
      case "n":
        this.attr.dense = "dense";
        break;
      case "o":
        this.attr.dense = "dense";
        this.attr.outlined = "outlined";
        break;
      case "r":
        this.attr.dense = "dense";
        this.attr.rounded = "rounded";
        break;
      case "o-r":
        this.attr.dense = "dense";
        this.attr.outlined = "outlined";
        this.attr.rounded = "rounded";
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
