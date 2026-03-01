
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-employee-dashboard',
  templateUrl: './employee-dashboard.html',
  styleUrls: ['./employee-dashboard.css']
})
export class EmployeeDashboard {

  constructor(private router: Router) {}

  applyLeave() {
    this.router.navigate(['/leave/apply']);
  }

  markAttendance() {
    this.router.navigate(['/attendance']);
  }

  logout() {
    localStorage.clear();
    this.router.navigate(['/login']);
  }
}