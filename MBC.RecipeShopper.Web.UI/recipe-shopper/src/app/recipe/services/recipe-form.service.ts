import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, throwError } from 'rxjs';
import { FormGroup, FormBuilder, FormArray } from '@angular/forms';
import { Recipe } from '../models/recipe.model';
import { RecipeForm } from '../models/recipe-form.model';
import { RecipeIngredientForm } from '../recipe-ingredient/models/recipe-ingredient-form.model';
import { RecipeIngredient } from '../recipe-ingredient/models/recipe-ingredient.model';
import { RecipeService } from './recipe.service';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class RecipeFormService {

  private recipeForm: BehaviorSubject<FormGroup | undefined> = new BehaviorSubject(this.fb.group(new RecipeForm(new Recipe())))
  recipeForm$: Observable<FormGroup> = this.recipeForm.asObservable()

  constructor(private fb: FormBuilder,
    private recipeService: RecipeService,
    private router: Router) { }

  addRecipeIngredient() {
    const currentRecipe = this.recipeForm.getValue()
    const currentRecipeIngredients = currentRecipe.get('recipeIngredients') as FormArray

    currentRecipeIngredients.push(
      this.fb.group(
        new RecipeIngredientForm(new RecipeIngredient())
      )
    )

    this.recipeForm.next(currentRecipe)
  }

  deleteRecipeIngredient(i: number) {
    const currentRecipe = this.recipeForm.getValue()
    const currentRecipeIngredients = currentRecipe.get('recipeIngredients') as FormArray

    currentRecipeIngredients.removeAt(i)

    this.recipeForm.next(currentRecipe)
  }

  save(recipeForm: FormGroup) {
    this.recipeService.save(recipeForm.value)
      .subscribe(result => {
        if(result.isValid) {
          alert(result.messages.map(msg => msg.message).join(', '))
        } else {
          alert(result.errors.map(err => err.message).join(', '))
        }
        this.router.navigate(['/recipe'])
      })
  }
}
