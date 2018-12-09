import { Ingredient } from './ingredient'
import { AmountType } from './amount-type'

export interface ShoplistIngredient {
    id: number
    shoplistId: number
    amount: number
    ingredient?: Ingredient
    amountType?: AmountType
}