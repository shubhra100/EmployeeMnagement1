import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../../core/services/employee.service';
import { Employee } from '../../models/employee.model';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { Router } from '@angular/router';
import { AuthService } from '../../core/services/auth';

@Component({
  selector: 'app-employee-list',
  imports: [CommonModule, RouterModule],
  templateUrl: './employee-list.html',
  styleUrl: './employee-list.css',
})
export class EmployeeList  implements OnInit{
  employees: Employee[] = [];
  role: string | null = '';

  constructor(
    private employeeService: EmployeeService,
    private router: Router,
    private auth: AuthService
  ) {}

  ngOnInit() {
    this.role = this.auth.getRole();
    this.loadEmployees();
  }

  loadEmployees() {
    this.employeeService.getAll().subscribe(res => {
      this.employees = res;
    });
  }

  edit(id: number) {
    this.router.navigate(['/employees/edit', id]);
  }
  delete(id: number) {
    if(confirm('Are you sure you want to delete this employee?')) {
      this.employeeService.delete(id).subscribe(() => {
        this.loadEmployees();
      });
    }
  }

}
