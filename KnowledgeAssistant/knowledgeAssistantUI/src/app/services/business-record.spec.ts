import { TestBed } from '@angular/core/testing';
import { provideHttpClient } from '@angular/common/http';

import { BusinessRecordService } from './business-record';

describe('BusinessRecordService', () => {

  let service: BusinessRecordService;

  beforeEach(() => {

    TestBed.configureTestingModule({
      providers: [
        provideHttpClient()
      ]
    });

    service = TestBed.inject(BusinessRecordService);

  });

  it('should be created', () => {

    expect(service).toBeTruthy();

  });

});