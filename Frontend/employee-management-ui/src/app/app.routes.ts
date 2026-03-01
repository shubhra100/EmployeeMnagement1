import { Routes } from '@angular/router';
import { Login } from './auth/login/login';
import { Layout } from './layout/layout';
import { AdminDashboard } from './dashboard/admin-dashboard/admin-dashboard';
import { HrDashboard } from './dashboard/hr-dashboard/hr-dashboard';
import { EmployeeDashboard } from './dashboard/employee-dashboard/employee-dashboard';
import { EmployeeList } from './employees/employee-list/employee-list';
import { EmployeeForm } from './employees/employee-form/employee-form';

import { ApplyLeaveComponent } from './leave/apply-leave/apply-leave';
import { LeaveListComponent } from './leave/leave-list/leave-list';

import { AttendanceComponent } from './attendance/attendance';

import { authGuard } from './core/guards/auth-guard';

export const routes: Routes = [

  // Public Route
  { path: 'login', component: Login },

  // Protected Layout Wrapper
  {
    path: '',
    component: Layout,
    canActivate: [authGuard],
    children: [

      // Employee
      {
        path: 'employees',
        component: EmployeeList,
        data: { roles: ['Admin','HR'] }
      },
      {
        path: 'employees/add',
        component: EmployeeForm,
        data: { roles: ['HR'] }
      },
      {
        path: 'employees/edit/:id',
        component: EmployeeForm,
        data: { roles: ['HR'] }
      },
      { path: 'employee-dashboard', component: EmployeeDashboard },
      { path: 'hr-dashboard', component: HrDashboard },
      { path: 'admin-dashboard', component: AdminDashboard },
      // Leave
      {
        path: 'leave/apply',
        component: ApplyLeaveComponent,
        data: { roles: ['Employee'] }
      },
      {
        path: 'leave/list',
        component: LeaveListComponent,
        data: { roles: ['HR'] }
      },

      // Attendance
      {
        path: 'attendance',
        component: AttendanceComponent,
        data: { roles: ['Admin','HR','Employee'] }
      }

    ]
  },

  { path: '', redirectTo: 'login', pathMatch: 'full' }
];