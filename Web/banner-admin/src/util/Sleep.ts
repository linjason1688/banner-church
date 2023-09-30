export function Sleep(ms: number): Promise<number> {
  return new Promise((rs) => {
    setTimeout(() => {
      rs(ms);
    }, ms);
  });
}
