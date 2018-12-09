import { Component, OnInit } from '@angular/core';
import { Recipe } from '../models/recipe.model';
import { RecipeService } from '../services/recipe.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  collapsed: true
  recipes: Recipe[]
  constructor(private recipeService: RecipeService) { }

  ngOnInit() {
    this.recipeService.get().subscribe(recipes => {
      this.recipes = recipes
    })
  }

}
