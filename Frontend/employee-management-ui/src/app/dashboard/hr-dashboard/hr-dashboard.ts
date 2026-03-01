
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-hr-dashboard',
  templateUrl: './hr-dashboard.html',
  styleUrls: ['./hr-dashboard.css']
})
export class HrDashboard {

  constructor(private router: Router) {}

  goToEmployees() {
    this.router.navigate(['/employees']);
  }

  goToLeaveRequests() {
    this.router.navigate(['/leave/list']);
  }

  logout() {
    localStorage.clear();
    this.router.navigate(['/login']);
  }
}