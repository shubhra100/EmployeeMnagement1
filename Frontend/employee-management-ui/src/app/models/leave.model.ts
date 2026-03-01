export interface LeaveRequest {
  id: number;
  employeeId: number;
  startDate: string;   // ISO Date format from API
  endDate: string;
  reason: string;
  status: string;      // 'Pending' | 'Approved' | 'Rejected'
  appliedOn?: string;  // optional (if backend returns it)
}