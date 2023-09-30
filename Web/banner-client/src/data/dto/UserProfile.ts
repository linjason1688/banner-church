// TODO: adjust api dto
interface ApiUserProfile {
  //
  email: string;
  account: string;
}

export interface UserProfile extends ApiUserProfile {
  id: number;
  name: string;
  employeeId: string;
  employeeDeptId?: string;
  roleIdList?: string[];
  jwt: string;
}
