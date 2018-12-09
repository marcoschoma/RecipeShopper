import { Ingredient } from '../../../shared/models/ingredient.model'
import { AmountType } from '../../../shared/models/amount-type.model'

export class RecipeIngredient {
    id: number
    ingredientId: number
    amountTypeId: number
    amount: number
    ingredient?: Ingredient
    amountType?: AmountType
}
