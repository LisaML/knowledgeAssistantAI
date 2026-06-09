import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface AskResponse {
  question: string;
  answer: string;
}

@Injectable({
  providedIn: 'root'
})
export class AiService {

  private http = inject(HttpClient);

  private apiUrl = 'http://localhost:5020/api/AI';

  ask(question: string): Observable<AskResponse> {
    return this.http.post<AskResponse>(`${this.apiUrl}/ask`, {
      question: question
    });
  }

  analyze(recordId: number): Observable<any> {
    return this.http.post(`${this.apiUrl}/analyze/${recordId}`, {});
  }
}