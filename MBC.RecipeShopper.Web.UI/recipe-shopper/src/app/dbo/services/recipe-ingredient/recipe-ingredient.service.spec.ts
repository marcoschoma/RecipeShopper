import { TestBed } from '@angular/core/testing';

import { RecipeIngredientService } from './recipe-ingredient.service';

describe('RecipeIngredientService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: RecipeIngredientService = TestBed.get(RecipeIngredientService);
    expect(service).toBeTruthy();
  });
});
