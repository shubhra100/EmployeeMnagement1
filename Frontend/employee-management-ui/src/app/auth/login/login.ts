import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../core/services/auth';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.html',
  styleUrls: ['./login.css']
})
export class Login {

  username = '';
  password = '';
  errorMessage = '';

  constructor(
    private authService: AuthService,
    private router: Router
  ) {}

  login() {

    const credentials = {
      username: this.username,
      password: this.password
    };

    this.authService.login(credentials)
      .subscribe({
        next: (res: any) => {

          localStorage.setItem('token', res.token);
          localStorage.setItem('role', res.role);

          if (res.role === 'Admin' || res.role === 'HR') {
            this.router.navigate(['/employees']);
          }
          else {
            this.router.navigate(['/leave/apply']);
          }

        },
        error: () => {
          this.errorMessage = "Invalid username or password";
        }
      });
  }
}