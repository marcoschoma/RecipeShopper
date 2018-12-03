import { Component, OnInit } from '@angular/core';
import { ShoplistService } from '../../services/shoplist/shoplist.service';
import { HelperService } from 'src/app/shared/services/helper.service';

@Component({
  selector: 'app-shoplist',
  templateUrl: './shoplist.component.html',
  styleUrls: ['./shoplist.component.css']
})
export class ShoplistComponent implements OnInit {

  constructor(
    private shoplistService: ShoplistService,
    private helperService: HelperService
  ) { }

  ngOnInit() {
  }

}
