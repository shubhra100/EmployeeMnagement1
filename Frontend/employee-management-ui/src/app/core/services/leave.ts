
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LeaveRequest } from '../../models/leave.model';

@Injectable({
  providedIn: 'root'
})
export class LeaveService {

  private apiUrl = 'https://localhost:5001/api/leave';

  constructor(private http: HttpClient) {}

  private getHeaders(): HttpHeaders {
    const token = localStorage.getItem('token');
    return new HttpHeaders().set('Authorization', `Bearer ${token}`);
  }

  getAll(): Observable<LeaveRequest[]> {
    return this.http.get<LeaveRequest[]>(this.apiUrl, {
      headers: this.getHeaders()
    });
  }

  apply(data: LeaveRequest) {
    return this.http.post(this.apiUrl, data, {
      headers: this.getHeaders()
    });
  }

  updateStatus(id: number, status: string) {
    return this.http.put(`${this.apiUrl}/${id}/status`, { status }, {
      headers: this.getHeaders()
    });
  }
}