
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.html',
  styleUrls: ['./admin-dashboard.css']
})
export class AdminDashboard {

  role = localStorage.getItem('role');

  constructor(private router: Router) {}

  goToEmployees() {
    this.router.navigate(['/employees']);
  }

  goToAttendance() {
    this.router.navigate(['/attendance']);
  }

  logout() {
    localStorage.clear();
    this.router.navigate(['/login']);
  }
}