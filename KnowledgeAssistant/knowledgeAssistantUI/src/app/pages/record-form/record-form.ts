import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BusinessRecordService } from '../../services/business-record';
import { BusinessRecord } from '../../models/business-record';

@Component({
  selector: 'app-record-form',
  imports: [FormsModule],
  templateUrl: './record-form.html',
  styleUrl: './record-form.css'
})
export class RecordForm implements OnInit {

  private service = inject(BusinessRecordService);
  private route = inject(ActivatedRoute);
  private router = inject(Router);

  isEditMode = false;

  record: BusinessRecord = {
    title: '',
    content: '',
    department: ''
  };

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');

    if (id) {
      this.isEditMode = true;

      this.service.getById(Number(id))
        .subscribe({
          next: data => this.record = data,
          error: error => console.error(error)
        });
    }
  }

  save(): void {
    if (this.isEditMode) {
      this.update();
    } else {
      this.create();
    }
  }

  create(): void {
    this.service.create(this.record)
      .subscribe({
        next: () => {
          alert('Registro creado correctamente');
          this.router.navigate(['/records']);
        },
        error: error => console.error(error)
      });
  }

  update(): void {
    this.service.update(this.record)
      .subscribe({
        next: () => {
          alert('Registro actualizado correctamente');
          this.router.navigate(['/records']);
        },
        error: error => console.error(error)
      });
  }
}