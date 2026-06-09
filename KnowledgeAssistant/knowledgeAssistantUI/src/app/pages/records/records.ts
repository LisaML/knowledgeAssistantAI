import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BusinessRecordService } from '../../services/business-record';
import { BusinessRecord } from '../../models/business-record';
import { AiService, AIAnalysis } from '../../services/ai';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-records',
  imports: [CommonModule, RouterLink],
  templateUrl: './records.html',
  styleUrl: './records.css'
})
export class Records implements OnInit {

  records: BusinessRecord[] = [];
  analyses: { [key: number]: AIAnalysis } = {};
  loadingRecordId: number | null = null;

  private service = inject(BusinessRecordService);
  private aiService = inject(AiService);

  ngOnInit(): void {
    this.loadRecords();
  }

  loadRecords(): void {
    this.service.getAll().subscribe({
      next: data => this.records = data,
      error: error => console.error(error)
    });
  }

  analyze(recordId: number | undefined): void {
    if (!recordId) return;

    this.loadingRecordId = recordId;

    this.aiService.analyze(recordId).subscribe({
      next: analysis => {
        this.analyses[recordId] = analysis;
        this.loadingRecordId = null;
      },
      error: error => {
        console.error(error);
        alert('Error al analizar con IA');
        this.loadingRecordId = null;
      }
    });
  }
}