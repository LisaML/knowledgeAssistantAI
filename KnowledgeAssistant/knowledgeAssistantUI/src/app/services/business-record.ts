import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BusinessRecord } from '../models/business-record';

@Injectable({
  providedIn: 'root'
})
export class BusinessRecordService {

  private http = inject(HttpClient);

  private apiUrl = 'http://localhost:5020/api/BusinessRecords';

  getAll(): Observable<BusinessRecord[]> {
    return this.http.get<BusinessRecord[]>(this.apiUrl);
  }

  create(record: BusinessRecord): Observable<BusinessRecord> {
    return this.http.post<BusinessRecord>(this.apiUrl, record);
  }
}