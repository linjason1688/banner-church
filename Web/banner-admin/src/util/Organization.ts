import { OrganizationView } from "src/api/feature";

interface IdName$ {
  id: number;
  name: string;
}

export function toOrganization(organizationList: Array<OrganizationView>, id: string) {
  return organizationList.find(e => e.id.toString() == id) as IdName$;
}

export function fromOrganization(val: IdName$) {
  if (!val) return "";
  if (!val.hasOwnProperty("id")) return val.toString();
  if (val && val.id)
    return val.id.toString();
  return "";
}
