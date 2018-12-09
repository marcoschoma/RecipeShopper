import { FormControl, Validators } from '@angular/forms'
import { RecipeIngredient } from './recipe-ingredient';

export class CreateRecipeIngredient {
  name = new FormControl()
  amout = new FormControl()
  amountTypeId = new FormControl()
  ingredientId = new FormControl()

  constructor(
    recipeIngredient: RecipeIngredient
  ) {
    this.name.setValue(recipeIngredient.name)
    this.name.setValidators([Validators.required])

    this.amout.setValue(recipeIngredient.amount)

    this.amountTypeId.setValue(recipeIngredient.amountTypeId)

    this.ingredientId.setValue(recipeIngredient.ingredientId)
    this.ingredientId.setValidators([Validators.required])
  }
}