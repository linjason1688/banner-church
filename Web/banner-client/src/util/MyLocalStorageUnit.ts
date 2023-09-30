export class MyLocalStorageUnit<T> {
  private key: string;
  /**
   *
   */
  constructor(key: string) {
    this.key = key;
  }

  getItem(): T | undefined {
    const value = localStorage.getItem(this.key);

    if (!value) {
      return undefined;
    }

    try {
      return JSON.parse(value) as T;
    } catch (error) {
      return;
    }
  }

  setItem(data: T): void {
    localStorage.setItem(this.key, JSON.stringify(data));
  }
}
