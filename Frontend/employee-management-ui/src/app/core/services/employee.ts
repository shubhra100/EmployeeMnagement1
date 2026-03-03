import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from '../../models/employee.model';

@Injectable({ providedIn: 'root' })
export class EmployeeService {

  private apiUrl = 'https://localhost:7239/api/Employee';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.apiUrl);
  }

  getById(id: number): Observable<Employee> {
    return this.http.get<Employee>(`${this.apiUrl}/${id}`);
  }
  create(employee: Employee) {
  return this.http.post(this.apiUrl, employee);
}

  add(emp: Employee) {
    return this.http.post(this.apiUrl, emp);
  }

  update(id: number, emp: Employee) {
    return this.http.put(`${this.apiUrl}/${id}`, emp);
  }

  delete(id: number) {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}