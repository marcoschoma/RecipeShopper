import { Component, OnInit, Input } from '@angular/core';
import { ShoplistService } from '../services/shoplist.service';
import { RecipeService } from 'src/app/recipe/services/recipe.service';
import { Recipe } from 'src/app/recipe/models/recipe.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-shoplist-form',
  templateUrl: './shoplist-form.component.html',
  styleUrls: ['./shoplist-form.component.css']
})
export class ShoplistFormComponent implements OnInit {

  @Input() selectedRecipeId: number
  @Input() selectedRecipeName: String

  constructor(
    private shoplistService: ShoplistService,
    private recipeService: RecipeService,
    private router: Router
  ) { }

  availableRecipes: Recipe[] = []
  selectedRecipes: Recipe[] = []

  ngOnInit() {
    this.recipeService.get().subscribe(data => {
      this.availableRecipes = data
    })
  }

  addRecipe() {
    if (!this.selectedRecipes.some(r => r.id == this.selectedRecipeId))
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
    ).subscribe(result => {
      console.log(result)
      this.router.navigate(['/shoplist'])
    })
  }
}
