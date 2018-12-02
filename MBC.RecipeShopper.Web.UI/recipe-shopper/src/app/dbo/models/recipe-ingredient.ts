import { Ingredient } from './ingredient'
import { AmountType } from './amount-type'

export interface RecipeIngredient {
    id: number
    ingredientId: number
    amountTypeId: number
    name: string
    steps: string
    amount: number
    ingredient?: Ingredient
    amountType?: AmountType
}
