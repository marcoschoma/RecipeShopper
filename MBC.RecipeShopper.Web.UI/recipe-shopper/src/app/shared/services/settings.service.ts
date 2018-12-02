import { Injectable } from '@angular/core';

@Injectable()
export class SettingsService {

  private _locale: string;
  private _dateFormat: string;
  private _decimalSeparator: string;

  constructor() {
    this.locale = 'pt-BR';
  }

  get locale(): string {
    return this._locale;
  }

  set locale(str: string) {
    this._locale = str;

    if (str === 'en-US') {
      this._dateFormat = 'mm/dd/yyyy';
      this._decimalSeparator = '.';
    } else {
      this._dateFormat = 'dd/mm/yyyy';
      this._decimalSeparator = ',';
    }
  }

  get dateFormat(): string {
    return this._dateFormat;
  }

  get decimalSeparator(): string {
    return this._decimalSeparator;
  }

}
