import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmployeeService } from '../../core/services/employee.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
@Component({
  selector: 'app-employee-form',
  imports: [CommonModule, RouterModule,ReactiveFormsModule],
  templateUrl: './employee-form.html',
  styleUrl: './employee-form.css',
})
export class EmployeeForm implements OnInit{
  form!: FormGroup;
  id!: number;
  isEdit = false;

  constructor(
    private fb: FormBuilder,
    private employeeService: EmployeeService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    this.form = this.fb.group({
      fullName: ['', [Validators.required, Validators.minLength(3)]],
      email: ['', [Validators.required, Validators.email]],
      department: ['', Validators.required],
      salary: ['', [Validators.required, Validators.min(1000)]],
      userId: ['', Validators.required]
    });
  this.id = Number(this.route.snapshot.paramMap.get('id'));

    if(this.id) {
      this.isEdit = true;
      this.employeeService.getById(this.id).subscribe(res => {
        this.form.patchValue(res);
      });
    }
  }

  submit() {
    if(this.form.invalid) return;

    if(this.isEdit) {
      this.employeeService.update(this.id, this.form.value)
        .subscribe(() => this.router.navigate(['/employees']));
    }
    else {
      this.employeeService.create(this.form.value)
        .subscribe(() => this.router.navigate(['/employees']));
    }
  }

}
