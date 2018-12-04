import { Component, OnInit, Input } from '@angular/core';
import { ShoplistService } from 'src/app/dbo/services/shoplist/shoplist.service';
import { RecipeService } from 'src/app/dbo/services/recipe/recipe.service';
import { Recipe } from 'src/app/dbo/models/recipe';

@Component({
  selector: 'app-create-shoplist',
  templateUrl: './create-shoplist.component.html',
  styleUrls: ['./create-shoplist.component.css']
})
export class CreateShoplistComponent implements OnInit {

  @Input() selectedRecipeId: number
  @Input() selectedRecipeName: String

  constructor(
    private shoplistService: ShoplistService,
    private recipeService: RecipeService
  ) { }

  availableRecipes: Recipe[] = []
  selectedRecipes: Recipe[] = []

  ngOnInit() {
    this.recipeService.get().subscribe(data => {
      this.availableRecipes = data
    })
  }

  addRecipe() {
    this.selectedRecipes.push({
      id: this.selectedRecipeId,
      name: this.selectedRecipeName
    } as Recipe)
  }

  changeRecipe(event: Event) {
    let selectElementText = event.target['options'][event.target['options'].selectedIndex].text;
    this.selectedRecipeName = selectElementText;
  }
  saveShoplist() {
    this.shoplistService.createFromRecipeIdList(
      this.selectedRecipes.map(r => r.id)
    )
  }

}
