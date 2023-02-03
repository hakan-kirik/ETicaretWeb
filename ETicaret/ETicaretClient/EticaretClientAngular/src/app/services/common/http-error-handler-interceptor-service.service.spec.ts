import { TestBed } from '@angular/core/testing';

import { HttpErrorHandlerInterceptorServiceService } from './http-error-handler-interceptor-service.service';

describe('HttpErrorHandlerInterceptorServiceService', () => {
  let service: HttpErrorHandlerInterceptorServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HttpErrorHandlerInterceptorServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
