interface NameValue$ {
  value: string;
  name: string;
}

export function convertSystemConfig(e: Array<NameValue$>, name: string) : string | null {
  const found = e.find(e1 => e1.name == name);
  if (found) return found.value;
  return "";
}
