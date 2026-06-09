import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AiService } from '../../services/ai';

@Component({
  selector: 'app-chat',
  imports: [FormsModule, CommonModule],
  templateUrl: './chat.html',
  styleUrl: './chat.css'
})
export class Chat {

  private aiService = inject(AiService);

  question = '';
  answer = '';
  loading = false;

  ask() {

    if (!this.question.trim()) {

      alert('Escribe una pregunta');

      return;

    }

    this.loading = true;

    this.answer = '';

    this.aiService.ask(this.question)
      .subscribe({

        next: response => {

          this.answer = response.answer;

          this.loading = false;

        },

        error: error => {

          console.error(error);

          this.answer = 'Ocurrió un error al consultar la IA.';

          this.loading = false;

        }

      });

  }

}