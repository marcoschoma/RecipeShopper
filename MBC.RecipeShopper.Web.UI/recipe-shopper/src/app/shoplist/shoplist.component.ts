import { Component, OnInit } from '@angular/core';
import { ShoplistService } from './services/shoplist.service';
import { Shoplist } from './models/shoplist.model';

@Component({
  selector: 'app-shoplist',
  templateUrl: './shoplist.component.html',
  styleUrls: ['./shoplist.component.css']
})
export class ShoplistComponent implements OnInit {

  shoplists: Shoplist[]
  constructor(private shoplistService: ShoplistService) { }

  ngOnInit() {
    this.load()
  }
  load() {
    this.shoplistService.get().subscribe(shoplists =>
      this.shoplists = shoplists)
  }
  remove(id) {
    this.shoplistService.delete(id).subscribe(result => {
      if(result.isValid)
        this.load()
      else 
        alert(result.errors.map(err => err.message).join(', '))
    }
    )
  }

}
