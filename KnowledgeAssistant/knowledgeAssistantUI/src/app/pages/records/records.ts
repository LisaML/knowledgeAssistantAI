import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BusinessRecordService } from '../../services/business-record';
import { BusinessRecord } from '../../models/business-record';

@Component({
  selector: 'app-records',
  imports: [CommonModule],
  templateUrl: './records.html',
  styleUrl: './records.css'
})
export class Records implements OnInit {

  records: BusinessRecord[] = [];

  private service = inject(BusinessRecordService);

  ngOnInit(): void {
    this.service.getAll().subscribe({
      next: data => {
        console.log('Registros:', data);
        this.records = data;
      },
      error: error => {
        console.error('Error cargando registros:', error);
      }
    });
  }
}