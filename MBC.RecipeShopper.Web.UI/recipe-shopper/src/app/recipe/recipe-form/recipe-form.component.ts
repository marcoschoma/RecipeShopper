import { Component, OnInit } from '@angular/core';
import { FormGroup, FormArray } from '@angular/forms';
import { Subscription } from 'rxjs';
import { RecipeFormService } from '../services/recipe-form.service';
import { Ingredient } from 'src/app/shared/models/ingredient.model';
import { AmountType } from 'src/app/shared/models/amount-type.model';
import { IngredientService } from 'src/app/shared/services/ingredient.service';
import { AmountTypeService } from 'src/app/shared/services/amount-type.service';

@Component({
  selector: 'app-recipe-form',
  templateUrl: './recipe-form.component.html',
  styleUrls: ['./recipe-form.component.css']
})
export class RecipeFormComponent implements OnInit {
  recipeForm: FormGroup
  recipeFormSub: Subscription
  recipeIngredients: FormArray
  ingredients: Ingredient[]
  amountTypes: AmountType[]

  constructor(private recipeFormService: RecipeFormService,
    private ingredientService: IngredientService,
    private amountTypeService: AmountTypeService) { }

  ngOnInit() {
    this.recipeFormSub = this.recipeFormService.recipeForm$
      .subscribe(recipe => {
        this.recipeForm = recipe
        this.recipeIngredients = this.recipeForm.get('recipeIngredients') as FormArray
      })
    this.ingredientService.get().subscribe(ingredients => {
      this.ingredients = ingredients
    })
    this.amountTypeService.get().subscribe(amountTypes => {
      this.amountTypes = amountTypes
    })
  }

  ngOnDestroy() {
    this.recipeFormSub.unsubscribe()
  }

  addRecipeIngredient() {
    this.recipeFormService.addRecipeIngredient()
  }

  deleteRecipeIngredient(index: number) {
    this.recipeFormService.deleteRecipeIngredient(index)
  }

  saveRecipe() {
    this.recipeFormService.save(this.recipeForm)
  }
}
