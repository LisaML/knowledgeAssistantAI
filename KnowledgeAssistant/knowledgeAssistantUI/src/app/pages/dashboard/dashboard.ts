import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { BusinessRecordService } from '../../services/business-record';
import { BusinessRecord } from '../../models/business-record';

@Component({
  selector: 'app-dashboard',
  imports: [CommonModule, RouterLink],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css'
})
export class Dashboard implements OnInit {

  records: BusinessRecord[] = [];

  private service = inject(BusinessRecordService);

  ngOnInit(): void {
    this.service.getAll().subscribe({
      next: data => this.records = data,
      error: error => console.error(error)
    });
  }

  get totalRecords(): number {
    return this.records.length;
  }

  get totalDepartments(): number {
    return new Set(this.records.map(r => r.department)).size;
  }
}