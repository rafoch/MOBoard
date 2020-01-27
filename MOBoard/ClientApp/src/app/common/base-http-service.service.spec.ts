import { TestBed } from '@angular/core/testing';

import { BaseHttpServiceService } from './base-http-service.service';

describe('BaseHttpServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BaseHttpServiceService = TestBed.get(BaseHttpServiceService);
    expect(service).toBeTruthy();
  });
});
