import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { FormGroup, FormBuilder, FormArray } from '@angular/forms';
import { CreateRecipe } from '../../models/create-recipe';
import { Recipe } from '../../models/recipe';
import { RecipeIngredientComponent } from '../../pages/recipe/recipe-ingredient/recipe-ingredient.component';
import { CreateRecipeIngredient } from '../../models/create-recipe-ingredient';
import { RecipeIngredient } from '../../models/recipe-ingredient';

@Injectable({
  providedIn: 'root'
})
export class CreateRecipeService {
  private createRecipe: BehaviorSubject<FormGroup | undefined> =
    new BehaviorSubject(this.fb.group(
      new CreateRecipe({} as Recipe)
    ))
  
  recipeForm$: Observable<FormGroup> = this.createRecipe.asObservable()
  constructor(private fb: FormBuilder) {}
  addIngredient() {
    const currentRecipe = this.createRecipe.getValue()
    const currentIngredients = currentRecipe.get('recipeIngredients') as FormArray
    currentIngredients.push(
      this.fb.group(
        new CreateRecipeIngredient({} as RecipeIngredient)
      )
    )
    this.createRecipe.next(currentRecipe)
  }
  deleteIngredient(i: number) {
    const currentRecipe = this.createRecipe.getValue()
    const currentRecipeIngredients = currentRecipe.get('recipeIngredients') as FormArray
    currentRecipeIngredients.removeAt(i)
    this.createRecipe.next(currentRecipe)
  }
}
