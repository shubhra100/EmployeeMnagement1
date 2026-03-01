
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LeaveService } from '../../core/services/leave';
import { LeaveRequest } from '../../models/leave.model';

@Component({
  selector: 'app-leave-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './leave-list.html',
  styleUrl: './leave-list.css',
})
export class LeaveListComponent implements OnInit {

  leaves: LeaveRequest[] = [];

  constructor(private leaveService: LeaveService) {}

  ngOnInit() {
    this.leaveService.getAll()
      .subscribe(res => this.leaves = res);
  }

  update(id: number, status: string) {
    this.leaveService.updateStatus(id, status)
      .subscribe(() => {
        this.ngOnInit();
      });
  }
}