import { UserProfile as ApiUserProfile } from "src/api/feature";

export interface UserProfile extends ApiUserProfile {
  id: number;
  name: string;
  employeeId: string;
  employeeDeptId?: string;
  roleIdList?: string[];
  jwt: string;
}
