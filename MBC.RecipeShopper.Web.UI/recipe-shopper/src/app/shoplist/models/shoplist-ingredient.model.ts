import { Ingredient } from '../../shared/models/ingredient.model'
import { AmountType } from '../../shared/models/amount-type.model'

export class ShoplistIngredient {
    id: number
    shoplistId: number
    amount: number
    ingredient?: Ingredient
    amountType?: AmountType
}