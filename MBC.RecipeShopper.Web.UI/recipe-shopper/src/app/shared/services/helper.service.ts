import { Injectable } from '@angular/core';
import { ToastaService, ToastaConfig, ToastOptions } from 'ngx-toasta';
import { NotificationResult } from './../models/notification-result';

declare const $: any;

export class Message {
  toastOptions: ToastOptions = {
    title: "Hm..",
    msg: "",
    showClose: true,
    timeout: 3000,
  };
  constructor(private toastaService: ToastaService, private toastaConfig: ToastaConfig) {
    toastaConfig.theme = 'bootstrap'


  }
  public success(result: NotificationResult): void {
    if (result && result.messages.length > 0) {
      this.toastOptions.msg = result.messages[0].message
      this.toastaService.success(this.toastOptions);
    }
  }

  public error(result: NotificationResult): void {
    if (result && result.errors.length > 0) {
      this.toastaService.error(result.errors[0].message);
    }
  }

  public errorMessage(message: string) {
    this.toastaService.error(message);
  }

}

@Injectable()
export class HelperService {

  public message: Message = new Message(this.toastaService, this.toastaConfig);

  constructor(
    public toastaService: ToastaService, public toastaConfig: ToastaConfig) { }

}
