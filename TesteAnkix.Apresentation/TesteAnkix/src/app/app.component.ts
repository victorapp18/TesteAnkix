
import { Component, OnInit, Inject } from '@angular/core';
import { DataService } from './services/data.service';
import { Country } from './models/Country';
import { Rate } from './models/Rate';
import { Vat } from './models/Vat';
import { DOCUMENT } from '@angular/common';
import { Calculed } from './models/Calculed';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'TesteAnkix';
  countries: Country[] | undefined;
  rates: Rate[] = [];
  vats: Vat[] | undefined;
  vatIdValue!: Number;
  
  constructor(private dataService: DataService, @Inject(DOCUMENT) document: Document) {}
  
  ngOnInit(): void {
    this.getCountries();
    this.getVats();
    this.getRatesInit();
  }

  onOptionsCountrySelected(value:any){
    this.dataService.getRateByCountryId(value)
      .subscribe({
        next: (data) => {
          this.rates = data.result;
         
          if(Number(this.vatIdValue) > 0)
            this.getCalculed()

        },
        error: (e) => console.error(e)
      });
}
onKeyUp(vatId:number){
  this.vatIdValue = vatId
  this.getCalculed()
}

onOptionsRadioRateSelected(){
  this.getCalculed()
}

getCalculed(){
  (<HTMLInputElement>document.getElementById("divNesage")).style.display = "none";

  var ratIdValue =(<HTMLInputElement> document.querySelector('input[name=radioRate]:checked')).value
  const dataInput = 
      {
          rateId : ratIdValue,
          vatId : this.vatIdValue,
          value : this.vatIdValue == 1 ? Number((<HTMLInputElement>document.getElementById("numberInputVat1")).value) :
          this.vatIdValue == 2 ? Number((<HTMLInputElement>document.getElementById("numberInputVat2")).value) :
          Number((<HTMLInputElement>document.getElementById("numberInputVat3")).value)
      }

  this.dataService.getCalculed(dataInput)
    .subscribe({
      next: (data) => {
        (<HTMLInputElement>document.getElementById("numberInputVat1")).value = data.result.Net;
        (<HTMLInputElement>document.getElementById("numberInputVat2")).value = data.result.Vat;
        (<HTMLInputElement>document.getElementById("numberInputVat3")).value = data.result.Gross;
      },
      error: (e) => {
          (<HTMLInputElement>document.getElementById("labelNesage")).innerHTML = e;
          (<HTMLInputElement>document.getElementById("divNesage")).style.display = "block";
      }
    });
}

onOptionsVatSelected(value:any){
  const numberInputVat = document.getElementsByName("numberInputVat");
  for(var i = 0; numberInputVat.length > i; i++) {
    numberInputVat[i].setAttribute("disabled", "disabled");
  }
  document.getElementById("numberInputVat" + value)?.removeAttribute("disabled");
}

getVats(): void {
  this.dataService.getVatAll()
    .subscribe({
      next: (data) => {
        this.vats = data.result;
      },
      error: (e) => console.error(e)
    });
}

getCountries(): void {
  this.dataService.getCountrytAll()
    .subscribe({
      next: (data) => {
        this.countries = data.result;
      },
      error: (e) => console.error(e)
    });
}

  getRatesInit(): void {
    this.dataService.getRateByCountryId(1)
      .subscribe({
        next: (data) => {
          this.rates = data.result;
        },
        error: (e) => console.error(e)
      });
  }
}
