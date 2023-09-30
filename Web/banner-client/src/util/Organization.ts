interface IdName$ {
  id: number;
  name: string;
}

export function toOrganization(organizationList: Array<IdName$>, id: string) {
  return organizationList.find(e => e.id.toString() == id) as IdName$;
}

export function fromOrganization(val: IdName$) {
  if (!val.hasOwnProperty("id")) return val.toString();
  if (val && val.id)
    return val.id.toString();
  return "";
}

export function convertOrganization(organizationList: Array<IdName$>, id: string) {
  const found = toOrganization(organizationList, id);
  if (found) return found.name;
  return "";
}
