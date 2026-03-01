import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AttendanceService } from '../core/services/attendance';
import { Attendance } from '../models/attendance.model';

@Component({
  selector: 'app-attendance',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './attendance.html'
})
export class AttendanceComponent implements OnInit {

  attendanceList: Attendance[] = [];
  employeeId!: number;

  constructor(private attendanceService: AttendanceService) {}

  ngOnInit(): void {
    this.loadAttendance();
  }

  loadAttendance() {
    this.attendanceService.getAll()
      .subscribe(res => this.attendanceList = res);
  }

  markAttendance() {

    const attendance: Attendance = {
      id: 0,
      employeeId: this.employeeId,
      date: new Date().toISOString(),
      status: 'Present'
    };

    this.attendanceService.mark(attendance)
      .subscribe(() => {
        alert("Attendance Marked Successfully");
        this.loadAttendance();
      });
  }
}