import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

import { IngredientService } from '../ingredient.service';
import { Ingredient } from '../ingredient.model';

@Component({
  selector: 'app-ingredient-edit',
  templateUrl: './ingredient-edit.component.html',
  styleUrls: ['./ingredient-edit.component.css']
})
export class IngredientEditComponent implements OnInit {
  ingredientForm: FormGroup;

  constructor(
    private ingredientService: IngredientService,
    private toastrService: ToastrService) { }

  ngOnInit() {
    this.initForm();
  }

  private initForm() {
    this.ingredientForm = new FormGroup({
      'name': new FormControl(null, Validators.required)
    });
  }

  onSubmit() {
    const ingredientToAdd = new Ingredient(this.ingredientForm.value['name']);

    this.ingredientService.add(ingredientToAdd).subscribe(newIngredient => {
      this.ingredientService.ingredientsChanged.next(newIngredient);
      this.ingredientForm.reset();

      this.toastrService.success(`${newIngredient.name} ingredient has been added!`, `New ingredient`);
    },
      error => alert(`An error has occured while adding the ingredient: ${error.message}`)
    );
  }
}
