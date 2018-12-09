import { FormControl } from '@angular/forms';
import { RecipeIngredient } from './recipe-ingredient.model';
import { Ingredient } from 'src/app/shared/models/ingredient.model';
import { AmountType } from 'src/app/shared/models/amount-type.model';

export class RecipeIngredientForm {
    id = new FormControl();
    ingredientId = new FormControl();
    amountTypeId = new FormControl();
    amount = new FormControl();

    constructor(recipeIngredient: RecipeIngredient) {
        if (recipeIngredient.id)
            this.id.setValue(recipeIngredient.id)
        if (recipeIngredient.ingredientId)
            this.ingredientId.setValue(recipeIngredient.ingredientId)
        if (recipeIngredient.amountTypeId)
            this.amountTypeId.setValue(recipeIngredient.amountTypeId)
        if (recipeIngredient.amount)
            this.amount.setValue(recipeIngredient.amount)
    }
}
