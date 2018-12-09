import { TestBed } from '@angular/core/testing';

import { CreateRecipeService } from './create-recipe.service';

describe('CreateRecipeService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CreateRecipeService = TestBed.get(CreateRecipeService);
    expect(service).toBeTruthy();
  });
});
