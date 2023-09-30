export class SelectOption<T> {
  value: T;
  private _text: string = "";
  public get text(): string {
    return this._text;
  }
  public set text(value: string) {
    this._text = value;
  }

  constructor(value: T) {
    this.value = value;
  }
}

// types inherit from api DTO

// export interface AdminOption extends ExampleItem {
//   value: string;
//   text: string;
//   description: string;
// }
