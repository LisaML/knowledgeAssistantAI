import { TestBed } from '@angular/core/testing';

import { BusinessRecord } from './business-record';

describe('BusinessRecord', () => {
  let service: BusinessRecord;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BusinessRecord);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
