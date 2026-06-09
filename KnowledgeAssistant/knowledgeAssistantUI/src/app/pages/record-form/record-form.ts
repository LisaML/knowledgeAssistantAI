import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BusinessRecordService } from '../../services/business-record';
import { BusinessRecord } from '../../models/business-record';

@Component({
  selector: 'app-record-form',
  imports: [FormsModule],
  templateUrl: './record-form.html',
  styleUrl: './record-form.css'
})
export class RecordForm {

  private service = inject(BusinessRecordService);

  record: BusinessRecord = {
    title: '',
    content: '',
    department: ''
  };

  save() {

    this.service.create(this.record)
      .subscribe({

        next: response => {

          alert('Registro creado correctamente');

          this.record = {
            title: '',
            content: '',
            department: ''
          };

        },

        error: error => {

          console.error(error);

        }

      });

  }

}