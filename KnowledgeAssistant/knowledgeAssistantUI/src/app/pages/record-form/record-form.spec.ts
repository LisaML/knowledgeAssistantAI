import { ComponentFixture, TestBed } from '@angular/core/testing';
import { provideHttpClient } from '@angular/common/http';
import { provideRouter } from '@angular/router';

import { RecordForm } from './record-form';

describe('RecordForm', () => {
  let component: RecordForm;
  let fixture: ComponentFixture<RecordForm>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RecordForm],
      providers: [
        provideHttpClient(),
        provideRouter([])
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(RecordForm);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});