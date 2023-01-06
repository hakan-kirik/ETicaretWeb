import { TestBed } from '@angular/core/testing';

import { CustomToasterService } from './custom-toaster.service';

describe('CustomToasterService', () => {
  let service: CustomToasterService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CustomToasterService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
