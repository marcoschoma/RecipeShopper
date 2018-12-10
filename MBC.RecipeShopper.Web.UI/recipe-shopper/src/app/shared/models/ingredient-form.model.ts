import { FormControl } from "@angular/forms";
import { Ingredient } from "./ingredient.model";

export class IngredientForm {
    description = new FormControl()
    id = new FormControl()

    constructor(ingredient: Ingredient) {
        if(ingredient.id) {
            this.id.setValue(ingredient.id)
        }
        if(ingredient.description) {
            this.description.setValue(ingredient.description)
        }
    }
}