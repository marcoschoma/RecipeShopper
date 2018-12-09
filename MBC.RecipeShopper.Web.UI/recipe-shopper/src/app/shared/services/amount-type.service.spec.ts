import { TestBed } from '@angular/core/testing';

import { AmountTypeService } from './amount-type.service';

describe('AmountTypeService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AmountTypeService = TestBed.get(AmountTypeService);
    expect(service).toBeTruthy();
  });
});
