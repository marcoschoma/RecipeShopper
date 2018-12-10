import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormArray } from '@angular/forms';
import { IngredientForm } from '../../models/ingredient-form.model';
import { ActivatedRoute, Router } from '@angular/router';
import { IngredientService } from '../../services/ingredient.service';
import { Ingredient } from '../../models/ingredient.model';

@Component({
  selector: 'app-ingredient-form',
  templateUrl: './ingredient-form.component.html',
  styleUrls: ['./ingredient-form.component.css']
})
export class IngredientFormComponent implements OnInit {

  @Input() ingredientId: number
  @Input() description: string
  constructor(private ingredientService: IngredientService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    this.ingredientId = this.route.snapshot.params['id']
    if (this.ingredientId) {
      this.ingredientService.getById(this.ingredientId).subscribe(result => {
        this.description = result.description
      })
    }
  }

  save() {
    const ingredient = new Ingredient(this.ingredientId, this.description)
    if (this.ingredientId)
      this.ingredientService.put(this.ingredientId, ingredient).subscribe(result => {
        this.router.navigate(['/ingredient'])
      })
    else
      this.ingredientService.post(ingredient).subscribe(result => {
        this.router.navigate(['/ingredient'])
      })
  }

}
