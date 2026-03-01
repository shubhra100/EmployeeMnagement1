export interface Attendance {
  id: number;
  employeeId: number;
  date: string;
  status: string;   // Present / Absent
}