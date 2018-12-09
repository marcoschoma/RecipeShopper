import { Component, TemplateRef } from '@angular/core';
import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';

@Component({
  selector: 'app-shoplist-details',
  templateUrl: './shoplist-details.component.html',
  styleUrls: ['./shoplist-details.component.css']
})
export class ShoplistDetailsComponent {
  modalRef: BsModalRef;
  constructor(private modalService: BsModalService) { }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }
  closeFirstModal() {
    this.modalRef.hide();
    this.modalRef = null;
  }
}
