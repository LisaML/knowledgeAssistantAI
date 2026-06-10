import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BusinessRecord } from '../models/business-record';

@Injectable({
  providedIn: 'root'
})
export class BusinessRecordService {

  private http = inject(HttpClient);

  private apiUrl = 'http://localhost:5020/api/v1/BusinessRecords';

  getAll(): Observable<BusinessRecord[]> {
    return this.http.get<BusinessRecord[]>(this.apiUrl);
  }

  getById(id: number): Observable<BusinessRecord> {
    return this.http.get<BusinessRecord>(`${this.apiUrl}/${id}`);
  }

  create(record: BusinessRecord): Observable<BusinessRecord> {
    return this.http.post<BusinessRecord>(this.apiUrl, record);
  }

  update(record: BusinessRecord): Observable<any> {
    return this.http.put(`${this.apiUrl}/${record.id}`, record);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  search(term: string): Observable<BusinessRecord[]> {
    return this.http.get<BusinessRecord[]>(`${this.apiUrl}/search?term=${term}`);
  }

  filter(department: string): Observable<BusinessRecord[]> {
    return this.http.get<BusinessRecord[]>(`${this.apiUrl}/filter?department=${department}`);
  }
}