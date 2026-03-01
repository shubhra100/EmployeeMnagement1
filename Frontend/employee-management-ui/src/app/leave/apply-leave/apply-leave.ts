import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LeaveService } from '../../core/services/leave';
import { Router } from '@angular/router';

@Component({
  selector: 'app-apply-leave',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './apply-leave.html'
})
export class ApplyLeaveComponent implements OnInit {

  form!: FormGroup;   // declare only

  errorMessage = '';

  constructor(
    private fb: FormBuilder,
    private leaveService: LeaveService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.form = this.fb.group({
      employeeId: ['', Validators.required],
      startDate: ['', Validators.required],
      endDate: ['', Validators.required],
      reason: ['', Validators.required]
    });
  }

  submit() {

    if (this.form.invalid) return;

    const start = new Date(this.form.value.startDate!);
    const end = new Date(this.form.value.endDate!);

    if (end <= start) {
      this.errorMessage = "End Date must be greater than Start Date";
      return;
    }

    this.leaveService.apply(this.form.value as any)
      .subscribe(() => {
        this.router.navigate(['/leave/list']);
      });
  }
}