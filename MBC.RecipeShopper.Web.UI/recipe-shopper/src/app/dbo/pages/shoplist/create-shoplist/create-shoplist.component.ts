import { Component, OnInit } from '@angular/core';
import { ShoplistService } from 'src/app/dbo/services/shoplist/shoplist.service';
import { RecipeService } from 'src/app/dbo/services/recipe/recipe.service';
import { Recipe } from 'src/app/dbo/models/recipe';

@Component({
  selector: 'app-create-shoplist',
  templateUrl: './create-shoplist.component.html',
  styleUrls: ['./create-shoplist.component.css']
})
export class CreateShoplistComponent implements OnInit {

  constructor(
    private shoplistService: ShoplistService,
    private recipeService: RecipeService
  ) { }

  availableRecipes: Recipe[] = []

  ngOnInit() {
    this.recipeService.get().subscribe(data => {
      this.availableRecipes = data
    })
  }

}
