import { Pipe, PipeTransform } from '@angular/core';
import { ShoplistIngredient } from '../../models/shoplist-ingredient';

@Pipe({ name: 'describeIngredients' })
export class DescribeIngredients implements PipeTransform {

    transform(shoplistIngredients: ShoplistIngredient[]) {
        if (!shoplistIngredients || shoplistIngredients.length == 0)
            return ''

        let allIngredients = shoplistIngredients.map(si =>
            si.amount + ' ' + si.amountType.description + ' ' + si.ingredient.description
        ).join(',')
        if (allIngredients.length > 100)
            return allIngredients.substring(0, 100) + '...'
        else
            return allIngredients
    }
}