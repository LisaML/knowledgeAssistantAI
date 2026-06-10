import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { BusinessRecordService } from '../../services/business-record';
import { BusinessRecord } from '../../models/business-record';
import { AiService, AIAnalysis } from '../../services/ai';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-records',
  imports: [CommonModule, RouterLink, FormsModule],
  templateUrl: './records.html',
  styleUrl: './records.css'
})
export class Records implements OnInit {

  records: BusinessRecord[] = [];
  analyses: { [key: number]: AIAnalysis } = {};
  loadingRecordId: number | null = null;
  currentPage = 1;
  pageSize = 5;

  private service = inject(BusinessRecordService);
  private aiService = inject(AiService);

  ngOnInit(): void {
    this.loadRecords();
  }

  loadRecords(): void {
    this.service.getAll().subscribe({
      next: data => {
      this.records = data;
      this.currentPage = 1;
    },
      error: error => console.error(error)
    });
  }

    searchTerm = '';

  selectedDepartment = '';

  departments = [
    'RH',
    'Ventas',
    'Producción',
    'Calidad',
    'TI',
    'Finanzas'
  ];

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

  search(): void {

    if (!this.searchTerm.trim()) {

      this.loadRecords();

      return;

    }

    this.service.search(this.searchTerm)
      .subscribe({

        next: data => {
        this.records = data;
        this.currentPage = 1;
      },

        error: error => console.error(error)

      });

  }

  filter(): void {

    if (!this.selectedDepartment) {

      this.loadRecords();

      return;

    }

    this.service.filter(this.selectedDepartment)
      .subscribe({

        next: data => {
        this.records = data;
        this.currentPage = 1;
      },

        error: error => console.error(error)

      });

  }

  deleteRecord(id: number | undefined): void {

    if (!id) return;

    const confirmed =
      confirm(
        '¿Desea eliminar el registro?');

    if (!confirmed)
      return;

    this.service.delete(id)
      .subscribe({

        next: () => {

          this.loadRecords();

        },

        error: error => {

          console.error(error);

        }

      });

  }
  get paginatedRecords(): BusinessRecord[] {
    const startIndex = (this.currentPage - 1) * this.pageSize;
    return this.records.slice(startIndex, startIndex + this.pageSize);
  }

  get totalPages(): number {
    return Math.ceil(this.records.length / this.pageSize);
  }

  nextPage(): void {
    if (this.currentPage < this.totalPages) {
      this.currentPage++;
    }
  }

  previousPage(): void {
    if (this.currentPage > 1) {
      this.currentPage--;
    }
  }
}