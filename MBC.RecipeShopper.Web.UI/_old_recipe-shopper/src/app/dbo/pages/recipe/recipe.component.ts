import { Component, OnInit } from '@angular/core';
import { RecipeService } from '../../services/recipe/recipe.service';
import { Recipe } from '../../models/recipe';
import { HelperService } from 'src/app/shared/services/helper.service';

@Component({
  selector: 'app-recipe',
  templateUrl: './recipe.component.html',
  styleUrls: ['./recipe.component.css']
})
export class RecipeComponent implements OnInit {
  items: Recipe[] = []
  constructor(
    private recipeService: RecipeService,
    private helperService: HelperService
  ) { }

  ngOnInit() {
    this.recipeService.get().subscribe(data => {
      this.items = data
    })
  }

}
