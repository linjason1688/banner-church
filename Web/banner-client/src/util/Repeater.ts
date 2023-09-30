type AsyncAction = () => Promise<void>;
// eslint-disable-next-line no-unused-vars
type ActionCallback = (count: number, time: Date) => void;

export class Repeater {
  private tmr: number | NodeJS.Timeout | undefined;
  private count = 0;

  /**
   *
   */
  constructor(
    //
    private action: AsyncAction,
    private cb: ActionCallback,
    private interval: number
  ) {
    //
    this.tmr = setInterval(() => {
      void action().then(() => {
        this.count++;
        cb(this.count, new Date());
      });
    }, interval);
  }

  dispose() {
    clearInterval(this.tmr as number);
  }
}
