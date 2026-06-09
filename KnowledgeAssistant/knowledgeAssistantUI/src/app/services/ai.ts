import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface AskResponse {
  question: string;
  answer: string;
}

export interface AIAnalysis {
  id: number;
  businessRecordId: number;
  summary: string;
  classification: string;
  recommendations: string;
  createdAt: string;
}

@Injectable({
  providedIn: 'root'
})
export class AiService {

  private http = inject(HttpClient);

  private apiUrl = 'http://localhost:5020/api/AI';

  ask(question: string): Observable<AskResponse> {
    return this.http.post<AskResponse>(`${this.apiUrl}/ask`, {
      question
    });
  }

  analyze(recordId: number): Observable<AIAnalysis> {
    return this.http.post<AIAnalysis>(`${this.apiUrl}/analyze/${recordId}`, {});
  }
}